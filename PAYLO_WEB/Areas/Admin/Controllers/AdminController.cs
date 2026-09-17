using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PAYLO_Classes.Admin;
using PAYLO_Classes.Associate;
using PAYLO_Classes.Common;
using PAYLO_WEB.Extensions;
using PAYLO_WEB.Models;
using PAYLO_WEB.Services;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace PAYLO_WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly CommanHttpServices _httpServices;
        private readonly IAuthService _authService;
        private readonly string? _apiBaseUrl;
        private readonly IConfiguration _configuration;
        private readonly string Allowfiles = ".jpg,.jpeg,.png,.webp,.avif,.pdf";
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminController(
            ILogger<AdminController> logger,
            IAuthService authService,
            CommanHttpServices commonHttpServices,
            HttpClient httpClient,
            IWebHostEnvironment webHostEnvironment,
            IConfiguration configuration)
        {
            _httpServices = commonHttpServices;
            _authService = authService;
            _configuration = configuration;
            _apiBaseUrl = _configuration.GetValue<string>("ApiUrl");
            _webHostEnvironment = webHostEnvironment;
        }

        // ============================================================
        // GET: /Admin/Login
        // This action displays the Login.cshtml page
        // ============================================================
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // ============================================================
        // POST: /Admin/Login
        // This action processes the login form
        // ============================================================
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Invalid Username or Password";
                return View(model);
            }

            try
            {
                // ----------------------------------------------------
                // Login information
                // ----------------------------------------------------
                model.IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "::1";
                model.UserAgent = Request.Headers.UserAgent.ToString();
                model.UserType = "Admin";
                model.LoginFrom = "web";
                model.SessionID = "";

                // ----------------------------------------------------
                // Call Admin Login API
                // ----------------------------------------------------
                var data = await _httpServices.PostAsync<LoginResponse>("api/Admin/AdminLogin", model);

                // ----------------------------------------------------
                // Validate API response
                // ----------------------------------------------------
                if (data == null || data.RegID <= 0)
                {
                    TempData["Error"] =
                        data?.Msg ?? "Login failed.";

                    return View(model);
                }

                if (data.Msg is not ("Success" or "POPSUCCESS"))
                {
                    TempData["Error"] =
                        data.Msg ?? "Invalid Username or Password";

                    return View(model);
                }

                // ----------------------------------------------------
                // Token expiry
                // ----------------------------------------------------
                var fallbackMinutes =
                    _configuration.GetValue<int>(
                        "TokenSettings:AccessTokenLifetimeMinutes",
                        120);

                string expiryUtc;

                if (DateTime.TryParse(
                    data.accessTokenExpiry,
                    null,
                    System.Globalization.DateTimeStyles.RoundtripKind,
                    out var parsedDt))
                {
                    expiryUtc = parsedDt
                        .ToUniversalTime()
                        .ToString("o");
                }
                else
                {
                    expiryUtc = DateTimeOffset.UtcNow
                        .AddMinutes(fallbackMinutes)
                        .ToString("o");
                }

                // ----------------------------------------------------
                // Create Claims
                // ----------------------------------------------------
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, data.Name ?? ""),
                    new Claim("MemberID", data.MemberID ?? ""),
                    new Claim("RegID", data.RegID.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, data.RegID.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim("SessionId", data.sessionId ?? ""),
                    new Claim("UserType", "Admin"),
                    new Claim("AccessToken", data.accessToken ?? ""),
                    new Claim("AccessTokenExpiry", expiryUtc),
                    new Claim("RefreshToken", data.RefreshToken ?? "")
                };

                // ----------------------------------------------------
                // Create Identity
                // IMPORTANT: Must match AdminScheme
                // ----------------------------------------------------
                var identity = new ClaimsIdentity(
                    claims,
                    "AdminScheme");

                var principal = new ClaimsPrincipal(identity);

                // ----------------------------------------------------
                // Sign in using AdminScheme
                // IMPORTANT: Must match Program.cs
                // ----------------------------------------------------
                await HttpContext.SignInAsync(
                    "AdminScheme",
                    principal,
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(2)
                    });

                // ----------------------------------------------------
                // Login successful
                // ----------------------------------------------------
                return RedirectToAction("Dashboard", "Admin", new { area = "Admin" });
            }
            catch (Exception ex)
            {
                TempData["Error"] =
                    $"An error occurred: {ex.Message}";

                return View(model);
            }
        }

        // ============================================================
        // GET: /Admin/Welcome
        // Temporary dashboard/home after successful login
        // ============================================================
        [Authorize(AuthenticationSchemes = "AdminScheme")]
        [HttpGet]
        public IActionResult Welcome()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _authService.SignOutAsync(HttpContext, "AdminScheme");

            return RedirectToAction("Login", "Admin", new { area = "Admin" });
        }
        public async Task<IActionResult> LogoutGet()
        {
            try
            {
                await _authService.SignOutAsync(HttpContext, "AdminScheme");
            }
            catch { }
            return Ok();   // return Ok not Redirect — fetch doesn't follow redirects
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult CreditCardPercentage()
        {
            var regIdString = User.FindFirst("RegID")?.Value;

            // Safely convert string to int
            int regId = 0;
            if (!string.IsNullOrEmpty(regIdString))
            {
                int.TryParse(regIdString, out regId);
            }

            if (regId > 0)
            {
                return View();
            }

            return RedirectToAction("Login");
        }
        public IActionResult Customers()
        {
            var regIdString = User.FindFirst("RegID")?.Value;

            // Safely convert string to int
            int regId = 0;
            if (!string.IsNullOrEmpty(regIdString))
            {
                int.TryParse(regIdString, out regId);
            }

            if (regId > 0)
            {
                return View();
            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> GetCustomers()
        {
            string token = User.FindFirst("AccessToken")?.Value ?? string.Empty;
            var payload = new { };
            StringContent content = new StringContent(
                JsonConvert.SerializeObject(payload),
                Encoding.UTF8,
                "application/json"
            );

            using (var httpClient = HttpClientHelper.GetHttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                string endpoint = _apiBaseUrl + "/api/Admin/GetCustomers";
                HttpResponseMessage response = await httpClient.PostAsync(endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var reportData = JsonConvert.DeserializeObject<List<GetCustomers_OP>>(apiResponse);

                    return ViewComponent("Customers", new { customers = reportData });
                }

                return Content("No Data Found");
            }
        }
        [HttpPost]
        public async Task<IActionResult> InsertAndUpdateCustomerDetails(
        [FromForm] CustomerMaster_IP obj,
        [FromForm] IFormFile AadhaarImage,
        [FromForm] IFormFile PanImage,
        [FromForm] string OldAadhaarPath,
        [FromForm] string OldPanPath)
        {
            string token = User.FindFirst("AccessToken")?.Value ?? string.Empty;
            string webRootPath = _webHostEnvironment.WebRootPath;

            // Aadhaar upload
            if (AadhaarImage != null && AadhaarImage.Length > 0)
            {
                string filename = AadhaarImage.FileName.Replace(' ', '-');
                string path = Path.Combine(webRootPath, "uploads", "aadhaar");
                Directory.CreateDirectory(path);

                string newFileName = $"{DateTime.Now:yyyyMMddHHmmssfff}_{filename}";
                string filePath = Path.Combine(path, newFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await AadhaarImage.CopyToAsync(stream);
                }

                obj.AadhaarImagePath = "/uploads/aadhaar/" + newFileName;
            }
            else if (!string.IsNullOrEmpty(OldAadhaarPath))
            {
                obj.AadhaarImagePath = OldAadhaarPath;
            }

            // PAN upload
            if (PanImage != null && PanImage.Length > 0)
            {
                string filename = PanImage.FileName.Replace(' ', '-');
                string path = Path.Combine(webRootPath, "uploads", "pan");
                Directory.CreateDirectory(path);

                string newFileName = $"{DateTime.Now:yyyyMMddHHmmssfff}_{filename}";
                string filePath = Path.Combine(path, newFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await PanImage.CopyToAsync(stream);
                }

                obj.PANImagePath = "/uploads/pan/" + newFileName;
            }
            else if (!string.IsNullOrEmpty(OldPanPath))
            {
                obj.PANImagePath = OldPanPath;
            }

            obj.CreatedBy = 1;
            if (obj.PANNumber == null) { obj.PANNumber = ""; }
            if (obj.AadhaarNumber == null) { obj.AadhaarNumber = ""; }
            if (obj.AadhaarImage == null) { obj.AadhaarImage = ""; }
            if (obj.PanImage == null) { obj.PanImage = ""; }
            obj.CustomerName = obj.CustomerName ?? string.Empty;
            obj.Email = obj.Email ?? string.Empty;
            obj.MobileNumber = obj.MobileNumber ?? string.Empty;
            obj.IPAddress = "";
            obj.SessionID = "";

            using (var httpClient = HttpClientHelper.GetHttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                string endpoint = _apiBaseUrl + "/api/Admin/InsertAndUpdateCustomerDetails";
                var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<Result>>(apiResponse);
                    return Json(new { success = true, message = "Customer saved successfully", data = result });
                }
                else
                {
                    return Json(new { success = false, message = "Failed to save customer" });
                }
            }
        }

    }

}



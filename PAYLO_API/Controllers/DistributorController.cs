using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using PAYLO_Classes;
using PAYLO_Classes.Admin;
using PAYLO_Classes.Associate;
using PAYLO_Classes.GlobalDB;
using PAYLO_Dal;
using PAYLO_API.Filters;
using PAYLO_API.Services;
using PAYLO_API.Services.GlobalException;
using PAYLO_API.Models;

namespace VedalexNepalAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DistributorController : AppControllerBase
    {
        private const string UserType = "Associate";
        //private const string RefreshCookie = "rt_Admin";   // HttpOnly cookie name
        private const string CookiePrefix = "rt_Associate_";
        private const string SessionIdHeader = "X-Session-Id";
       
        private readonly ITokenService _tokenService;

        public DistributorController(
             IConfiguration configuration,
             IErrorLoggerService errorLogger,
             IWebHostEnvironment hostEnvironment,
             ITokenService tokenService)
             : base(configuration, errorLogger, hostEnvironment)
        {
            _tokenService = tokenService
                ?? throw new ArgumentNullException(nameof(tokenService));

        }

        //POST api/Distributor/VerifyDistributorLogin 
        [AllowAnonymous]
        [HttpPost("VerifyDistributorLogin")]
        public async Task<IActionResult>  VerifyDistributorLogin([FromBody] AssociateLoginIP model)
        {
            try
            {
                string result = PAYLODAL.Instance.DistributorService.VerifyDistributorLogin(NapalConEnvironment, model);

                var details = JsonConvert.DeserializeObject<LoginResponse>(result);

                if (details == null)
                    return Unauthorized(new { StatusCode = 401, Message = "Distributor not found." });
                

                if (details.Msg is not ("SUCCESS" or "POPSUCCESS"))
                {
                    return Ok(new
                    {
                        details.RegID,
                        details.MemberID,
                        details.Name,
                        details.Msg,
                        details.accessToken,
                        details.accessTokenExpiry,
                        details.sessionId,
                    });
                }

                var ip = IpAddress.ToString();
                var ua = UserAgent.ToString();
                var tokenPair = await _tokenService.IssueTokenPairAsync(
                   details.MemberID, details.RegID, details.Name!, UserType, ip, ua);

                if (string.IsNullOrEmpty(tokenPair.RawRefreshToken))
                    return Unauthorized(new { StatusCode = 401, Message = "Not logged in Try again." });
                //if (!string.IsNullOrEmpty(tokenPair.RawRefreshToken))
                //    SetRefreshTokenCookie(tokenPair.MultiSessionId, tokenPair.RawRefreshToken, tokenPair.RefreshTokenExpiry);

                details.accessToken = tokenPair.AccessToken;
                details.accessTokenExpiry = tokenPair.AccessTokenExpiry?.ToString("o") ?? "";
                details.sessionId = tokenPair.MultiSessionId;
                details.RefreshToken = tokenPair.RawRefreshToken;
                details.RefreshTokenExpiry = tokenPair.RefreshTokenExpiry.ToString("o") ?? "";
                return Ok(details);
            }
            catch (Exception ex)
            {
                return StatusCode(404, new { ex.Message });
            }
        }
        private void SetRefreshTokenCookie(string sessionId, string rawToken, DateTime expires)
        {
            Response.Cookies.Append(CookiePrefix + sessionId, rawToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax,
                Expires = new DateTimeOffset(expires, TimeSpan.Zero), // explicit UTC offset
                Path = "/api/Distributor"
            });
        }
        private (string? sessionId, string? rawToken) ReadRefreshCookie()
        {
            // Priority 1: X-Session-Id header (real UI — React/Angular/Mobile)
            var headerSessionId = Request.Headers[SessionIdHeader].ToString();
            if (!string.IsNullOrEmpty(headerSessionId))
            {
                var cookieName = CookiePrefix + headerSessionId;
                var rawToken = Request.Cookies[cookieName];
                if (!string.IsNullOrEmpty(rawToken))
                    return (headerSessionId, rawToken);
            }

            // Priority 2: Scan cookie names — fallback for Scalar/Swagger testing
            // Safe ONLY when one user is logged in (single cookie present)
            // In production real UI always sends X-Session-Id header
            var matches = Request.Cookies
                .Where(c => c.Key.StartsWith(CookiePrefix, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (matches.Count == 1)
            {
                // Only one session cookie present — safe to use
                var sessionId = matches[0].Key[CookiePrefix.Length..];
                return (sessionId, matches[0].Value);
            }

            if (matches.Count > 1)
            {
                // Multiple session cookies — cannot determine which user without header
                // Log warning: multi-user detected but no X-Session-Id header provided
                return (null, null);
            }

            return (null, null);
        }

        // API CommonController or DistributorController
        [HttpPost("GetLinks")]
        public IActionResult GetLinks([FromBody] LinksParam obj)
        {
            try
            {
                //obj.UserType = User.FindFirst("UserType")?.Value ?? "";
                //obj.RegID = int.Parse(User.FindFirst("RegID")?.Value ?? "0");

                var result = PAYLODAL.Instance.CommonService
                                 .GetLinks(NapalConEnvironment, obj);

                // Always return array — never return null (causes object deserialization error)
                return Ok(result ?? new List<LinksOutput>());
            }
            catch (Exception ex)
            {
                // Return empty array on error — not error object
                // Returning StatusCode(400, ex.Message) returns a string, not an array
                // UI tries to deserialize string as List<LinksOutput> → crash
                return Ok(new List<LinksOutput>());   // safe fallback
            }
        }
        //ResumeSession endpoint for Duplicate Tab
        [AllowAnonymous]
        [HttpPost("ResumeSession")]
        public async Task<IActionResult> ResumeSession()
        {
            try
            {
                var (sessionId, _) = ReadRefreshCookie();
                if (string.IsNullOrEmpty(sessionId))
                    return Unauthorized(new { Message = "No session cookie found." });
                var tokenPair = await _tokenService.ResumeSessionAsync(sessionId, UserType);
                if (tokenPair == null)
                {
                    DeleteRefreshCookie(sessionId);
                    return Unauthorized(new { Message = "Session expired. Please log in again." });
                }
                return Ok(new
                {
                    AccessToken = tokenPair.AccessToken,
                    AccessTokenExpiry = tokenPair.AccessTokenExpiry,
                    MultiSessionId = tokenPair.MultiSessionId,
                    RefreshTokenExpiry = tokenPair.RefreshTokenExpiry
                });
            }
            catch (Exception ex) { return StatusCode(400, new { ex.Message }); }
        }
        private void DeleteRefreshCookie(string sessionId)
        {
            Response.Cookies.Delete(CookiePrefix + sessionId,
                new CookieOptions { Path = "/api/Associate" });
        }
        // ── POST api/Admin/RefreshToken ───────────────────────────────────────
        [AllowAnonymous]
        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(
            [FromBody] RefreshTokenRequest request)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "";
            var ua = Request.Headers.UserAgent.ToString();
            var tokenPair = await _tokenService.RotateRefreshTokenAsync(
                request.RawRefreshToken, UserType, ip, ua);

            if (tokenPair == null)
                return Unauthorized(new { Message = "Session expired." });

            // Exact same field names and format as Login response
            return Ok(new
            {
                accessToken = tokenPair.AccessToken,
                accessTokenExpiry = tokenPair.AccessTokenExpiry?.ToString("o") ?? "",  // ISO "o" string
                sessionId = tokenPair.MultiSessionId,                   //  include sessionId
                refreshToken = tokenPair.RawRefreshToken,
                refreshTokenExpiry = tokenPair.RefreshTokenExpiry.ToString("o")  // ISO "o" string
            });
        }
        // ── POST api/Distributor/RefreshToken ─────────────────────────────────
        [HttpPost("RefreshTokenWithSession")]
        public IActionResult RefreshTokenWithSession()
        {
            try
            {
                var tokenString = HttpContext.Session.GetString("JwtToken_Distributor");
                if (string.IsNullOrEmpty(tokenString))
                    return BadRequest(new { Message = "No active session found." });

                var handler = new JwtSecurityTokenHandler();
                var oldToken = handler.ReadToken(tokenString) as JwtSecurityToken;
                if (oldToken == null)
                    return BadRequest(new { Message = "Invalid session token." });

                var expiresAt = oldToken.ValidTo.ToLocalTime();
                var refreshAt = expiresAt - TimeSpan.FromMinutes(2);
                var now = DateTime.Now;

                if (now < refreshAt)
                {
                    var existing = HttpContext.Session.GetString("RefreshToken_Distributor");
                    return Ok(new { RefreshToken = existing, Token = tokenString });
                }

                // Issue new token — key from config, NOT hardcoded 
                string jwtKey = Configuration.GetValue<string>("JWTTokenGenKey:VedalexNepal")!;
                byte[] keyBytes = Encoding.UTF8.GetBytes(jwtKey);   // UTF-8

                var newJwt = new JwtSecurityToken(
                    issuer: oldToken.Issuer,
                    audience: oldToken.Audiences.FirstOrDefault(),
                    claims: oldToken.Claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(keyBytes),
                        SecurityAlgorithms.HmacSha256));

                string newTokenString = handler.WriteToken(newJwt);
                string newRefreshToken = Guid.NewGuid().ToString();

                HttpContext.Session.SetString("JwtToken_Distributor", newTokenString);
                HttpContext.Session.SetString("RefreshToken_Distributor", newRefreshToken);
                HttpContext.Session.SetString("JwtTokenExpiration_Distributor",DateTime.UtcNow.AddHours(1).ToString("o"));

                return Ok(new { RefreshToken = newRefreshToken, Token = newTokenString });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { ex.Message });
            }
        }

        [HttpPost]
        [Route("MemberDashboard")]
        public IActionResult MemberDashboard(MemberDashboard_IP obj)
        {
            try
            {
                string response = PAYLODAL.Instance.DistributorService.MemberDashboard(NapalConEnvironment, obj);

                if (string.IsNullOrEmpty(response))
                {
                    return BadRequest("No Data Found");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Signup")]
        [ApiKeyAuth(typeof(RegistrationResponse))]
        public IActionResult Signup(SignupIP obj)
        {
            try
            {
                string result = PAYLODAL.Instance.DistributorService.Signup(NapalConEnvironment, obj);
                if (result == null)
                {
                    return NotFound();

                }
                return JsonContent(result);

            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("PincodeCheck")]
        [ApiKeyAuth(typeof(RegistrationResponse))]
        public IActionResult PincodeCheck(PincodeCheckIP obj)
        {
            try
            {
                string result = PAYLODAL.Instance.DistributorService.PincodeCheck(NapalConEnvironment, obj);
                if (result == null)
                {
                    return NotFound();

                }
                return JsonContent(result);

            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("CheckUserInfo")]
        [ApiKeyAuth(typeof(CheckUserAailableResponse))]
        public IActionResult CheckUserInfo(CheckUserInfo_IP obj)
        {
            try
            {
                string result = PAYLODAL.Instance.DistributorService.CheckUserInfo(NapalConEnvironment, obj);
                if (result == null)
                {
                    return NotFound();

                }
                return JsonContent(result);

            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("SendOTP")]
        [ApiKeyAuth(typeof(SendOTPResponse))]
        public IActionResult SendOTP(SendOTP_IP obj)
        {
            try
            {
                string result = PAYLODAL.Instance.DistributorService.SendOTP(NapalConEnvironment, obj);
                if (result == null)
                {
                    return NotFound();

                }
                return JsonContent(result);

            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        

        // DistributorController API — Logout
        [AllowAnonymous]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            var result = await _tokenService.LogoutAsync(
                request.RawRefreshToken, UserType, request.RawJwt);

            return result.Success
                ? Ok(new { result.Message })
                : Unauthorized(new { result.Message });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("MemberProfile")]
        public IActionResult MemberProfile(MemberProfile_IP encInfo)
        {
            try
            {

                List<MemberProfile_OutPut> _adminUsers = PAYLODAL.Instance.DistributorService.MemberProfile(NapalConEnvironment, encInfo);
                if (_adminUsers == null)
                {
                    var _errorDetails = new ErrorDetails(201, "SS", "Invalid credentials");

                }

                return Ok(_adminUsers);
            }
            catch (Exception ex)
            {

                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost]
        [Route("GetCitizenshipStatus")]
        public IActionResult GetCitizenshipStatus(NepaliCitizenship_IP obj)
        {
            try
            {
                string response = PAYLODAL.Instance.DistributorService.GetCitizenshipStatus(NapalConEnvironment,obj);
                if (response == null)
                {
                    var _errorDetails = new ErrorDetails(201, "SS", "Invalid credentials");

                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost]
        [Route("UploadCitizenshipRequest")]
        public IActionResult UploadCitizenshipRequest(NepaliCitizenship_IP obj)
        {
            try
            {
                string response =PAYLODAL.Instance.DistributorService.UploadCitizenshipRequest(NapalConEnvironment,obj);

                if (response == null)
                {
                    var _errorDetails = new ErrorDetails(201, "SS", "Invalid credentials");

                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost]
        [Route("UploadBankDetails")]
        public IActionResult UploadBankDetails([FromBody] BankDetails_IP obj)
        {
            try
            {
                string response = PAYLODAL.Instance.DistributorService.UploadBankDetails(NapalConEnvironment, obj);

                if (response == null)
                {
                    var _errorDetails = new ErrorDetails(201, "SS", "Invalid credentials");

                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("UploadPANDetails")]
        public IActionResult UploadPANDetails([FromBody] PANDetails_IP obj)
        {
            try
            {
                string response = PAYLODAL.Instance.DistributorService.UploadPANDetails(NapalConEnvironment, obj);

                if (response == null)
                {
                    var _errorDetails = new ErrorDetails(201, "SS", "Invalid credentials");

                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("UploadMemberPhoto")]
        public IActionResult UploadMemberPhoto([FromBody] MemberPhoto_IP obj)
        {
            try
            {
                string response = PAYLODAL.Instance.DistributorService.UploadMemberPhoto(NapalConEnvironment,obj);

                if (response == null)
                {
                    var _errorDetails = new ErrorDetails(201,"SS","Invalid credentials");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(ForgotPassword_IP obj)
        {
            try
            {
                string result = PAYLODAL.Instance.DistributorService.ForgotPassword(NapalConEnvironment, obj);
                if (result == null)
                {
                    return NotFound();

                }
                return JsonContent(result);

            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PAYLO_API.Models;
using PAYLO_API.Services;
using PAYLO_API.Services.GlobalException;
using PAYLO_Classes;
using PAYLO_Classes.Admin;
using PAYLO_Classes.Associate;
using PAYLO_Classes.Common;
using PAYLO_Classes.Franchise;
using PAYLO_Classes.GlobalDB;
using PAYLO_Classes.Opensite;
using PAYLO_Dal;

namespace VedalexNepalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : AppControllerBase
    {
        private const string UserType = "Admin";
        //private const string RefreshCookie = "rt_Admin";   // HttpOnly cookie name
        private const string CookiePrefix = "rt_Admin_";
        private const string SessionIdHeader = "X-Session-Id";
        private readonly string _conEnv;
        private readonly ITokenService _tokenService;

        public AdminController(
             IConfiguration configuration,
             IErrorLoggerService errorLogger,
             IWebHostEnvironment hostEnvironment,
             ITokenService tokenService)
             : base(configuration, errorLogger, hostEnvironment)
        {
            _tokenService = tokenService
                ?? throw new ArgumentNullException(nameof(tokenService));

        }



        // ── POST api/Associate/VerifyDistributorLogin ───────────────────────
        [AllowAnonymous]
        [HttpPost("AdminLogin")]
        public async Task<IActionResult> VerifyDistributorLogin([FromBody] AssociateLogin model)
        {
            try
            {
                model.IPAddress = IpAddress;
                model.userAgent = UserAgent;
                string raw = PAYLODAL.Instance.AdminService .AssociateLogin(NapalConEnvironment, model);
                var details = JsonConvert.DeserializeObject<LoginResponse>(raw);

                if (string.IsNullOrEmpty(details.ToString()))
                    return Unauthorized(new { StatusCode = 401, Message = "Not logged in Try again." });


                if (details.Msg is not ("Success" or "POPSUCCESS"))
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
                        details.RefreshToken,
                        details.RefreshTokenExpiry
                    });
                }


                //  Issue token pair
                var ip = IpAddress.ToString();
                var ua = UserAgent.ToString();
                var tokenPair = await _tokenService.IssueTokenPairAsync(
                   details.MemberID, details.RegID, details.Name!, UserType, ip, ua);

                // Only set cookie if this is a fresh session (new login, not existing tab)
                //if (!string.IsNullOrEmpty(tokenPair.RawRefreshToken))
                //    SetRefreshTokenCookie(tokenPair.MultiSessionId, tokenPair.RawRefreshToken, tokenPair.RefreshTokenExpiry);

                details.accessToken = tokenPair.AccessToken;
                details.accessTokenExpiry = tokenPair.AccessTokenExpiry?.ToString("o") ?? "";
                details.sessionId = tokenPair.MultiSessionId;
                details.RefreshToken = tokenPair.RawRefreshToken;
                details.RefreshTokenExpiry = tokenPair.RefreshTokenExpiry.ToString("o") ?? "";
                // ── Access token → JSON body (stored in JS memory, NOT localStorage) ─
                return Ok(details);
            }
            catch (Exception ex)
            {
                return StatusCode(400, new { ex.Message });
            }
        }

        

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
                return Unauthorized(new { StatusCode = 401, Message = "Session expired." });

            //  Exact same field names and format as Login response
            return Ok(new
            {
                accessToken = tokenPair.AccessToken,
                accessTokenExpiry = tokenPair.AccessTokenExpiry?.ToString("o") ?? "",  // ISO "o" string
                sessionId = tokenPair.MultiSessionId,                   // include sessionId
                refreshToken = tokenPair.RawRefreshToken,
                refreshTokenExpiry = tokenPair.RefreshTokenExpiry.ToString("o")  // ISO "o" string
            });
        }
        // DistributorController API — Logout
        //[AllowAnonymous]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            var result = await _tokenService.LogoutAsync(
                request.RawRefreshToken, UserType, request.RawJwt);

            return result.Success
                ? Ok(new { result.Message })
                : Unauthorized(new { StatusCode = 401, result.Message });
        }

        #region Revoke
        // CommonController (API)
        [AllowAnonymous]
        [HttpPost("SoftRevoke")]
        public IActionResult SoftRevoke([FromBody] SessionRef r)
        {
            if (r == null
             || string.IsNullOrWhiteSpace(r.MultiSessionId)
             || string.IsNullOrWhiteSpace(r.UserType))
                return Ok(new { success = false });   // nothing to revoke, no error

            // ✅ DAL returns rows affected (count of sessions marked pending)
            int affected = PAYLODAL.Instance.CommonService
                               .SoftRevoke(NapalConEnvironment, r);

            return Ok(new { success = true, affected });
        }

        [AllowAnonymous]
        [HttpPost("CancelSoftRevoke")]
        public IActionResult CancelSoftRevoke([FromBody] SessionRef r)
        {
            if (r == null
             || string.IsNullOrWhiteSpace(r.MultiSessionId)
             || string.IsNullOrWhiteSpace(r.UserType))
                return Ok(new { success = false });

            int affected = PAYLODAL.Instance.CommonService
                               .CancelSoftRevoke(NapalConEnvironment, r);

            return Ok(new { success = true, affected });
        }
        #endregion
        // ── POST api/Associate/RevokeAllSessions ────────────────────────────
        // Use after password change or account compromise
        [HttpPost("RevokeAllSessions")]
        public async Task<IActionResult> RevokeAllSessions()
        {
            var regIdClaim = User.FindFirst("RegID")?.Value;
            var IdNoClaim = User.FindFirst("IdNo")?.Value;
            var sessionId = User.FindFirst("MultiSessionId")?.Value;

            if (string.IsNullOrEmpty(regIdClaim))
                return Unauthorized(new { StatusCode = 401, Message = "All sessions not revoked." });

            await _tokenService.RevokeAllUserTokensAsync(IdNoClaim.ToString(), int.Parse(regIdClaim), UserType);
            DeleteRefreshCookie(sessionId);

            return Ok(new { Message = "All sessions revoked." });
        }

        // Cookie helpers 
        // ── Cookie helpers — sessionId in cookie name ─────────────────────────────
        private void SetRefreshTokenCookie(string sessionId, string rawToken, DateTime expires)
        {
            Response.Cookies.Append(CookiePrefix + sessionId, rawToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax,
                Expires = new DateTimeOffset(expires, TimeSpan.Zero), // explicit UTC offset
                Path = "/api/Admin"
            });
        }

        private void DeleteRefreshCookie(string sessionId)
        {
            Response.Cookies.Delete(CookiePrefix + sessionId,
                new CookieOptions { Path = "/api/Admin" });
        }
        // ── Helper: scan cookies for prefix → return (sessionId, rawToken) ────────
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

        //ResumeSession endpoint for Duplicate Tab
        [AllowAnonymous]
        [HttpPost("ResumeSession")]
        public async Task<IActionResult> ResumeSession()
        {
            try
            {
                var (sessionId, _) = ReadRefreshCookie();
                if (string.IsNullOrEmpty(sessionId))
                    return Unauthorized(new { StatusCode = 401, Message = "No session cookie found." });
                var tokenPair = await _tokenService.ResumeSessionAsync(sessionId, UserType);
                if (tokenPair == null)
                {
                    DeleteRefreshCookie(sessionId);
                    return Unauthorized(new { StatusCode = 401, Message = "Session expired. Please log in again." });
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

        [HttpPost("CreateOrUpdateUser")]
        public IActionResult CreateOrUpdateUser(UserCreation_IP encInfo)
        {
            try
            {

                List<CommonMessage> _response = PAYLODAL.Instance.AdminService.CreateOrUpdateUser(NapalConEnvironment, encInfo, IpAddress);
                if (_response == null)
                {
                    var _errorDetails = new ErrorDetails(201, "SS", "Invalid credentials");

                }
                return Ok(_response);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        [HttpPost("UsersReport")]
        public IActionResult UsersReport(UserReport_IP encInfo)
        {
            try
            {
                List<UserReport_OutPut> _response = PAYLODAL.Instance.AdminService.UsersReport(NapalConEnvironment, encInfo);
                if (_response == null)
                {
                    var _errorDetails = new ErrorDetails(201, "SS", "Invalid credentials");

                }
                return Ok(_response);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        [HttpPost("LinksPremission")]
        public IActionResult LinksPremission(LinksPremissionIP encInfo)
        {
            try
            {
                string _response = PAYLODAL.Instance.AdminService.LinksPremission(NapalConEnvironment, encInfo);
                if (_response == null)
                {
                    var _errorDetails = new ErrorDetails(201, "SS", "Invalid credentials");

                }
                return Ok(_response);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        [HttpPost("UpdateLinksPremission")]
        public IActionResult UpdateLinksPremission(UpdateLinksPremissionIP encInfo)
        {
            try
            {
                List<Result> _response = PAYLODAL.Instance.AdminService.UpdateLinksPremission(NapalConEnvironment, encInfo);
                if (_response == null)
                {
                    var _errorDetails = new ErrorDetails(201, "SS", "Invalid credentials");

                }
                return Ok(_response);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        [HttpPost]
        [Route("GetLinks")]
        public IActionResult GetLinks(LinksParam obj)
        {
            try
            {

                List<LinksOutput> _adminUsers = PAYLODAL.Instance.CommonService.GetLinks(NapalConEnvironment, obj);
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

        //--------------------MY NEW API FOR PAYLO--------------------
        [HttpPost("GetCustomers")]
        public IActionResult GetCustomers()
        {
            try
            {
                List<GetCustomers_OP> _response = PAYLODAL.Instance.AdminService.GetCustomers(NapalConEnvironment);
                if (_response == null)
                {
                    var _errorDetails = new ErrorDetails(201, "SS", "Invalid credentials");

                }
                return Ok(_response);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        [HttpPost("InsertAndUpdateCustomerDetails")]
        public IActionResult InsertAndUpdateCustomerDetails([FromBody] CustomerMaster_IP obj)
        {
            try
            {
                obj.IPAddress = IpAddress;
                List<Result> _adminUsers = PAYLODAL.Instance.AdminService.InsertAndUpdateCustomerDetails(NapalConEnvironment, obj);

                if (_adminUsers == null)
                {
                    return Unauthorized(new ErrorDetails(201, "SS", "Invalid credentials"));
                }

                return Ok(_adminUsers);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}

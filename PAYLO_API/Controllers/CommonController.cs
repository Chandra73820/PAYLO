using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PAYLO_API.Models;
using PAYLO_API.Models.Cache;
using PAYLO_API.Services;
using PAYLO_API.Services.GlobalException;
using PAYLO_Classes;
using PAYLO_Classes.Common;
using PAYLO_Classes.GlobalDB;
using PAYLO_Dal;



namespace VedalexNepalAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : AppControllerBase
    {
        public string? ConEnvironment { get; set; }

        public bool IsRedisCacheEnable { get; set; }

        public IWebHostEnvironment _env;

        public string? newTokenString;

        private readonly ITokenService _tokenService;

        private readonly ICacheService _cacheService;

        public CommonController(
              IConfiguration configuration,
              IErrorLoggerService errorLogger,
              IWebHostEnvironment hostEnvironment,
              ITokenService tokenService)
              : base(configuration, errorLogger, hostEnvironment)
        {
            _tokenService = tokenService
                ?? throw new ArgumentNullException(nameof(tokenService));

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("GetDropDown")]
        public IActionResult GetDropDown(GetDropDown_IP encInfo)
        {
            try
            {
                List<DropDownDetails_OP> result = PAYLODAL.Instance.CommonService.GetDropDown(NapalConEnvironment, encInfo);
                if (result == null)
                {
                    var _errorDetails = new ErrorDetails(201, "SS", "Invalid credentials");

                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("GetDropDownText")]
        public IActionResult GetDropDownText(GetDropDown_IP encInfo)
        {
            try
            {
               string result = PAYLODAL.Instance.CommonService.GetDropDownText(NapalConEnvironment, encInfo);

                if (result == null)
                {
                    var _errorDetails = new ErrorDetails(201, "SS", "Invalid credentials");

                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("CheckUserID")]
        public IActionResult CheckUserID(CheckUserID_IP encInfo)
        {
            try
            {
                List<CheckUserID_OutPut> result = PAYLODAL.Instance.CommonService.CheckUserID(NapalConEnvironment, encInfo);
                if (result == null)
                {
                    var _errorDetails = new ErrorDetails(201, "SS", "Invalid credentials");

                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("MemberAddress")]
        public IActionResult MemberAddress(MemberAddress_IP obj)
        {
            try
            {
                string response = PAYLODAL.Instance.CommonService.MemberAddress(NapalConEnvironment, obj);

                if (response == null)
                {
                    var errorDetails = new ErrorDetails(201, "SS", "Invalid credentials");
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
        [Route("GetReceipt")]
        public IActionResult GetReceipt(GetReceiptIP obj)
        {
            try
            {
                string response = PAYLODAL.Instance.CommonService.GetReceipt(NapalConEnvironment, obj);

                if (response == null)
                {
                    var errorDetails = new ErrorDetails(201, "SS", "Invalid credentials");
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
        [Route("UserIDChangeFromIndia")]
        public IActionResult UserIDChangeFromIndia(UserIDChangeFromIndia_IP obj)
        {
            try
            {
                string response = PAYLODAL.Instance.CommonService.UserIDChangeFromIndia(NapalConEnvironment, obj);

                if (string.IsNullOrWhiteSpace(response))
                {
                    var errorDetails = new ErrorDetails(201, "SS", "No Data Found");

                    return BadRequest(errorDetails);
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PAYLO_API.Models;
using PAYLO_API.Services;
using PAYLO_API.Services.GlobalException;
using PAYLO_Classes.Admin;
using PAYLO_Classes.Opensite;
using PAYLO_Dal;

namespace VedalexNepalAPI.Controllers
{

    public class OpenController : AppControllerBase
    {
        public OpenController(
              IConfiguration configuration,
              IErrorLoggerService errorLogger,
              IWebHostEnvironment hostEnvironment,
              ITokenService tokenService)
              : base(configuration, errorLogger, hostEnvironment)
        {
          

        }
        [HttpPost]
        [Route("ProductDetails")]
        public IActionResult ProductDetails(OpenProductDetailsIP obj)
        {
            try
            {
                string response = PAYLODAL.Instance.OpenService.ProductDetails(NapalConEnvironment, obj);
                if (response == null)
                {
                    var _errorDetails = new ErrorDetails(201, "SS", "Invalid credentials");

                }
                return JsonContent(response);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        [HttpPost]
        [Route("ContactUs")]
        public IActionResult ContactUs(ContactUs_IP obj)
        {
            try
            {
                obj.IPAddress = IpAddress;

                string response = PAYLODAL.Instance.OpenService.ContactUs(NapalConEnvironment, obj);
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
        [HttpPost]
        [Route("TestimonialDetails")]
        public IActionResult TestimonialDetails(Open_Testimonials_IP obj)
        {
            try
            {
                string response = PAYLODAL.Instance.OpenService.TestimonialDetails(NapalConEnvironment, obj);
                if (response == null)
                {
                    var _errorDetails = new ErrorDetails(201, "SS", "Invalid credentials");

                }
                return JsonContent(response);
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}

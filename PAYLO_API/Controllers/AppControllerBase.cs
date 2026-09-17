using Microsoft.AspNetCore.Mvc;
using PAYLO_API.Services.GlobalException;

namespace VedalexNepalAPI.Controllers
{
    /// <summary>
    /// Base controller — every controller in the solution should inherit from this.
    /// Provides shared error logging, environment config, and helper methods.
    /// </summary>
    [ApiController]
    public abstract class AppControllerBase : ControllerBase
    {
        protected readonly IConfiguration Configuration;
        public IWebHostEnvironment _env;
        protected readonly IErrorLoggerService ErrorLogger;
        protected readonly string _GBLConEnvironment;
        protected readonly string _XAPIKey;
        protected readonly string _XAPIKeyHeaderName;
        protected readonly string _NapalConEnvironment;
        protected readonly string _XCorrelationIdHeaderName;
        protected readonly string JsonContentType;
       // protected string IpAddress;
        protected AppControllerBase(IConfiguration configuration, IErrorLoggerService errorLogger,
            IWebHostEnvironment env)
        {
            Configuration = configuration;
            ErrorLogger = errorLogger;
            _env = env;
            _NapalConEnvironment = configuration.GetValue<string>("Environment");
            _GBLConEnvironment = configuration.GetValue<string>("GBLEnvironment");
            _XAPIKey = configuration?.GetValue<string>("ApiSettings:GlobalApiKey") ?? "GBL-SEC-2026-VEDALEX";
            _XAPIKeyHeaderName = configuration?.GetValue<string>("ApiSettings:ApiKeyHeaderName") ?? "X-API-Key";
            _XCorrelationIdHeaderName = configuration?.GetValue<string>("ApiSettings:XCorrelationIdHeaderName") ?? "X-Correlation-Id";
            JsonContentType = configuration?.GetValue<string>("JsonContentType") ?? "application/json";
           // IpAddress = GetClientIp();
        }

        protected string NapalConEnvironment => _NapalConEnvironment;
        protected string GBLConEnvironment => _GBLConEnvironment;
        protected string XAPIKey => _XAPIKey;
        protected string XAPIKeyHeaderName => _XAPIKeyHeaderName;
        /// <summary>Get the correlation ID for this request.</summary>
        protected string CorrelationId => HttpContext.Items[_XCorrelationIdHeaderName]?.ToString() ?? "";
        

        /// <summary>Return a JSON content response (use when SP already produces JSON).</summary>
        protected ContentResult JsonContent(string json) => Content(json ?? "{}", JsonContentType);

        protected string IpAddress => HttpContext.Connection.RemoteIpAddress?.ToString() ?? "";
       

        protected string UserAgent => Request.Headers.UserAgent.ToString();

        /// <summary>Log an authentication failure with HTTP context.</summary>
        protected void LogAuthFailure(string reason) => ErrorLogger?.LogAuthFailure(HttpContext, reason);

        /// <summary>Log an exception with HTTP context.</summary>
        protected void LogException(Exception ex, int? statusCode = null)=> ErrorLogger?.LogException(HttpContext, ex, statusCode);

        /// <summary>Log any custom message (validation, business event).</summary>
        protected void LogMessage(string type, string message, int? statusCode = null) => ErrorLogger?.LogMessage(HttpContext, type, message, statusCode);

        // In AdminController, AssociateController login actions:
        //private string GetClientIp()
        //{
        //    //  Cloudflare passes real IP in CF-Connecting-IP header
        //    var cfIp = HttpContext.Request.Headers["CF-Connecting-IP"]
        //                   .FirstOrDefault();
        //    if (!string.IsNullOrEmpty(cfIp)) return cfIp;

        //    //  Standard reverse proxy header
        //    var forwardedFor = HttpContext.Request.Headers["X-Forwarded-For"]
        //                           .FirstOrDefault();
        //    if (!string.IsNullOrEmpty(forwardedFor))
        //        return forwardedFor.Split(',')[0].Trim();  // first IP in chain

        //    // Direct connection fallback
        //    return HttpContext.Connection.RemoteIpAddress?.ToString() ?? "";
        //}

        // Use in Login and RefreshToken:
        
    }
}
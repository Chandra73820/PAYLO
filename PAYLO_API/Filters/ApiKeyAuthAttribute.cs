using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using PAYLO_Classes.Common;

namespace PAYLO_API.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {

        private readonly Type _errorResponseType;

        public ApiKeyAuthAttribute(Type errorResponseType = null)
        {
            if (errorResponseType != null &&
                !typeof(IApiErrorResponse).IsAssignableFrom(errorResponseType))
            {
                throw new ArgumentException(
                    $"{errorResponseType.Name} must implement IApiErrorResponse");
            }
            _errorResponseType = errorResponseType;
        }

        public async Task OnActionExecutionAsync(
            ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var configuration = context.HttpContext.RequestServices
                .GetService(typeof(IConfiguration)) as IConfiguration;

            string headerName = configuration?.GetValue<string>("ApiSettings:ApiKeyHeaderName") ?? "X-API-Key";
            string configuredKey = configuration?.GetValue<string>("ApiSettings:GlobalApiKey");
            string providedKey = context.HttpContext.Request.Headers[headerName].ToString();

            if (string.IsNullOrEmpty(providedKey))
            {
                context.Result = BuildErrorResult("API Key header is missing");
                return;
            }

            if (!string.Equals(providedKey, configuredKey, StringComparison.Ordinal))
            {
                context.Result = BuildErrorResult("Unauthorized - Invalid API Key");
                return;
            }

            await next();
        }

        private ContentResult BuildErrorResult(string message)
        {
            object responseObj;

            if (_errorResponseType != null)
            {
                var instance = (IApiErrorResponse)Activator.CreateInstance(_errorResponseType);
                instance.SetErrorMessage(message);
                responseObj = instance;
            }
            else
            {
                responseObj = new { Message = message };
            }

            return new ContentResult
            {
                StatusCode = 401,
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(responseObj)
            };
        }


    }
}

using Newtonsoft.Json;
using PAYLO_API.Services.GlobalException;
using PAYLO_Classes.Common;
using PAYLO_Classes.Common.Exceptions;

namespace PAYLO_API.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IErrorLoggerService _errorLogger;
        private readonly IHostEnvironment _env;
        private readonly ILogger<GlobalExceptionMiddleware> _ilogger;

        public GlobalExceptionMiddleware(
            RequestDelegate next,
            IErrorLoggerService errorLogger,
            IHostEnvironment env,
            ILogger<GlobalExceptionMiddleware> ilogger)
        {
            _next = next;
            _errorLogger = errorLogger;
            _env = env;
            _ilogger = ilogger;
        }

        public async Task Invoke(HttpContext context)
        {
            // Enable buffering so we can read the body for logging if an exception occurs
            context.Request.EnableBuffering();

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            string correlationId = context.Items["X-Correlation-Id"]?.ToString() ?? "n/a";

            int statusCode = ex is AppException appEx ? appEx.StatusCode : 500;
            string clientMessage = ex is AppException
                ? ex.Message
                : "An unexpected error occurred. Please contact support with the correlation ID.";

            // Build log entry
            var entry = new ErrorLogEntry
            {
                CorrelationId = correlationId,
                MachineName = Environment.MachineName,
                Application = "VedalexNepalAPI",
                Environment = _env.EnvironmentName,
                HttpMethod = context.Request.Method,
                RequestPath = context.Request.Path,
                QueryString = context.Request.QueryString.ToString(),
                StatusCode = statusCode,
                ClientIp = context.Connection.RemoteIpAddress?.ToString(),
                UserAgent = context.Request.Headers["User-Agent"].ToString(),
                UserIdentity = context.User?.Identity?.Name,
                ExceptionType = ex.GetType().FullName,
                ExceptionMessage = ex.Message,
                StackTrace = ex.StackTrace,
                InnerException = ex.InnerException?.ToString(),
                RequestBody = await SafeReadBodyAsync(context.Request)
            };

            // ILogger for immediate visibility (console/file)
            _ilogger.LogError(ex,
                "Unhandled exception. CorrelationId={CorrelationId}, Path={Path}",
                correlationId, context.Request.Path);

            // Enqueue for DB logging (non-blocking)
            try { _errorLogger.Enqueue(entry); } catch { /* never let logging break the response */ }

            // Build client response
            var response = new ApiErrorResponse
            {
                Success = false,
                Message = clientMessage,
                CorrelationId = correlationId
            };

            context.Response.Clear();
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

        private static async Task<string> SafeReadBodyAsync(HttpRequest request)
        {
            try
            {
                if (!request.Body.CanSeek) return null;
                request.Body.Position = 0;
                using var reader = new StreamReader(request.Body, leaveOpen: true);
                string body = await reader.ReadToEndAsync();
                request.Body.Position = 0;

                // Truncate huge bodies; sanitize known sensitive fields
                if (body.Length > 4000) body = body.Substring(0, 4000) + "...[truncated]";
                return SanitizeSensitiveFields(body);
            }
            catch { return null; }
        }

        private static string SanitizeSensitiveFields(string body)
        {
            if (string.IsNullOrEmpty(body)) return body;
            // Mask common sensitive fields — extend as needed
            return System.Text.RegularExpressions.Regex.Replace(
                body,
                "(\"(password|pwd|apiKey|token|cardNumber|cvv)\"\\s*:\\s*\")[^\"]*\"",
                "$1***\"",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }
    }
}

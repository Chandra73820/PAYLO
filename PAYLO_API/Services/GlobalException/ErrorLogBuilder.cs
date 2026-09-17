using PAYLO_Classes.Common;

namespace PAYLO_API.Services.GlobalException
{
    public static class ErrorLogBuilder
    {
        public static ErrorLogEntry FromHttpContext(
            HttpContext http,
            string exceptionType,
            string message,
            int? statusCode = null,
            string stackTrace = null,
            string innerException = null)
        {
            return new ErrorLogEntry
            {
                CorrelationId = http?.Items["X-Correlation-Id"]?.ToString() ?? Guid.NewGuid().ToString("N"),
                MachineName = Environment.MachineName,
                Application = "VedalexNepalAPI",
                HttpMethod = http?.Request?.Method,
                RequestPath = http?.Request?.Path,
                QueryString = http?.Request?.QueryString.ToString(),
                StatusCode = statusCode,
                ClientIp = http?.Request?.Headers["CF-Connecting-IP"].FirstOrDefault() ?? http?.Request?.Headers["X-Forwarded-For"].FirstOrDefault()
                ?.Split(',')[0].Trim() ?? http?.Connection?.RemoteIpAddress?.ToString(),
                UserAgent = http?.Request?.Headers["User-Agent"].ToString(),
                UserIdentity = http?.User?.Identity?.Name,
                ExceptionType = exceptionType,
                ExceptionMessage = message,
                StackTrace = stackTrace,
                InnerException = innerException
            };
        }
    }
}

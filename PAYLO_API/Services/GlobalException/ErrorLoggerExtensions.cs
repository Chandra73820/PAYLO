namespace PAYLO_API.Services.GlobalException
{
    public static class ErrorLoggerExtensions
    {
        /// <summary>Log an auth failure from any location with HttpContext access.</summary>
        public static void LogAuthFailure(this IErrorLoggerService logger, HttpContext http, string reason)
        {
            try
            {
                var entry = ErrorLogBuilder.FromHttpContext(
                    http, exceptionType: "AuthFailure", message: reason, statusCode: 401);
                logger.Enqueue(entry);
            }
            catch { /* never let logging break the caller */ }
        }

        /// <summary>Log any exception with full HTTP context.</summary>
        public static void LogException(this IErrorLoggerService logger, HttpContext http, Exception ex, int? statusCode = null)
        {
            try
            {
                var entry = ErrorLogBuilder.FromHttpContext(
                    http,
                    exceptionType: ex.GetType().FullName,
                    message: ex.Message,
                    statusCode: statusCode,
                    stackTrace: ex.StackTrace,
                    innerException: ex.InnerException?.ToString());
                logger.Enqueue(entry);
            }
            catch { /* swallow */ }
        }

        /// <summary>Log a custom message (validation failure, business event, etc.).</summary>
        public static void LogMessage(this IErrorLoggerService logger, HttpContext http, string type, string message, int? statusCode = null)
        {
            try
            {
                var entry = ErrorLogBuilder.FromHttpContext(http, type, message, statusCode);
                logger.Enqueue(entry);
            }
            catch { /* swallow */ }
        }
    }
}

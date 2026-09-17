namespace PAYLO_API.Models
{
    public static class AppConstants
    {
        // Application
        public const string ApplicationName = "VedalexNepalAPI";

        // HTTP Headers
        public const string ApiKeyHeaderName = "X-API-Key";
        public const string CorrelationIdHeaderName = "X-Correlation-Id";
        public const string ForwardedForHeader = "X-Forwarded-For";

        // Content Types
        public const string JsonContentType = "application/json";

        // Configuration Keys (paths into appsettings.json)
        public const string ConfigGlobalApiKey = "ApiSettings:GlobalApiKey";
        public const string ConfigApiKeyHeaderName = "ApiSettings:ApiKeyHeaderName";
        public const string ConfigCorrelationHeader = "ApiSettings:CorrelationIdHeaderName";
        public const string ConfigGBLEnvironment = "GBLEnvironment";
        public const string ConfigNepalEnvironment = "Environment";
    }
}

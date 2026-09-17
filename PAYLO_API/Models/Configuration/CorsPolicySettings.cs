namespace PAYLO_API.Models.Configuration
{
    public class CorsPolicySettings
    {
        public string[] AllowedOrigins { get; set; } = Array.Empty<string>();
        public string[] AllowedMethods { get; set; } = Array.Empty<string>();
        public string[] AllowedHeaders { get; set; } = Array.Empty<string>();
        public string[] ExposedHeaders { get; set; } = Array.Empty<string>();
        public bool AllowCredentials { get; set; }
        public int MaxAgeSeconds { get; set; } = 600;
    }

    public class RateLimitWindowSettings
    {
        public int PermitLimit { get; set; }
        public int WindowSeconds { get; set; }
        public int QueueLimit { get; set; } = 0;
    }

    public class HealthCheckSettings
    {
        public int DatabaseTimeoutMs { get; set; } = 3000;
        public int DatabaseDegradedMs { get; set; } = 1000;
        public long MemoryThresholdMb { get; set; } = 1024;
    }
}

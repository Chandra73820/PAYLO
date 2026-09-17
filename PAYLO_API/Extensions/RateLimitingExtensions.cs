namespace VedalexNepalAPI.Extensions
{
    using global::PAYLO_API.Models;
    using global::PAYLO_API.Models.Configuration;
    using global::PAYLO_API.Services.GlobalException;
    using Microsoft.AspNetCore.RateLimiting;
    using Newtonsoft.Json;
    using PAYLO_Classes.ConfigurationClasses;
    using System.Threading.RateLimiting;

    namespace PAYLO_API.Extensions
    {
        public static class RateLimitingExtensions
        {
            public static IServiceCollection AddRateLimiting(
                this IServiceCollection services, IConfiguration config)
            {
                if (!config.GetValue<bool>("RateLimiting:Enabled", true))
                    return services;

                var whitelisted = config.GetSection("RateLimiting:WhitelistedIps").Get<string[]>()
                                  ?? Array.Empty<string>();

                services.AddRateLimiter(options =>
                {
                    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
                    options.OnRejected = BuildRejectionHandler();

                    options.AddPolicy(RateLimitPolicies.Global, ctx =>
                        BuildIpFixedWindow(ctx, config, "RateLimiting:Global", whitelisted));

                    options.AddPolicy(RateLimitPolicies.Auth, ctx =>
                        BuildIpSlidingWindow(ctx, config, "RateLimiting:Authentication", whitelisted));

                    options.AddPolicy(RateLimitPolicies.ApiKey, ctx =>
                        BuildApiKeyTokenBucket(ctx, config, "RateLimiting:ApiKey"));

                    options.AddPolicy(RateLimitPolicies.Sensitive, ctx =>
                        BuildIpSlidingWindow(ctx, config, "RateLimiting:Sensitive", whitelisted));

                    // Global limiter applies to everything unless an endpoint specifies its own
                    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(ctx =>
                        BuildIpFixedWindow(ctx, config, "RateLimiting:Global", whitelisted));
                });

                return services;
            }

            // ─── Algorithm builders ────────────────────────────────────────

            private static RateLimitPartition<string> BuildIpFixedWindow(
                HttpContext ctx, IConfiguration config, string section, string[] whitelisted)
            {
                string ip = GetClientIp(ctx);
                if (IsWhitelisted(ip, whitelisted))
                    return RateLimitPartition.GetNoLimiter("whitelist");

                var s = config.GetSection(section).Get<RateLimitWindowSettings>()!;
                return RateLimitPartition.GetFixedWindowLimiter(ip, _ => new FixedWindowRateLimiterOptions
                {
                    PermitLimit = s.PermitLimit,
                    Window = TimeSpan.FromSeconds(s.WindowSeconds),
                    QueueLimit = s.QueueLimit,
                    AutoReplenishment = true
                });
            }

            /// <summary>Sliding window — smoother enforcement, better for auth/sensitive endpoints.</summary>
            private static RateLimitPartition<string> BuildIpSlidingWindow(
                HttpContext ctx, IConfiguration config, string section, string[] whitelisted)
            {
                string ip = GetClientIp(ctx);
                if (IsWhitelisted(ip, whitelisted))
                    return RateLimitPartition.GetNoLimiter("whitelist");

                var s = config.GetSection(section).Get<RateLimitWindowSettings>()!;
                return RateLimitPartition.GetSlidingWindowLimiter(ip, _ => new SlidingWindowRateLimiterOptions
                {
                    PermitLimit = s.PermitLimit,
                    Window = TimeSpan.FromSeconds(s.WindowSeconds),
                    SegmentsPerWindow = 6,
                    QueueLimit = s.QueueLimit,
                    AutoReplenishment = true
                });
            }

            /// <summary>Token bucket — bursty traffic friendlier, partitioned by API key.</summary>
            private static RateLimitPartition<string> BuildApiKeyTokenBucket(
                HttpContext ctx, IConfiguration config, string section)
            {
                string apiKey = ctx.Request.Headers[AppConstants.ApiKeyHeaderName].ToString();
                string partition = !string.IsNullOrEmpty(apiKey) ? $"key:{apiKey}" : $"ip:{GetClientIp(ctx)}";

                var s = config.GetSection(section).Get<RateLimitWindowSettings>()!;
                return RateLimitPartition.GetTokenBucketLimiter(partition, _ => new TokenBucketRateLimiterOptions
                {
                    TokenLimit = s.PermitLimit,
                    ReplenishmentPeriod = TimeSpan.FromSeconds(s.WindowSeconds),
                    TokensPerPeriod = s.PermitLimit,
                    AutoReplenishment = true,
                    QueueLimit = s.QueueLimit
                });
            }

            // ─── Rejection handler ─────────────────────────────────────────

            private static Func<OnRejectedContext, CancellationToken, ValueTask> BuildRejectionHandler() =>
                async (context, token) =>
                {
                    var http = context.HttpContext;
                    string correlationId = http.Items[AppConstants.CorrelationIdHeaderName]?.ToString()
                                           ?? http.TraceIdentifier;

                    if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
                        http.Response.Headers.RetryAfter = ((int)retryAfter.TotalSeconds).ToString();

                    // Log to your error pipeline
                    var logger = http.RequestServices.GetService<IErrorLoggerService>();
                    logger?.LogMessage(http, "RateLimitExceeded",
                        $"Rate limit hit on {http.Request.Path}", statusCode: 429);

                    var response = new
                    {
                        Success = false,
                        Message = "Too many requests. Please slow down and try again shortly.",
                        CorrelationId = correlationId
                    };

                    http.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                    http.Response.ContentType = AppConstants.JsonContentType;
                    await http.Response.WriteAsync(JsonConvert.SerializeObject(response), token);
                };

            // ─── Helpers ───────────────────────────────────────────────────

            private static string GetClientIp(HttpContext ctx)
            {
                var forwarded = ctx.Request.Headers[AppConstants.ForwardedForHeader].FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(forwarded))
                    return forwarded.Split(',')[0].Trim();
                return ctx.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            }

            private static bool IsWhitelisted(string ip, string[] whitelist) =>
                whitelist.Contains(ip, StringComparer.OrdinalIgnoreCase);
        }
    }
}

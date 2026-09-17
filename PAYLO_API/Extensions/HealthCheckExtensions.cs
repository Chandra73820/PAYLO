using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using PAYLO_API.Models;
using PAYLO_API.Models.Configuration;
using PAYLO_Classes.ConfigurationClasses;
using System.Diagnostics;
using PAYLO_Dal;

namespace PAYLO_API.Extensions
{
    public static class HealthCheckExtensions
    {
        public static IServiceCollection AddApplicationHealthChecks(
            this IServiceCollection services, IConfiguration config)
        {
            services.Configure<HealthCheckSettings>(config.GetSection("HealthChecks"));

            services.AddHealthChecks()
                .AddCheck<DatabaseHealthCheck>(
                    name: "database",
                    failureStatus: HealthStatus.Unhealthy,
                    tags: new[] { HealthCheckTags.Ready, PAYLO_Classes.ConfigurationClasses.HealthCheckTags.Critical, HealthCheckTags.Db })
                .AddCheck<MemoryHealthCheck>(
                    name: "memory",
                    failureStatus: HealthStatus.Degraded,
                    tags: new[] { HealthCheckTags.Ready });

            return services;
        }

        public static WebApplication MapApplicationHealthEndpoints(this WebApplication app)
        {
            // Liveness — is the app process up and responsive? Used by k8s/load balancer
            app.MapHealthChecks("/health/live", new HealthCheckOptions
            {
                Predicate = check => check.Tags.Contains(HealthCheckTags.Live) || check.Tags.Count == 0,
                ResponseWriter = WriteShortResponse,
                AllowCachingResponses = false
            });

            // Readiness — are all dependencies healthy enough to serve traffic?
            app.MapHealthChecks("/health/ready", new HealthCheckOptions
            {
                Predicate = check => check.Tags.Contains(HealthCheckTags.Ready),
                ResponseWriter = WriteShortResponse,
                AllowCachingResponses = false
            });

            // Detailed — full diagnostics. Restrict to internal IPs / authenticated admin.
            app.MapHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = WriteDetailedResponse,
                AllowCachingResponses = false
            });
            // .RequireAuthorization("AdminOnly");   // recommended for /health

            return app;
        }

        private static Task WriteShortResponse(HttpContext context, HealthReport report)
        {
            context.Response.ContentType = AppConstants.JsonContentType;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                status = report.Status.ToString(),
                durationMs = (int)report.TotalDuration.TotalMilliseconds
            }));
        }

        private static Task WriteDetailedResponse(HttpContext context, HealthReport report)
        {
            context.Response.ContentType = AppConstants.JsonContentType;

            var payload = new
            {
                status = report.Status.ToString(),
                totalDurationMs = (int)report.TotalDuration.TotalMilliseconds,
                checks = report.Entries.Select(e => new
                {
                    name = e.Key,
                    status = e.Value.Status.ToString(),
                    durationMs = (int)e.Value.Duration.TotalMilliseconds,
                    description = e.Value.Description,
                    tags = e.Value.Tags,
                    data = e.Value.Data,
                    exception = e.Value.Exception?.Message
                })
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(payload));
        }
    }

    // ─── Custom checks ─────────────────────────────────────────────────

    public class DatabaseHealthCheck : IHealthCheck
    {
        private readonly IConfiguration _config;
        private readonly HealthCheckSettings _settings;

        public DatabaseHealthCheck(
            IConfiguration config,
            Microsoft.Extensions.Options.IOptions<HealthCheckSettings> opts)
        {
            _config = config;
            _settings = opts.Value;
        }

        //public object PAYLODAL { get; private set; }

        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            string env = _config.GetValue<string>("Environment");
            var sw = Stopwatch.StartNew();

            try
            {
                // Ping via the existing DAL connection service.
                // Assumes IConnService has a lightweight test method (e.g., SELECT 1).
                // PAYLODAL.Instance.ConnService.TestConnection(env);
                PAYLODAL.Instance.ConnService.GetClientConnection(env);

                sw.Stop();

                var data = new Dictionary<string, object>
                {
                    ["responseTimeMs"] = sw.ElapsedMilliseconds,
                    ["environment"] = env
                };

                if (sw.ElapsedMilliseconds > _settings.DatabaseTimeoutMs)
                    return Task.FromResult(HealthCheckResult.Unhealthy(
                        $"DB exceeded {_settings.DatabaseTimeoutMs}ms threshold", data: data));

                if (sw.ElapsedMilliseconds > _settings.DatabaseDegradedMs)
                    return Task.FromResult(HealthCheckResult.Degraded(
                        $"DB slow ({sw.ElapsedMilliseconds}ms)", data: data));

                return Task.FromResult(HealthCheckResult.Healthy("DB responsive", data));
            }
            catch (Exception ex)
            {
                sw.Stop();
                var data = new Dictionary<string, object>
                {
                    ["responseTimeMs"] = sw.ElapsedMilliseconds,
                    ["environment"] = env,
                    ["error"] = ex.Message
                };
                return Task.FromResult(HealthCheckResult.Unhealthy("DB unreachable", ex, data));
            }
        }
    }

    public class MemoryHealthCheck : IHealthCheck
    {
        private readonly long _thresholdBytes;

        public MemoryHealthCheck(Microsoft.Extensions.Options.IOptions<HealthCheckSettings> opts)
        {
            _thresholdBytes = opts.Value.MemoryThresholdMb * 1024L * 1024L;
        }

        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            long allocated = GC.GetTotalMemory(forceFullCollection: false);
            using var proc = Process.GetCurrentProcess();
            long workingSet = proc.WorkingSet64;

            var data = new Dictionary<string, object>
            {
                ["allocatedMb"] = allocated / (1024 * 1024),
                ["workingSetMb"] = workingSet / (1024 * 1024),
                ["thresholdMb"] = _thresholdBytes / (1024 * 1024),
                ["gen0"] = GC.CollectionCount(0),
                ["gen1"] = GC.CollectionCount(1),
                ["gen2"] = GC.CollectionCount(2)
            };

            if (allocated > _thresholdBytes)
                return Task.FromResult(HealthCheckResult.Degraded("Memory usage high", data: data));

            return Task.FromResult(HealthCheckResult.Healthy("Memory usage OK", data));
        }
    }
}

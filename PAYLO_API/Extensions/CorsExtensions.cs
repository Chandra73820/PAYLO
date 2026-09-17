using Microsoft.AspNetCore.Cors.Infrastructure;
using PAYLO_Classes.ConfigurationClasses;
using PAYLO_API.Models.Configuration;

namespace PAYLO_API.Extensions
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddCorsPolicies(
            this IServiceCollection services, IConfiguration config)
        {
            services.AddCors(options =>
            {
                AddPolicyFromConfig(options, config, "Cors:Policies:Default", CorsPolicies.Default, required: true);
                AddPolicyFromConfig(options, config, "Cors:Policies:Public", CorsPolicies.Public, required: false);
            });

            return services;
        }

        private static void AddPolicyFromConfig(
            CorsOptions options, IConfiguration config,
            string sectionPath, string policyName, bool required)
        {
            var settings = config.GetSection(sectionPath).Get<CorsPolicySettings>();

            if (settings == null)
            {
                if (required)
                    throw new InvalidOperationException($"Missing required CORS section '{sectionPath}'.");
                return;
            }

            options.AddPolicy(policyName, builder =>
            {
                // Origins
                bool anyOrigin = settings.AllowedOrigins.Contains("*");
                if (anyOrigin)
                    builder.AllowAnyOrigin();
                else if (settings.AllowedOrigins.Length > 0)
                    builder.WithOrigins(settings.AllowedOrigins);

                // Methods
                if (settings.AllowedMethods.Contains("*"))
                    builder.AllowAnyMethod();
                else if (settings.AllowedMethods.Length > 0)
                    builder.WithMethods(settings.AllowedMethods);

                // Headers
                if (settings.AllowedHeaders.Contains("*"))
                    builder.AllowAnyHeader();
                else if (settings.AllowedHeaders.Length > 0)
                    builder.WithHeaders(settings.AllowedHeaders);

                // Exposed headers — so JS can read X-Correlation-Id
                if (settings.ExposedHeaders.Length > 0)
                    builder.WithExposedHeaders(settings.ExposedHeaders);

                // Credentials — incompatible with AllowAnyOrigin (browser silently fails)
                if (settings.AllowCredentials && !anyOrigin)
                    builder.AllowCredentials();

                // Preflight cache duration
                if (settings.MaxAgeSeconds > 0)
                    builder.SetPreflightMaxAge(TimeSpan.FromSeconds(settings.MaxAgeSeconds));
            });
        }
    }
}

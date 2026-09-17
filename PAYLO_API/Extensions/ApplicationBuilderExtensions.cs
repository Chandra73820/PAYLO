using Scalar.AspNetCore;
using Serilog;
using PAYLO_API.Middleware;

namespace PAYLO_API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Configures the full HTTP request pipeline in the correct order.
        /// </summary>
        public static WebApplication ConfigureRequestPipeline(this WebApplication app)
        {
            // ✅ Must be FIRST in pipeline — before any middleware reads IP
            app.UseForwardedHeaders();
            // 1. Correlation ID — earliest so all logs/exceptions can attach the trace ID
            app.UseMiddleware<CorrelationIdMiddleware>();

            // 2. Global exception handler — wraps every middleware below
            app.UseMiddleware<GlobalExceptionMiddleware>();

            // 3. HTTPS redirection (production only)
            if (!app.Environment.IsDevelopment())
                app.UseHttpsRedirection();

            // 4. Serilog request logging — after auth would be ideal, but Serilog
            //    captures status+duration regardless, so placement here is fine
            app.UseSerilogRequestLogging();

            // 5. Cookie policy and session
            //app.UseCookiePolicy(new CookiePolicyOptions
            //{
            //    MinimumSameSitePolicy = SameSiteMode.Strict
            //});
            //app.UseSession();

            // 6. Authentication → custom token-blacklist → Authorization
            app.UseAuthentication();
            app.UseJtiBlacklist();          // MUST be after UseAuthentication
            app.UseAuthorization();

            // 7. Endpoint mapping — docs in dev, then controllers
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();                                           // /openapi/v1.json
                app.MapScalarApiReference(o =>                              // /scalar/v1
                    o.WithOpenApiRoutePattern("/openapi/v1.json"));
            }

            app.MapControllers();

            return app;
        }
    }
}

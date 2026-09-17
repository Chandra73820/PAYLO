using PAYLO_API.Models.Cache;
using PAYLO_API.Services;
using PAYLO_API.Services.GlobalException;

namespace PAYLO_API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        // ─── Core ASP.NET services ────────────────────────────────────────────
        public static IServiceCollection AddCoreServices(
            this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddOpenApi();
            return services;
        }


        // ─── Token + cache services (env-aware blacklist) ─────────────────────
        public static IServiceCollection AddTokenServices(
            this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICacheService, CacheService>();

            //  Global domain — these were missing (cause of the 500 on GblAdminLogin)
            services.AddScoped<IGlobalDomainRefreshTokenRepository, GlobalDomainRefreshTokenRepository>();
            services.AddScoped<IGlobalDomainTokenService, GlobalDomainTokenService>();

            if (env.IsDevelopment())
            {
                services.AddSingleton<IAccessTokenBlacklist, InMemoryAccessTokenBlacklist>();
                services.AddSingleton<IGlobalDomainAccessTokenBlacklist, GlobalDomainInMemoryAccessTokenBlacklist>();
            }
            else
            {
                services.AddSingleton<IAccessTokenBlacklist, SqlAccessTokenBlacklist>();
                services.AddSingleton<IGlobalDomainAccessTokenBlacklist, GlobalDomainSqlAccessTokenBlacklist>();
            }

            //   Session cleanup sweep — belongs with token/session services
            // Hard-revokes tokens left PendingRevoke=1 by the SoftRevoke (tab-close) flow
            //services.AddHostedService<PendingRevokeCleanup>();

            return services;
        }

        // ─── Memory cache (session removed — API is stateless) ────────────────
        public static IServiceCollection AddCachingAndSession(
            this IServiceCollection services)
        {
            //  IMemoryCache — used by JTI blacklist
            services.AddMemoryCache();

            // Session removed — API is stateless, JWT carries all state
            // AddDistributedMemoryCache removed — not needed
            return services;
        }

        // ─── Error logging infrastructure ─────────────────────────────────────
        // ─── Error logging infrastructure ─────────────────────────────────────
        public static IServiceCollection AddErrorHandling(
            this IServiceCollection services)
        {
            services.AddSingleton<ErrorLoggerService>();
            services.AddSingleton<IErrorLoggerService>(sp =>
                sp.GetRequiredService<ErrorLoggerService>());
            services.AddHostedService<ErrorLogBackgroundProcessor>();

            return services;
        }
    }
}

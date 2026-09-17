using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PAYLO_API.Models;
using System.Text;

namespace PAYLO_API.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services,
            IConfiguration configuration, IWebHostEnvironment env)
        {
            string jwtKey = configuration.GetValue<string>("JWTTokenGenKey:VedalexNepal")
                ?? throw new InvalidOperationException(
                    "Missing required configuration 'JWTTokenGenKey:VedalexNepal'. " +
                    "Set it in appsettings, user-secrets, or environment variables.");

            // Custom IAuth implementation
            services.AddSingleton<IAuth>(new Auth(jwtKey));

            byte[] keyBytes = Encoding.UTF8.GetBytes(jwtKey);

            services
                .AddAuthentication(o =>
                {
                    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = !env.IsDevelopment();
                    o.SaveToken = false;

                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        ClockSkew = TimeSpan.Zero,   // no grace period
                        IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
                    };

                    o.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = ctx =>
                        {
                            if (ctx.Exception is SecurityTokenExpiredException)
                                ctx.Response.Headers.Append("Token-Expired", "true");
                            return Task.CompletedTask;
                        }
                    };
                });

            return services;
        }
    }
}

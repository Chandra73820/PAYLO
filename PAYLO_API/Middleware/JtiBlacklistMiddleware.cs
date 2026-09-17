using PAYLO_API.Services;
using System.IdentityModel.Tokens.Jwt;

namespace PAYLO_API.Middleware
{
    /// <summary>
    /// Checks the JTI (JWT ID) claim of every authenticated request
    /// against the blacklist. Blocks tokens that were explicitly revoked
    /// (e.g. via Logout) even though they haven't expired yet.
    /// </summary>
    public class JtiBlacklistMiddleware
    {
        private readonly RequestDelegate _next;

        public JtiBlacklistMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITokenService tokenService)
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var jti = context.User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
                if (!string.IsNullOrEmpty(jti) && tokenService.IsAccessTokenBlacklisted(jti))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(
                        """{"message":"Token has been revoked. Please log in again."}""");
                    return;
                }
            }

            await _next(context);
        }
    }

    public static class JtiBlacklistMiddlewareExtensions
    {
        public static IApplicationBuilder UseJtiBlacklist(this IApplicationBuilder app)
            => app.UseMiddleware<JtiBlacklistMiddleware>();
    }
}

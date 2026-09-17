using Microsoft.IdentityModel.Tokens;
using PAYLO_API.Models.Token;
using System.Collections.Concurrent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PAYLO_API.Services
{
    /// <summary>
    /// Handles access-token creation and refresh-token rotation.
    /// No HttpContext.Session — stateless on the access-token side,
    /// durable refresh tokens stored in SQL via IRefreshTokenRepository.
    /// </summary>
    public interface ITokenService
    {
        Task<TokenPair> IssueTokenPairAsync(string idNo, int regId, string name,
                                                   string userType, string ipAddress,
                                                   string userAgent);


        Task<TokenPair?> RotateRefreshTokenAsync(string rawRefreshToken,
                                                  string userType,
                                                  string ipAddress,
                                                  string userAgent);
        Task<TokenPair?> ResumeSessionAsync(string multiSessionId, string userType);
        Task<LogoutResult> LogoutAsync(string rawRefreshToken, string userType,
                                              string? rawJwt);

        //   IdNo added — comes from claims on [Authorize] Logout endpoint
        Task RevokeRefreshTokenAsync(string rawRefreshToken, string idNo, string userType);
        Task RevokeAllUserTokensAsync(string idNo, int regId, string userType);
        Task BlacklistAccessTokenAsync(string jti, DateTime expiresAt);
        bool IsAccessTokenBlacklisted(string jti);
        string HashToken(string rawToken);
    }


    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly IRefreshTokenRepository _repo;
        private readonly IAccessTokenBlacklist _blacklist;

        private readonly TimeSpan AccessTokenLifetime;
        private readonly TimeSpan RefreshTokenLifetime;


        //// Access token lifetime — keep SHORT (60 min)
        //private static readonly TimeSpan AccessTokenLifetime = TimeSpan.FromMinutes(60);
        //// Refresh token lifetime — longer (1 days)
        //private static readonly TimeSpan RefreshTokenLifetime = TimeSpan.FromDays(1);


        //  private static readonly TimeSpan AccessTokenLifetime= TimeSpan.FromHours(2);

        // private static readonly TimeSpan RefreshTokenLifetime = TimeSpan.FromHours(2);
        public TokenService(IConfiguration config,
                            IRefreshTokenRepository repo,
                            IAccessTokenBlacklist blacklist)
        {
            _config = config;
            _repo = repo;
            _blacklist = blacklist;
            int accessMinutes = _config.GetValue<int>(
            "TokenSettings:AccessTokenLifetimeMinutes");

            int refreshMinutes = _config.GetValue<int>(
                "TokenSettings:RefreshTokenLifetimeMinutes");

            AccessTokenLifetime = TimeSpan.FromMinutes(accessMinutes);

            RefreshTokenLifetime = TimeSpan.FromMinutes(refreshMinutes);
        }


        // Composite key: RegID_UserType — unique per user per user type
        private static readonly ConcurrentDictionary<string, SemaphoreSlim> _userLocks = new();

        private static SemaphoreSlim GetUserLock(int regId, string userType)
        {
            // Key format: "1_Admin" | "1_Distributor" | "2_Retailer"
            var key = $"{regId}_{userType}";
            return _userLocks.GetOrAdd(key, _ => new SemaphoreSlim(1, 1));
        }
        // ── TokenService — IssueTokenPairAsync reuses SessionId if session exists ─────
        public async Task<TokenPair> IssueTokenPairAsync(
    string idNo, int regId, string name,
    string userType, string ipAddress, string userAgent)
        {
            //  Always fresh session on every login — no SQL existence check needed
            // Multi-tab handled by client sharing sessionId from sessionStorage
            // Browser close + relogin = clean fresh start 
            var sessionId = Guid.NewGuid().ToString();
            var (rawRefresh, hashedRefresh) = GenerateRefreshToken();

            await _repo.StoreRefreshTokenAsync(new RefreshTokenRecord
            {
                RegID = regId,
                IdNo = idNo,
                UserType = userType,
                TokenHash = hashedRefresh,
                MultiSessionId = sessionId,
                IssuedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.Add(RefreshTokenLifetime),
                IpAddress = ipAddress,
                UserAgent = userAgent
            });

            var jti = Guid.NewGuid().ToString();
            var accessToken = BuildAccessToken(idNo, regId, name, userType, jti, sessionId);

            return new TokenPair
            {
                AccessToken = accessToken,
                RawRefreshToken = rawRefresh,
                MultiSessionId = sessionId,
                AccessTokenExpiry = DateTime.UtcNow.Add(AccessTokenLifetime),
                RefreshTokenExpiry = DateTime.UtcNow.Add(RefreshTokenLifetime)
            };
        }


        // ── Rotate: validate old refresh token, issue new pair ───────────────
        public async Task<TokenPair?> RotateRefreshTokenAsync(string rawRefreshToken, string userType, string ipAddress, string userAgent)
        {
            string hash = Hash(rawRefreshToken);
            var record = await _repo.GetByHashAsync(hash, userType);

            if (record == null || record.IsRevoked || record.ExpiresAt < DateTime.UtcNow)
            {
                if (record?.IsRevoked == true)
                    await _repo.RevokeUserFamilyAsync(
                        record.IdNo!, record.RegID, userType,
                        "Refresh token reuse detected — possible theft");
                return null;
            }

            //  Lock per RegID + UserType — Admin and Distributor with same RegID
            //    never block each other
            var userLock = GetUserLock(record.RegID, userType);
            if (!await userLock.WaitAsync(TimeSpan.FromSeconds(5)))
            {
                //_logger.LogWarning(
                //    "RotateRefreshToken lock timeout. RegID={RegId} UserType={UserType}",
                //    record.RegID, userType);
                return null;
            }

            try
            {
                // Re-check after acquiring lock — another request may have just rotated
                var recheck = await _repo.GetByHashAsync(hash, userType);
                if (recheck == null || recheck.IsRevoked)
                    return null;

                await _repo.RevokeTokenAsync(hash, record.IdNo!, userType, replacedBy: null);

                var jti = Guid.NewGuid().ToString();
                var accessToken = BuildAccessToken(
                    record.IdNo ?? string.Empty,
                    record.RegID,
                    record.Name ?? string.Empty,
                    userType, jti, record.MultiSessionId);

                var (rawRefresh, hashedRefresh) = GenerateRefreshToken();

                await _repo.StoreRefreshTokenAsync(new RefreshTokenRecord
                {
                    RegID = record.RegID,
                    IdNo = record.IdNo,
                    UserType = userType,
                    TokenHash = hashedRefresh,
                    MultiSessionId = record.MultiSessionId,
                    IssuedAt = DateTime.UtcNow,
                    ExpiresAt = DateTime.UtcNow.Add(RefreshTokenLifetime),
                    IpAddress = ipAddress,
                    UserAgent = userAgent
                });

                return new TokenPair
                {
                    AccessToken = accessToken,
                    RawRefreshToken = rawRefresh,
                    MultiSessionId = record.MultiSessionId,
                    AccessTokenExpiry = DateTime.UtcNow.Add(AccessTokenLifetime),
                    RefreshTokenExpiry = DateTime.UtcNow.Add(RefreshTokenLifetime)
                };
            }
            finally
            {
                userLock.Release();

                // Cleanup lock when no longer in use — prevents dictionary growing forever
                if (userLock.CurrentCount == 1)
                    _userLocks.TryRemove($"{record.RegID}_{userType}", out _);
            }
        }


        public async Task<LogoutResult> LogoutAsync(
    string rawRefreshToken, string userType, string? rawJwt)
        {
            // Step 1: Hash and look up SQL record
            string hash = Hash(rawRefreshToken);
            var record = await _repo.GetByHashAsync(hash, userType);

            //  Token not found — nothing to revoke
            if (record == null)
                return new LogoutResult
                {
                    Success = false,
                    Message = "Token not found."
                };

            // Already revoked — idempotent, treat as success
            // Handles double-logout (safety net + countdown both firing)
            if (record.IsRevoked)
                return new LogoutResult
                {
                    Success = true,
                    Message = "Already logged out."
                };

            // REMOVED: record.ExpiresAt < DateTime.UtcNow check
            // Old: expired tokens returned failure → popup 00:00 logout never revoked RT
            // Fix: always revoke if token exists and not already revoked
            //      expired token in DB is harmless but should be cleaned up on logout

            // Step 2: Blacklist JWT JTI — no expiry validation, may be expired
            if (!string.IsNullOrEmpty(rawJwt))
            {
                try
                {
                    var handler = new JwtSecurityTokenHandler();
                    if (handler.CanReadToken(rawJwt))
                    {
                        var jwt = handler.ReadJwtToken(rawJwt); // no expiry check
                        if (!string.IsNullOrEmpty(jwt.Id))
                        {
                            var expiry = jwt.ValidTo == DateTime.MinValue
                                ? DateTime.UtcNow.Add(AccessTokenLifetime)
                                : jwt.ValidTo;

                            await BlacklistAccessTokenAsync(jwt.Id, expiry);
                        }
                    }
                }
                catch
                {
                    // Malformed JWT — skip blacklist, still revoke RT below
                }
            }

            // Step 3: Revoke RT — works for valid AND expired tokens
            await _repo.RevokeTokenAsync(
                hash, record.IdNo!, userType, replacedBy: null);

            return new LogoutResult
            {
                Success = true,
                Message = "Logged out successfully."
            };
        }
        public async Task<LogoutResult> LogoutAsyncOld1(string rawRefreshToken, string userType, string? rawJwt)
        {
            // Step 1: Hash the raw cookie value and look up SQL record 
            string hash = Hash(rawRefreshToken);
            var record = await _repo.GetByHashAsync(hash, userType);

            if (record == null || record.IsRevoked || record.ExpiresAt < DateTime.UtcNow)
                return new LogoutResult { Success = false, Message = "Session already expired or revoked." };

            // Step 2: Parse Bearer JWT for JTI — no validation, may be expired 
            if (!string.IsNullOrEmpty(rawJwt))
            {
                try
                {
                    var handler = new JwtSecurityTokenHandler();
                    if (handler.CanReadToken(rawJwt))
                    {
                        var jwt = handler.ReadJwtToken(rawJwt);     // ReadJwtToken — no expiry check
                        if (!string.IsNullOrEmpty(jwt.Id))
                        {
                            var expiry = jwt.ValidTo == DateTime.MinValue
                                ? DateTime.UtcNow.Add(AccessTokenLifetime)    // fallback if claim missing
                                : jwt.ValidTo;

                            await BlacklistAccessTokenAsync(jwt.Id, expiry);
                        }
                    }
                }
                catch
                {
                    // Malformed JWT — skip blacklist, still revoke refresh token below
                }
            }

            // Step 3: Revoke refresh token — IdNo from SQL record (not from claims) 
            await _repo.RevokeTokenAsync(hash, record.IdNo!, userType, replacedBy: null);

            return new LogoutResult { Success = true, Message = "Logged out successfully." };
        }
        // ── Logout: revoke one refresh token ─────────────────────────────────
        public async Task RevokeRefreshTokenAsync(string rawRefreshToken, string idNo, string userType)
        {
            string hash = Hash(rawRefreshToken);
            await _repo.RevokeTokenAsync(hash, idNo, userType, replacedBy: null);
        }

        // ── Force-logout: revoke ALL tokens for a user (e.g. password change) ─
        public async Task RevokeAllUserTokensAsync(string IdNo, int regId, string userType)
            => await _repo.RevokeAllAsync(IdNo, regId, userType);

        // ── Blacklist a specific access token JTI (for logout before expiry) ──
        public async Task BlacklistAccessTokenAsync(string jti, DateTime expiresAt)
            => await _blacklist.AddAsync(jti, expiresAt);

        public bool IsAccessTokenBlacklisted(string jti) => _blacklist.Contains(jti);

        // Private helpers

        private string BuildAccessToken(string idNo, int regId, string name,
                                  string userType, string jti, string sessionId)
        {
            string key = _config.GetValue<string>("JWTTokenGenKey:VedalexNepal")!;
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub,  name),
        new Claim(JwtRegisteredClaimNames.Jti,  jti),
        new Claim("RegID",    regId.ToString()),
        new Claim("IdNo",     idNo),             //  available in [Authorize] endpoints
        new Claim("UserType", userType),
        new Claim("MultiSessionId", sessionId),
        new Claim(JwtRegisteredClaimNames.Iat,DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(),
            ClaimValueTypes.Integer64)
    };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"] ?? "VedalexNepal",
                audience: _config["Jwt:Audience"] ?? "VedalexNepalClients",
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.Add(AccessTokenLifetime),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(keyBytes),
                    SecurityAlgorithms.HmacSha256Signature));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string HashToken(string rawToken) => Hash(rawToken);  // delegates to private Hash()
        /// <summary>
        /// Generate a cryptographically random 64-byte token.
        /// Returns (rawToken, SHA-256 hash).
        /// Only the hash is stored — raw token lives in the cookie.



        /// </summary>
        private static (string raw, string hash) GenerateRefreshToken()
        {
            var bytes = RandomNumberGenerator.GetBytes(64);
            var raw = Convert.ToBase64String(bytes);
            return (raw, Hash(raw));
        }

        private static string Hash(string value)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(value));
            return Convert.ToHexString(bytes).ToLowerInvariant();
        }
        public async Task<TokenPair?> ResumeSessionAsync(string multiSessionId, string userType)
        {
            var record = await _repo.GetBySessionIdAsync(multiSessionId, userType);
            if (record == null || record.IsRevoked || record.ExpiresAt < DateTime.UtcNow)
                return null;
            var jti = Guid.NewGuid().ToString();
            var accessToken = BuildAccessToken(record.IdNo ?? string.Empty, record.RegID,
                                  record.Name ?? string.Empty, userType, jti, multiSessionId);
            return new TokenPair
            {
                AccessToken = accessToken,
                RawRefreshToken = string.Empty,
                MultiSessionId = multiSessionId,
                AccessTokenExpiry = DateTime.UtcNow.Add(AccessTokenLifetime),
                RefreshTokenExpiry = record.ExpiresAt
            };
        }
    }
}

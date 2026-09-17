using Microsoft.Data.SqlClient;
using PAYLO_API.Models.Token;
using System.Data;

namespace PAYLO_API.Services
{
    // ── Interface 
    public interface IRefreshTokenRepository
    {
        void StoreRefreshToken(RefreshTokenRecord record);
        Task StoreRefreshTokenAsync(RefreshTokenRecord record);

        RefreshTokenRecord? GetByHash(string tokenHash, string userType);
        Task<RefreshTokenRecord?> GetByHashAsync(string tokenHash, string userType);
        Task<RefreshTokenRecord?> GetBySessionIdAsync(string multiSessionId, string userType);
        Task<ActiveSession?> GetActiveSessionAsync(int regId, string idNo, string userType);
        //  IdNo added — WHERE clause now verifies owner identity
        Task RevokeTokenAsync(string tokenHash, string idNo,
                                      string userType, string? replacedBy);
        Task RevokeUserFamilyAsync(string idNo, int regId,
                                      string userType, string reason);
        Task RevokeAllAsync(string idNo, int regId, string userType);
    }

    // ── ADO.NET Implementation ────────────────────────────────────────────────
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly string _connectionString;

        public RefreshTokenRepository(IConfiguration config)
        {
            string environment = config.GetValue<string>("Environment")!.ToUpper().Trim();

            _connectionString = environment switch
            {
                "DEV" => config.GetConnectionString("DevConnection"),
                "STAG" => config.GetConnectionString("StagingConnection"),
                "LIVE" => config.GetConnectionString("LiveConnection"),
                "PROD" => config.GetConnectionString("ProductionConnection"),
                _ => throw new InvalidOperationException(
                              $"Unknown Environment '{environment}'. Expected: DEV | STAG | LIVE | PROD")
            } ?? throw new InvalidOperationException(
                     $"Connection string for environment '{environment}' is null or missing in appsettings.");
        }

        // ── Store new refresh token → usp_UserRefreshTokens_Insert ───────────
        public void StoreRefreshToken(RefreshTokenRecord record) => StoreRefreshTokenAsync(record).GetAwaiter().GetResult();

        public async Task StoreRefreshTokenAsync(RefreshTokenRecord record)
        {
            await using var con = new SqlConnection(_connectionString);
            await using var cmd = new SqlCommand("usp_UserRefreshTokens_Insert", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add("@RegID", SqlDbType.Int).Value = record.RegID;
            cmd.Parameters.Add("@IdNo", SqlDbType.NVarChar, 50).Value = record.IdNo ?? (object)DBNull.Value;
            cmd.Parameters.Add("@UserType", SqlDbType.NVarChar, 20).Value = record.UserType;
            cmd.Parameters.Add("@TokenHash", SqlDbType.NVarChar, 512).Value = record.TokenHash;
            cmd.Parameters.Add("@MultiSessionId", SqlDbType.NVarChar, 50).Value = record.MultiSessionId;
            cmd.Parameters.Add("@IssuedAt", SqlDbType.DateTime2).Value = record.IssuedAt;
            cmd.Parameters.Add("@ExpiresAt", SqlDbType.DateTime2).Value = record.ExpiresAt;
            cmd.Parameters.Add("@IpAddress", SqlDbType.NVarChar, 50).Value = (object?)record.IpAddress ?? DBNull.Value;
            cmd.Parameters.Add("@UserAgent", SqlDbType.NVarChar, 512).Value = (object?)record.UserAgent ?? DBNull.Value;

            await con.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        // ── Get token by hash  usp_UserRefreshTokens_GetByHash ──────────────
        public RefreshTokenRecord? GetByHash(string tokenHash, string userType)
            => GetByHashAsync(tokenHash, userType).GetAwaiter().GetResult();

        public async Task<RefreshTokenRecord?> GetByHashAsync(string tokenHash, string userType)
        {
            await using var con = new SqlConnection(_connectionString);
            await using var cmd = new SqlCommand("usp_UserRefreshTokens_GetByHash", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add("@TokenHash", SqlDbType.NVarChar, 512).Value = tokenHash;
            cmd.Parameters.Add("@UserType", SqlDbType.NVarChar, 20).Value = userType;

            await con.OpenAsync();
            await using var reader = await cmd.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
                return null;

            return MapRecord(reader);
        }

        //  Revoke single token → usp_UserRefreshTokens_RevokeOne 
        public async Task RevokeTokenAsync(string tokenHash, string idNo,
                                    string userType, string? replacedBy)
        {
            await using var con = new SqlConnection(_connectionString);
            await using var cmd = new SqlCommand("usp_UserRefreshTokens_RevokeOne", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add("@TokenHash", SqlDbType.NVarChar, 512).Value = tokenHash;
            cmd.Parameters.Add("@IdNo", SqlDbType.NVarChar, 50).Value = idNo;
            cmd.Parameters.Add("@UserType", SqlDbType.NVarChar, 20).Value = userType;
            cmd.Parameters.Add("@ReplacedBy", SqlDbType.NVarChar, 512).Value = (object?)replacedBy ?? DBNull.Value;

            await con.OpenAsync();

            // Read AffectedRows — if 0, the hash existed but IdNo didn't match (spoofing attempt)
            await using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                int affected = reader.GetInt32(reader.GetOrdinal("AffectedRows"));
                if (affected == 0)
                {
                    // Log security warning — valid hash but wrong owner
                    // _logger.LogWarning("RevokeToken: hash matched but IdNo mismatch. IdNo={IdNo}", idNo);
                }
            }
        }

        // Revoke all tokens for user → usp_UserRefreshTokens_RevokeFamily 
        public async Task RevokeUserFamilyAsync(string idNo, int regId, string userType, string reason)
        {
            await using var con = new SqlConnection(_connectionString);
            await using var cmd = new SqlCommand("usp_UserRefreshTokens_RevokeFamily", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add("@IdNo", SqlDbType.NVarChar, 50).Value = idNo;
            cmd.Parameters.Add("@RegID", SqlDbType.Int).Value = regId;
            cmd.Parameters.Add("@UserType", SqlDbType.NVarChar, 20).Value = userType;
            cmd.Parameters.Add("@Reason", SqlDbType.NVarChar, 512).Value = reason;

            await con.OpenAsync();

            // Read RevokedCount returned by the procedure for logging
            await using var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                int revokedCount = reader.GetInt32(reader.GetOrdinal("RevokedCount"));
                // Log if needed: $"{revokedCount} token(s) revoked for RegID={regId}, IdNo={idNo}"
            }
        }

        //  Force-revoke all (password change / compromise) 
        public async Task RevokeAllAsync(string idNo, int regId, string userType)
            => await RevokeUserFamilyAsync(idNo, regId, userType, "Force-revoked by user");

        // Map SqlDataReader row RefreshTokenRecord 
        private static RefreshTokenRecord MapRecord(SqlDataReader r) => new()
        {
            Id = r.GetInt64(r.GetOrdinal("Id")),
            IdNo = r.IsDBNull(r.GetOrdinal("IdNo")) ? null : r.GetString(r.GetOrdinal("IdNo")),
            RegID = r.GetInt32(r.GetOrdinal("RegID")),
            UserType = r.GetString(r.GetOrdinal("UserType")),
            TokenHash = r.GetString(r.GetOrdinal("TokenHash")),
            IssuedAt = r.GetDateTime(r.GetOrdinal("IssuedAt")),
            ExpiresAt = r.GetDateTime(r.GetOrdinal("ExpiresAt")),
            IsRevoked = Convert.ToBoolean(r.GetValue(r.GetOrdinal("IsRevoked"))),
            RevokedAt = r.IsDBNull(r.GetOrdinal("RevokedAt"))
                                  ? null : r.GetDateTime(r.GetOrdinal("RevokedAt")),
            ReplacedByToken = r.IsDBNull(r.GetOrdinal("ReplacedByToken"))
                                  ? null : r.GetString(r.GetOrdinal("ReplacedByToken")),
            IpAddress = r.IsDBNull(r.GetOrdinal("IpAddress"))
                                  ? null : r.GetString(r.GetOrdinal("IpAddress")),
            UserAgent = r.IsDBNull(r.GetOrdinal("UserAgent"))
                                  ? null : r.GetString(r.GetOrdinal("UserAgent")),
            Name = r.IsDBNull(r.GetOrdinal("Name"))
                                  ? null : r.GetString(r.GetOrdinal("Name")),
            MultiSessionId = r.IsDBNull(r.GetOrdinal("MultiSessionId"))
                                  ? null : r.GetString(r.GetOrdinal("MultiSessionId"))
        };
        public async Task<ActiveSession?> GetActiveSessionAsync(int regId, string idNo, string userType)
        {
            await using var con = new SqlConnection(_connectionString);
            await using var cmd = new SqlCommand("usp_UserRefreshTokens_GetActiveSession", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.Add("@RegID", SqlDbType.Int).Value = regId;
            cmd.Parameters.Add("@IdNo", SqlDbType.NVarChar, 50).Value = idNo;
            cmd.Parameters.Add("@UserType", SqlDbType.NVarChar, 20).Value = userType;

            await con.OpenAsync();
            await using var reader = await cmd.ExecuteReaderAsync();

            if (!await reader.ReadAsync()) return null;

            return new ActiveSession
            {
                MultiSessionId = reader.GetString(reader.GetOrdinal("MultiSessionId")),
                TokenHash = reader.GetString(reader.GetOrdinal("TokenHash")),
                ExpiresAt = reader.GetDateTime(reader.GetOrdinal("ExpiresAt"))
            };
        }
        public async Task<RefreshTokenRecord?> GetBySessionIdAsync(string multiSessionId, string userType)
        {
            await using var con = new SqlConnection(_connectionString);
            await using var cmd = new SqlCommand("usp_UserRefreshTokens_GetBySessionId", con)
            { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add("@MultiSessionId", SqlDbType.NVarChar, 50).Value = multiSessionId;
            cmd.Parameters.Add("@UserType", SqlDbType.NVarChar, 20).Value = userType;
            await con.OpenAsync();
            await using var reader = await cmd.ExecuteReaderAsync();
            if (!await reader.ReadAsync()) return null;
            return MapRecord(reader);
        }


    }
}

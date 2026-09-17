namespace PAYLO_API.Models.Token
{
    /// <summary>
    /// Returned to the controller after every login or refresh operation.
    /// AccessToken  → sent in JSON response body (stored in JS memory by client)
    /// RawRefreshToken → written into HttpOnly cookie by controller (never in JSON)
    /// </summary>
    public class TokenPair
    {
        public string? AccessToken { get; set; } = string.Empty;
        public string? RawRefreshToken { get; set; } = string.Empty;
        public string? MultiSessionId { get; set; } = string.Empty;
        public DateTime? AccessTokenExpiry { get; set; }
        public DateTime RefreshTokenExpiry { get; set; }
    }



    /// <summary>
    /// Maps to dbo.UserRefreshTokens row.
    /// TokenHash is SHA-256 of the raw token — raw value is never stored.
    /// </summary>
    public class RefreshTokenRecord
    {
        public long Id { get; set; }
        public string IdNo { get; set; }
        public int RegID { get; set; }
        public string UserType { get; set; } = string.Empty;   // Distributor | Retailer | Poinsite
        public string TokenHash { get; set; } = string.Empty;
        public string? MultiSessionId { get; set; }
        public string? ReplacedByToken { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime? RevokedAt { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public string? Name { get; set; }   // populated on read for token rotation

        // Computed — mirrors the persisted computed column in SQL
        public bool IsRevoked { get; set; }
    }
    public class LogoutResult
    {
        public bool Success { get; init; }
        public string Message { get; init; } = string.Empty;
    }
    public class ActiveSession
    {
        public string MultiSessionId { get; set; } = string.Empty;
        public string TokenHash { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }
}

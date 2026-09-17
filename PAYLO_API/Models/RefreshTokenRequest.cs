namespace PAYLO_API.Models
{
    public class RefreshTokenRequest
    {
        public string RawRefreshToken { get; set; } = string.Empty;
        public string MultiSessionId { get; set; } = string.Empty;
    }
}

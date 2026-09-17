namespace PAYLO_API.Models
{
    public class LogoutRequest
    {
        public string RawRefreshToken { get; set; } = string.Empty;
        public string? RawJwt { get; set; }
    }
}

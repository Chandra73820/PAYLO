namespace PAYLO_Classes.Admin
{
    public class QuickLoginRequest
    {
        public int CustomerID { get; set; }
        public string CustomerCode { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
        public string UserAgent { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    public class QuickLoginCustomer_OP
    {
        public int CustomerID { get; set; }
        public string CustomerCode { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string AadhaarNumber { get; set; } = string.Empty;
        public string AadhaarImagePath { get; set; } = string.Empty;
        public string PANNumber { get; set; } = string.Empty;
        public string PANImagePath { get; set; } = string.Empty;
        public int Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }   // nullable if not always set
        public int? UpdatedBy { get; set; }          // nullable if not always set
        public string IPAddress { get; set; } = string.Empty;
        public string SessionID { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string RedirectUrl { get; set; } = string.Empty;

        // Optional: include token/session info if needed
        public string AccessToken { get; set; } = string.Empty;
        public string SessionId { get; set; } = string.Empty;
    }
}

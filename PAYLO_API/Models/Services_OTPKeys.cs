namespace PAYLO_API.Models
{
    public class Services_OTPKeys
    {
        public class SMSOTPKeys
        {
            public string Url { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string SenderID { get; set; }
        }
        public class SMSData
        {
            public string MobileNo { get; set; }
            public string Message { get; set; }
        }
        public class SMSResult
        {
            public string Status { get; set; }
            public string Msg { get; set; }
        }
    }
}

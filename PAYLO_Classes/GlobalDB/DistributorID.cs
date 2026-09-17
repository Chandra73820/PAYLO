namespace PAYLO_Classes.GlobalDB
{
    public class DistributorID
    {
        public string? DistributorId { get; set; }

        public string? DownToId { get; set; } = string.Empty;
        public string? SpSeries { get; set; } = string.Empty;
    }
    public class ChangeSponsor_IP
    {
        public string? Action { get; set; }
        public string? DistributorId { get; set; }
        public string? DownToId { get; set; } = string.Empty;
        public string? SpSeries { get; set; } = string.Empty;
    }
    public class ReferralCheck_IP
    {
        public string? ReferenceID { get; set; } //Referral Code 
    }

    public class ScmProfile
    {

        public string ? ScmProfileId { get; set; } = null;
    }

    public class ProfileSales
    {
        public string? ID { get;  set; } = null;
    }

    public class DistributorIDWithSess : Session_IPAdd
    {
        public string? DistributorId { get; set; }
    }
    public class Introducer_IP
    {
        public string Action { get; set; }
        public string Introducer { get; set; }
        public string Upliner { get; set; }
    }
    public class Introducer_OutPut
    {
        public string sprno { get; set; }
        public string SponsorId { get; set; }
        public string SponsorName { get; set; }
        public string result { get; set; }
    }
    public class CheckUserInfo_IP
    {
        public string? Action { get; set; }
        public string? Input { get; set; }
    }
    public class SendOTP_IP
    {
        public string? Action { get; set; }
        public string? Input { get; set; }
    }
    public class ForgotPassword_IP
    {
        public string? HRID { get; set; }
        public string? MobileNo { get; set; }
        public string? NewPassword { get; set; }
    }
    public class ForgotPassword_OP
    {
        public string? Result { get; set; }
        public string? Message { get; set; }
    }
}

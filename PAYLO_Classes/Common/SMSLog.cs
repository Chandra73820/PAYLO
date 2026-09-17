namespace PAYLO_Classes.Common
{
    public class SMSLog : Session_IPAdd
    {
        public string SenderID { get; set; }
        public string MobileNo { get; set; }
        public string Message { get; set; }
        public string TemplateID { get; set; }
        public int RegID { get; set; }
        public string MemberID { get; set; }
        public string SendFrom { get; set; }
        public string Remarks { get; set; } 
    }


    public class SmsLog_Sp_IP
    {
        public string Action { get; set; }
        public string sesid { get; set; }
        public int RegID { get; set; }
   
    }
}

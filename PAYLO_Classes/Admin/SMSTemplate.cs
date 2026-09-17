using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class SMSTemplate_IP
    {
        public string Action { get; set; } = "";
        public int TemplateId { get; set; }
        public string TemplateCode { get; set; } = "";
        public string Title { get; set; } = "";
        public string MessageText { get; set; } = "";
        public string CountryCode { get; set; } = "NPL";
        public string VarDescription { get; set; } = "";
        public string SparrowTemplateId { get; set; } = "";
        public string Remarks { get; set; } = "";
        public bool? IsActive { get; set; }
        public string ModifiedBy { get; set; } = "";
        public string IpAddress { get; set; } = "";
    }
    public class SMSTemplate_OP
    {
        public bool Status { get; set; }
        public string Message { get; set; } = "";
        public int? TemplateId { get; set; }
    }
    public class SMSTemplateReport_OP
    {
        public int TemplateId { get; set; }
        public string TemplateCode { get; set; } = "";
        public string Title { get; set; } = "";
        public string MessageText { get; set; } = "";
        public int VarCount { get; set; }
        public string CountryCode { get; set; } = "";
        public string VarDescription { get; set; } = "";
        public string SparrowTemplateId { get; set; } = "";
        public string Remarks { get; set; } = "";
        public string SMSStatus { get; set; } = "";
        public string CreatedOn { get; set; } = "";
        public string ModifiedOn { get; set; } = "";
        public int SentCount { get; set; }
        public int FailedCount { get; set; }
        public string LastSentOn { get; set; } = "";
    }

}

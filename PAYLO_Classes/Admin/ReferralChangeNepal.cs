using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class ReferralChangeNepal_IP
    {
        public int RegId { get; set; }
        public int NewSprNo { get; set; }
        public int OldRefGlobalUserId { get; set; }
        public int NewRefGlobalUserId { get; set; }
        public int OldRefFrom { get; set; }
        public int NewRefFrom { get; set; }
        public string Remarks { get; set; }
        public int UId { get; set; }
        public string Session { get; set; }
        public string RefID { get; set; }
        public string RefName { get; set; }
    }
    public class ChangeReferralReportNepal_IP
    {
        public string Action { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string Id { get; set; } = "";
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 100;
        public string SearchText { get; set; } = "";
    }
    public class ChangeReferralReportNepal
    {
        public int TotalRecords { get; set; }
        public string UserId { get; set; } = "";
        public string UserName { get; set; } = "";
        public string OldReferralId { get; set; } = "";
        public string OldReferralName { get; set; } = "";
        public string OldReferralFrom { get; set; } = "";
        public string NewReferralId { get; set; } = "";
        public string NewReferralName { get; set; } = "";
        public string NewReferralFrom { get; set; } = "";
        public string UpdatedDate { get; set; } = "";
        public string Remarks { get; set; } = "";
        public string Status { get; set; } = "";
    }
    public class ChangeReferralReportResponse
    {
        public int TotalRecords { get; set; }
        public List<ChangeReferralReportNepal> Data { get; set; } = new();
    }
}

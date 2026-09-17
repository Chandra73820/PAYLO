using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.GlobalDB
{
    public class ReferralChangeGlobal_IP
    {
        public string IdNo { get; set; }
        public string NewRefIdNo { get; set; }
        public string Remarks { get; set; }
        public int UId { get; set; }
        public string Session { get; set; }
        public string RegFrom { get; set; } = "NP";
        public string Type { get; set; } = "Global";
    }
    public class ReferralChangeResponse
    {
        public string Result { get; set; }
        public string Message { get; set; }
        public string UserID { get; set; }
        public int RegId { get; set; }
        public int CountryId { get; set; }
        public string NewReferral { get; set; }
        public int NewRefRegId { get; set; }
    }
    public class ChangeReferralReport_IP
    {
        public string Action { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string Id { get; set; } = "";
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 100;
        public string SearchText { get; set; } = "";
    }
    public class ChangeReferralReport_GBL
    {
        public int TotalRecords { get; set; }
        public string UserId { get; set; } = "";
        public string UserName { get; set; } = "";
        public string CountryName { get; set; } = "";
        public string OldReferralId { get; set; } = "";
        public string OldReferralName { get; set; } = "";
        public string NewReferralId { get; set; } = "";
        public string NewReferralName { get; set; } = "";
        public string UpdatedDate { get; set; } = "";
        public string Remarks { get; set; } = "";
        public string Status { get; set; } = "";
    }
    public class ChangeReferralReportResponse_GBL
    {
        public int TotalRecords { get; set; }
        public List<ChangeReferralReport_GBL> Data { get; set; } = new();
    }
}

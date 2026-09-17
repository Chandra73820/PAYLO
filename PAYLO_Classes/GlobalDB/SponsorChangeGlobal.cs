using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.GlobalDB
{
    public class SponsorChangeGlobal_IP
    {
        public string IdNo { get; set; }
        public string NewSprIdNo { get; set; }
        public string Remarks { get; set; }
        public int UId { get; set; }
        public string Session { get; set; }
        public string RegFrom { get; set; } = "NP";
        public string Type { get; set; } = "Global";
    }
    public class SponsorChangeResponse
    {
        public string Result { get; set; }
        public string Message { get; set; }
        public string UserID { get; set; }
        public int RegId { get; set; }
        public int CountryId { get; set; }
        public string NewSponsor { get; set; }
        public int NewSprRegId { get; set; }
        public int NewLeg { get; set; }
    }

    public class ChangeSponsorReport_IP
    {
        public string Action { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string Id { get; set; } = "";
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 100;
        public string SearchText { get; set; } = "";
    }
    public class ChangeSponsorReport_GBL
    {
        public int TotalRecords { get; set; }
        public string UserId { get; set; } = "";
        public string UserName { get; set; } = "";
        public string CountryName { get; set; } = "";
        public string OldSponsorId { get; set; } = "";
        public string OldSponsorName { get; set; } = "";
        public string NewSponsorId { get; set; } = "";
        public string NewSponsorName { get; set; } = "";
        public string UpdatedDate { get; set; } = "";
        public string Remarks { get; set; } = "";
        public string UpdatedBy { get; set; } = "";
        public string Status { get; set; } = "";
    }
    public class ChangeSponsorReportResponse_GBL
    {
        public int TotalRecords { get; set; }
        public List<ChangeSponsorReport_GBL> Data { get; set; } = new();
    }
}

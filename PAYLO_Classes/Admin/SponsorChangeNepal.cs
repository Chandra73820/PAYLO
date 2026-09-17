using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class SponsorChangeNepal_IP
    {
        public int RegId { get; set; }
        public int NewSprNo { get; set; }
        public string Remarks { get; set; }
        public int UId { get; set; }
        public string Session { get; set; }       
        public int OldSprGlobalUserId { get; set; }
        public int NewSprGlobalUserId { get; set; }
        public int NewSeries { get; set; }
        public int NewLeg { get; set; }
        public int OldSprFrom { get; set; }
        public int NewSprFrom { get; set; }
        public string SprID { get; set; }
        public string SprName { get; set; }
    }
    public class ChangeSponsorReportNepal_IP
    {
        public string Action { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string Id { get; set; } = "";
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 100;
        public string SearchText { get; set; } = "";
    }
    public class ChangeSponsorReportNepal
    {
        public int TotalRecords { get; set; }
        public string UserId { get; set; } = "";
        public string UserName { get; set; } = "";
        public string OldSponsorId { get; set; } = "";
        public string OldSponsorName { get; set; } = "";
        public string OldSponsorFrom { get; set; } = "";
        public string NewSponsorId { get; set; } = "";
        public string NewSponsorName { get; set; } = "";
        public string NewSponsorFrom { get; set; } = "";
        public string UpdatedDate { get; set; } = "";
        public string Remarks { get; set; } = "";
        public string Status { get; set; } = "";
    }
    public class ChangeSponsorReportResponse
    {
        public int TotalRecords { get; set; }
        public List<ChangeSponsorReportNepal> Data { get; set; } = new();
    }
}

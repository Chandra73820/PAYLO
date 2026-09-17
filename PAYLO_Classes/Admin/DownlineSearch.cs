using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class DownlineSearch_IP
    {
        public string UserID { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string RegFrom { get; set; } = "";
        public string Type { get; set; } = "";
        public int PayNo { get; set; } = 0;
        public string SearchFrom { get; set; } = "Admin";
        public string MainID { get; set; } = "";

    }

    public class DownlineSearch_OP
    {
        public string? ImagePath { get; set; } = "";
        public string IdType { get; set; } = "";
        public int Sno { get; set; }

        public string UserID { get; set; } = "";
        public string Name { get; set; } = "";
        public string Mobile { get; set; } = "";

        public string Status { get; set; } = "";
        public string Rank { get; set; } = "";

        public int DirectReferrals { get; set; }
        public int TeamRecruits { get; set; }
        public int TotalRecruits { get; set; }

        public decimal PBV { get; set; }
        public decimal GBV { get; set; }
        public decimal TBV { get; set; }

        public decimal TotalPBV { get; set; }
        public decimal TotalGBV { get; set; }
        public decimal TotalTBV { get; set; }
    }

    public class SelfBusinessBillwise_IP
    {
        public string Action { get; set; } = "";
        public string MainIdno { get; set; } = "";
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int PayNo { get; set; }
        public string DwnIdno { get; set; } = "";
        public int MaxLvl { get; set; } = 0;
        public int TopN { get; set; } = 0;
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 100;
        public string SearchText { get; set; } = "";
    }
    public class BillWisePagedResponse<T>
    {
        public int TotalRecords { get; set; }

        public List<T> Data { get; set; } = new List<T>();
    }
    public class SelfBusinessBillwise_OP
    {
        public int Sno { get; set; }
        public string Idno { get; set; } = "";
        public string Name { get; set; } = "";
        public string BVSource { get; set; } = "";
        public string BillNo { get; set; } = "";
        public string BillDate { get; set; } = "";
        public decimal TotQty { get; set; }
        public decimal TotalBP { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal NetAmt { get; set; }
        public decimal TotalBV { get; set; }
        public decimal TotalSRBV { get; set; }
        public decimal BV { get; set; }
    }
    public class TeamSalesSummary_OP
    {
        public int Sno { get; set; }
        public string Idno { get; set; } = "";
        public string Name { get; set; } = "";
        public string RankName { get; set; } = "";
        public decimal SelfBV { get; set; }
        public decimal PreferredBV { get; set; }
        public decimal TotalBV { get; set; }
        public decimal TotalSRBV { get; set; }
        public decimal BV { get; set; }
    }
    public class SalesOrderSummary_OP
    {
        public int Sno { get; set; }
        public string Idno { get; set; } = "";
        public string Name { get; set; } = "";
        public string Source { get; set; } = "";
        public decimal SelfBV { get; set; }
        public decimal PreferredBV { get; set; }
        public decimal TotalBV { get; set; }
        public decimal TotalSRBV { get; set; }
        public decimal BV { get; set; }
    }

    public class BillWiseBusinessResponse
    {
        public int TotalRecords { get; set; }
        public List<SelfBusinessBillwise_OP> Data { get; set; } = new List<SelfBusinessBillwise_OP>();
    }


    public class TeamSalesSummaryResponse
    {
        public int TotalRecords { get; set; }
        public List<TeamSalesSummary_OP> Data { get; set; } = new List<TeamSalesSummary_OP>();
    }


    public class SalesOrderSummaryResponse
    {
        public int TotalRecords { get; set; }
        public List<SalesOrderSummary_OP> Data { get; set; } = new List<SalesOrderSummary_OP>();
    }

    public class ExcelJsonResponse<T>
    {
        public string? JsonList { get; set; }
    }
}

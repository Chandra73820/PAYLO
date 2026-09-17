using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class ProductMaster_IP
    {
        public string Action { get; set; } = "";

        public int ISPackage { get; set; }

        public int PrdType { get; set; }

        public int PScid { get; set; }

        public int PsubcatID { get; set; }

        public int PID { get; set; }

        public string PCode { get; set; } = "";

        public string PName { get; set; } = "";

        public string HSNCode { get; set; } = "";

        public decimal MRP { get; set; }

        public decimal SMMPrice { get; set; }

        public decimal CnfPrice { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal SFPrice { get; set; }

        public decimal ARSPrice { get; set; }

        public decimal FranchisePrice { get; set; }

        public decimal VDSPrice { get; set; }

        public decimal DP { get; set; }

        public decimal BV { get; set; }

        public decimal PV { get; set; }

        public decimal Capping { get; set; }

        public int UnitId { get; set; }

        public decimal GST { get; set; }

        public decimal CGST { get; set; }

        public decimal SGST { get; set; }

        public string ThumbImage { get; set; } = "";

        public string BigImage { get; set; } = "";

        public string SmallImage { get; set; } = "";

        public string BriefDescription { get; set; } = "";

        public string DetailDescription { get; set; } = "";

        public int Pstatus { get; set; }

        public int CreatedBy { get; set; }

        public string QUID { get; set; } = "";

        public int MinStock { get; set; }

        public int StandardPackSMM { get; set; }

        public int StandardPack { get; set; }

        public int SFStandardPack { get; set; }

        public int ARSStandardPack { get; set; }

        public int FranchiseStandardPack { get; set; }

        public int UnitWeight { get; set; }

        public int WebsiteDisplay { get; set; }

        public string BarCode { get; set; } = string.Empty;

        public decimal SRBV { get; set; }

        public int ARSaleQty { get; set; }

        public string Benefits { get; set; } = "";

        public string Usage { get; set; } = "";

        public string PrdUrl { get; set; } = string.Empty;

        public string MetaTitle { get; set; } = string.Empty;

        public string MetaDescription { get; set; } = string.Empty;

        public string MetaKeywords { get; set; } = string.Empty;

        public int AttId { get; set; }

        public int OptId { get; set; }
    }

    public class ProductMaster_OP
    {
        public string Result { get; set; } = "";

        public int PID { get; set; }

        public int PScid { get; set; }

        public int PsubcatID { get; set; }

        public string PCode { get; set; } = "";

        public string PName { get; set; } = "";

        public decimal MRP { get; set; }

        public decimal SMMPrice { get; set; }

        public decimal CnfPrice { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal SFPrice { get; set; }

        public decimal ARSPrice { get; set; }

        public decimal FranchisePrice { get; set; }

        public decimal VDSPrice { get; set; }

        public decimal DP { get; set; }

        public decimal BV { get; set; }

        public decimal PV { get; set; }

        public decimal Capping { get; set; }

        public string Category { get; set; } = "";

        public string SubCategory { get; set; } = "";

        public int UnitId { get; set; }

        public string UnitName { get; set; } = "";

        public string Benefits { get; set; } = "";

        public string Usage { get; set; } = "";

        public string Status { get; set; } = "";

        public string ThumbImage { get; set; } = "";

        public string BigImage { get; set; } = "";

        public string SmallImage { get; set; } = "";

        public string BriefDescription { get; set; } = "";

        public string DetailDescription { get; set; } = "";

        public int Pstatus { get; set; }

        public string HSNCode { get; set; } = "";

        public decimal GST { get; set; }

        public decimal CGST { get; set; }

        public decimal SGST { get; set; }

        public int PrdType { get; set; }

        public string PurchaseType { get; set; } = "";

        public int MinStock { get; set; }

        public int StandardPackSMM { get; set; }

        public int StandardPack { get; set; }

        public int SFStandardPack { get; set; }

        public int ARSStandardPack { get; set; }

        public int FranchiseStandardPack { get; set; }

        public int UnitWeight { get; set; }

        public int WebsiteDisplay { get; set; }

        public string BarCode { get; set; } = "";

        public decimal SRBV { get; set; }

        public decimal Gm { get; set; }

        public int ARSaleQty { get; set; }

        public string Offertype { get; set; } = "";

        public int IsOffer { get; set; }

        public string PrdUrl { get; set; } = "";

        public string MetaTitle { get; set; } = "";

        public string MetaDescription { get; set; } = "";

        public string MetaKeywords { get; set; } = "";

        public int AttId { get; set; }

        public int OptId { get; set; }

        public string AttributeName { get; set; } = "";

        public string OptionValue { get; set; } = "";
    }
    public class OpenProductDetailsIP
    {
        public string Action { get; set; } = "";

        public int PID { get; set; }

        public int CatID { get; set; }
    }
}

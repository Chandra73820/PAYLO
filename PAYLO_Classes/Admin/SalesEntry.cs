using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes
{
    public class SalesEntry
    {
    }
    public class ProductsRequestOrdersOP
    {
        public int checkbox { get; set; }
        public Int32 pid { get; set; }
        public string Pcode { get; set; }
        public string Name { get; set; }
        public decimal MRP { get; set; }
        public decimal BV { get; set; }
        public decimal PV { get; set; }
        public decimal DP { get; set; }
        public Int32 Qty { get; set; }
        public Int32 AvailQty { get; set; }
        public Int32 OrdQty { get; set; }
        public decimal PurchasePrice { get; set; }
        public string SmallImage { get; set; }
        public Boolean IsPackage { get; set; }
        public Int32 StandardPack { get; set; }
        public string ProductType { get; set; }


        public decimal FranchisePrice { get; set; }
        public decimal SFPrice { get; set; }
        public decimal CnfPrice { get; set; }
        public decimal ARSPrice { get; set; }
        public decimal SMMPrice { get; set; }
        public decimal VDSPrice { get; set; }
        public Int32 BalanceQuantity { get; set; }
        public int IsOffer { get; set; }
        public string OfferProduct { get; set; }
    }
    public class ProductDetails_IP
    {
        public string action { get; set; } = string.Empty;

        public string Fcode { get; set; } = string.Empty;

        public int pcid { get; set; }

        public int Regid { get; set; }
    }
    public class TmpRPProductsItemsOP
    {
        public string result { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }

        public Int32 Pid { get; set; }
        public string Pcode { get; set; }
        public string PName { get; set; }
        public Int32 Qty { get; set; }
        public Int32 AvailQty { get; set; }

        public decimal MRP { get; set; }
        public decimal DP { get; set; }
        public decimal TotalDP { get; set; }

        public decimal BasicPrice { get; set; }
        public decimal TotalBasicPrice { get; set; }
        public decimal OfferDiscPer { get; set; }
        public decimal OfferBP { get; set; }
        public decimal TotalOfferBP { get; set; }
        public decimal OfferDiscountAmt { get; set; }
        public decimal TotalOfferDiscountAmt { get; set; }
        public decimal DiscountPer { get; set; }

        public decimal BP { get; set; }
        public decimal TotalBP { get; set; }

        public decimal DiscountAmt { get; set; }
        public decimal TotalDiscountAmt { get; set; }

        public decimal VAT { get; set; }
        public decimal TaxAmt { get; set; }

        public decimal BV { get; set; }
        public decimal TotalBV { get; set; }

        public decimal PV { get; set; }
        public decimal TotalPV { get; set; }

        public string TaxType { get; set; }

        public decimal CCharges { get; set; }

        public Boolean IsPackage { get; set; }

        public int IsOffer { get; set; }
    }
    public class TmpRPProductsItemsIP
    {
        public string Orderfrom { get; set; } = string.Empty;

        public string action { get; set; } = string.Empty;

        public int pcode { get; set; }

        public int qty { get; set; }

        public string sessionid { get; set; } = string.Empty;

        public string UID { get; set; } = string.Empty;

        public int Regid { get; set; }

        public string DState { get; set; } = string.Empty;

        public string FCode { get; set; } = string.Empty;

        public string salesto { get; set; } = string.Empty;
    }
    public class OrderConfirmIP
    {
        public decimal RegID { get; set; }

        public int TotQty { get; set; }

        public decimal TotalDP { get; set; } = 0;

        public decimal ShipAmt { get; set; }

        public string TaxType { get; set; } = string.Empty;

        public string Sstate { get; set; } = string.Empty;

        public string Remraks { get; set; } = string.Empty;

        public string OrderThru { get; set; } = string.Empty;

        public string OrderFrom { get; set; } = string.Empty;

        public string SalesTo { get; set; } = string.Empty;

        public string sessid { get; set; } = string.Empty;

        public string UID { get; set; } = string.Empty;

        public string IpAddress { get; set; } = string.Empty;

        public string SName { get; set; } = string.Empty;

        public string Addr { get; set; } = string.Empty;

        public int StId { get; set; }

        public string District { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public string Pin { get; set; } = string.Empty;

        public string SGSTNo { get; set; } = string.Empty;

        public string Mop { get; set; } = string.Empty;

        public string DispatchMode { get; set; } = string.Empty;

        public int ReqTo { get; set; }

        public string ReqToType { get; set; } = string.Empty;

        public string ModeOfGST { get; set; } = string.Empty;
    }
    public class SalesInvoiceOP
    {
        public string Billno { get; set; }
        public string Result { get; set; }
    }
}

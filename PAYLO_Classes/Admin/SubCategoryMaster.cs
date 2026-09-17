using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class ProductSubCategory_IP
    {
        public string Action { get; set; }

        public int PcmId { get; set; }

        public int PscId { get; set; }

        public string SubCategoryName { get; set; }

        //public string Image { get; set; }

        public int Addedby { get; set; }

        public int Status { get; set; }

        public string IpAdd { get; set; }

        public string SessionID { get; set; }
    }
    public class StockInwardReport_IP
    {
        public string action { get; set; }

        public string fromdate { get; set; }

        public string todate { get; set; }
    }
    public class StockInwardReport_OP
    {
        public string Refno { get; set; }
        public int Qty { get; set; }
        public decimal TotalBP { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal NetAmt { get; set; }
        public string RefDate { get; set; }
        public string Remarks { get; set; }
        public string VenName { get; set; }
        public string Billno { get; set; }
        public string PName { get; set; }
        public string Purpose { get; set; }
        public string UserName { get; set; }
        public string InwardDate { get; set; }
    }
    public class StockLevel_IP
    {
        public string action { get; set; }
        public int FCode { get; set; }
        public string Fromdate { get; set; }
        public string Todate { get; set; }
    }
    public class StockLevel_OP
    {
        public int Pid { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Pstatus { get; set; }
        public string Category { get; set; }
        public decimal CP { get; set; }
        public decimal BV { get; set; }
        public decimal Open_Inward { get; set; }
        public decimal Open_Outward { get; set; }
        public int OpeningStock { get; set; }
        public int StockReceived { get; set; }
        public int StockReturnReceived { get; set; }
        public int StockAdjustmentReceived { get; set; }
        public int StockTransfer { get; set; }
        public int StockAdjustmentIssue { get; set; }
        public int SaleQuantity { get; set; }
        public int StockAdjAdmin { get; set; }
        public decimal KitStockTransfer { get; set; }
        public int BalanceQuantity { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal BalanceBV { get; set; }
        public string SubCategory { get; set; }
        public string PrdType { get; set; }
    }
    public class UploadpopImages_IP
    {
        public string action { get; set; }
        public string? Subject { get; set; }
        public string? Image { get; set; }
        public int Uid { get; set; } = 0;
        public string? PopUpStartDate { get; set; }
        public string? PopUpEndDate { get; set; }
    }
    public class UploadpopImages_OP
    {
        public int SNo { get; set; }
        public string? FileName { get; set; }
        public string? Subject { get; set; }
        public string? UserType { get; set; }
    }
    public class ARSalesReport_IP
    {
        public string action { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string? FCode { get; set; }
        public int TypeID { get; set; }
        public int CountryId { get; set; } = 0;
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 100;
        public string SearchText { get; set; } = "";
    }
    public class ARSalesReport_OP
    {
        public int RPOId { get; set; }
        public int BillType { get; set; }
        public string Orderno { get; set; }
        public string OrderDate { get; set; }
        public string InvNo { get; set; }
        public string memInvNo { get; set; }
        public string InvDate { get; set; }
        public string Idno { get; set; }
        public string Name { get; set; }
        public string StateName { get; set; }
        public string BuyerState { get; set; }
        public string ShipAddr { get; set; }
        public string ShipCity { get; set; }
        public string ShipDistrict { get; set; }
        public string ShipStateName { get; set; }
        public string ShipPincode { get; set; }
        public string ShipMobile { get; set; }
        public string ShippingAddress { get; set; }
        public string PStatus { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCP { get; set; }
        public decimal TotalPV { get; set; }
        public decimal TotalBV { get; set; }
        public decimal TotalSRBV { get; set; }
        public decimal TotalBillingAmount { get; set; }
        public decimal TotalTax { get; set; }
        public decimal NetAmount { get; set; }
        public string FCode { get; set; }
        public string FranchiseName { get; set; }
        public string CourierDetailes { get; set; }
        public string mop { get; set; }
        public string DocketNo { get; set; }
        public string DeliveryDate { get; set; }
        public string DeliveryRemarks { get; set; }
        public bool Migration { get; set; }
        public decimal TotWeight { get; set; }
        public string CourierNo { get; set; }
        public decimal OfferDiscountAmt { get; set; }
    }

    public class FranchiseReport_IP
    {
        public string Action { get; set; }
        public int FID { get; set; } = 0;
        public string? DeletedBY { get; set; }
    }

    public class VRSalesReport_GBL_OP
    {
        public long RPOId { get; set; }

        public int BillType { get; set; }

        public string OrderNo { get; set; } = "";

        public string OrderDate { get; set; } = "";

        public string InvNo { get; set; } = "";

        public string MemInvNo { get; set; } = "";

        public string InvDate { get; set; } = "";

        public string IdNo { get; set; } = "";

        public string Name { get; set; } = "";

        public string Country { get; set; } = "";

        public string PStatus { get; set; } = "";

        public int Quantity { get; set; }

        public decimal TotalCP { get; set; }

        public decimal TotalPV { get; set; }

        public decimal TotalBV { get; set; }

        public decimal TotalSRBV { get; set; }

        public decimal TotalBillingAmount { get; set; }

        public decimal TotalTax { get; set; }

        public decimal NetAmount { get; set; }

        public string MOP { get; set; } = "";

        public string DeliveryDate { get; set; } = "";

        public string DeliveryRemarks { get; set; } = "";

        public decimal TotWeight { get; set; }

        public decimal OfferDiscountAmt { get; set; }

        public string MemberStatus { get; set; } = "";

        public string Sponsor { get; set; } = "";
    }

    public class VRSalesReportResponse_GBL
    {
        public int TotalRecords { get; set; }
        public decimal PageBillingTotal { get; set; }
        public decimal PageTaxTotal { get; set; }
        public decimal PageNetTotal { get; set; }
        public decimal PageBVTotal { get; set; }

        public decimal GrandBillingTotal { get; set; }
        public decimal GrandTaxTotal { get; set; }
        public decimal GrandNetTotal { get; set; }
        public decimal GrandBVTotal { get; set; }
        public List<VRSalesReport_GBL_OP> Data { get; set; } = new();
    }
    public class FranchiseReport_OP
    {
        public int Fid { get; set; }
        public string Fcode { get; set; }
        public string fname { get; set; }
        public string Upliner { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public int Stateid { get; set; }
        public int DispayInWebsite { get; set; }
        public string? SponsorId { get; set; }
        public string? ReferalId { get; set; }
        public string? CPName { get; set; }
        public string? SelfId { get; set; }
        public string? JoinDate { get; set; }
        public int Stocklimit { get; set; }
        public int Salelimit { get; set; }
        public int AvlQty { get; set; }
        public decimal AvlBV { get; set; }
        public decimal AvlBalAmt { get; set; }
        public decimal Balance { get; set; }
        public string? Remarks { get; set; }
        public int Certid { get; set; }
        public int Stkrtnid { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? Tehsil { get; set; }
        public string? PhoneNo { get; set; }
        public string? AlternateMobile { get; set; }
        public string? Bank { get; set; }
        public string? Branch { get; set; }
        public string? AccType { get; set; }
        public string? AccNo { get; set; }
        public string? IFSC { get; set; }
        public string? Pan { get; set; }
        public string? GSTNo { get; set; }
        public string? GstType { get; set; }
        public string? FssaiNo { get; set; }
        public string? FSSAIExp { get; set; }
        public string? UplinerType { get; set; }
    }
    public class GenealogyTree_IP
    {
        public string IdNo { get; set; }
        public string RegFrom { get; set; }
        public string Type { get; set; }
        public string MainID { get; set; }
    }
        public class GenealogyTree_OP
    {
        public string? Result { get; set; }
        public string? Message { get; set; }
        public string? IdType { get; set; }
        public int regid { get; set; } = 0;
        public string? Name { get; set; }
        public string?  UserID { get; set; }
        public int Sprcount { get; set; } = 0;
        public int DownCnt { get; set; } = 0;
        public decimal? SelfAmt { get; set; }
        public decimal? SelfBV { get; set; }
        public decimal? TotBV { get; set; }
        public decimal? DownAmt { get; set; }
        public decimal? DownBV { get; set; }
        public decimal? TotDownBV { get; set; }
        public string Sponsor { get; set; }
        public string? sprname { get; set; }
        public string? memdate { get; set; }
        public string? stsdate { get; set; }
        public int StsID { get; set; } = 0;
        public string? mstatus { get; set; } 
        public string? Mobile { get; set; }
        public bool IsLock { get; set; }
        public string? Designationlevel { get; set; }
        public decimal? TotalGroupBV { get; set; }
        public string? Dno { get; set; }
        public int CountryId { get; set; }
        public decimal? GroupPurchase { get; set; }
        public decimal? GroupBV { get; set; }
        public string? ImagePath { get; set; }
         
    }
    public class FranchiseStocklevelReport_OP
    {
        public int Pid { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Pstatus { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public decimal CP { get; set; }
        public decimal MRP { get; set; }
        public decimal BV { get; set; }
        public decimal Open_Inward { get; set; }
        public decimal Open_Outward { get; set; }
        public int OpeningStock { get; set; }
        public int StockReceived { get; set; }
        public int StockReturnReceived { get; set; }
        public int StockAdjustmentReceived { get; set; }
        public int StockTransfer { get; set; }
        public int Sales { get; set; }
        public int StockAdjustmentIssue { get; set; }
        public int KitStockTransfer { get; set; }
        public int BalanceQuantity { get; set; }
        public decimal BalanceBV { get; set; }
        public decimal BalanceAmount { get; set; }
        public string PrdType { get; set; }
    }

    public class BatchWiseStockClick_IP
    {
        public string Action { get; set; } = "";

        public int Pid { get; set; }

        public string CFACode { get; set; } = "0";

        public string FromDate { get; set; } = "";

        public string ToDate { get; set; } = "";
    }
    public class BatchWiseStockClick_OP
    {
        public string Pcode { get; set; }

        public string PName { get; set; }

        public int Qty { get; set; }

        public string BatchNo { get; set; }

        public string ExpDate { get; set; }
    }
}

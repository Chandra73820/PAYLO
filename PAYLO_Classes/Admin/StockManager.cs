using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes
{
    public class StockManager
    {
    }
    public class GetProductsStockInward_List
    {
        public int disabledates { get; set; }
        public int checkbox { get; set; }
        public Int32 Pid { get; set; }
        //public int PID { get; set; }
        public string Pcode { get; set; }
        public string Pname { get; set; }
        public string ProductType { get; set; }
        public decimal Price { get; set; }
        public string BatchNo { get; set; }
        public string MfgDate { get; set; }
        public string ExpiryDate { get; set; }
        public Int32 Quantity { get; set; }
        public Int32 QtyPerBox { get; set; }
        public Int32 Balance { get; set; }
    }
    public class TempProductInward
    {
        public Int32 Sno { get; set; }
        public string SubCategory { get; set; }
        public string Pcode { get; set; }
        public string Pname { get; set; }
        public string ProductType { get; set; }
        public Int32 Quantity { get; set; }
        public Int32 Pid { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string BatchNo { get; set; }
        public string MfgDate { get; set; }
        public string ExpiryDate { get; set; }
        public Int32 QtyPerBox { get; set; }
        public Int32 MinQty { get; set; }
        public Int32 IsOffer { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal NetAmt { get; set; }
    }
    public class GetStockInwardProduct_IP
    {
        public int pscid { get; set; }

        public int pid { get; set; }
    }
    public class ProductInward_IP
    {
        public Int32 VenID { get; set; }
        public string VenBillNo { get; set; }
        public Int32 PurId { get; set; }
        public string UniqId { get; set; }
        public string Remarks { get; set; }
        public string InwardDate { get; set; }

        public string dmode { get; set; }
        public string modname { get; set; }
        public string modno { get; set; }
        public string moddate { get; set; }
        public string modremarks { get; set; }
        public string VehicleNo { get; set; }

        public string Sessid { get; set; }
    }
    public class TempProductInward_IP
    {
        public int PurId { get; set; }
        public string action { get; set; }
        public string UniqId { get; set; }
        public int Pid { get; set; }
        public int Quantity { get; set; }
        public string BatchNo { get; set; }
        public string MfgDate { get; set; }
        public string ExpiryDate { get; set; }
        public string sesid { get; set; }
    }
    public class GetStockOrderReq
    {
        public Int32 slno { get; set; }
        public string RefNo { get; set; }
        public string RefDate { get; set; }
        public string Fcode { get; set; }
        public string fname { get; set; }
        public string Packcode { get; set; }
        public Int32 qty { get; set; }
        public decimal NetAmt { get; set; }
        public decimal TotBV { get; set; }

        public string Remarks { get; set; }
        public string status { get; set; }

        public string InvNo { get; set; }
        public string InvDate { get; set; }

        public string VerifyNo { get; set; }
        public string VerifyDate { get; set; }
        public string ReturnType { get; set; }
        public decimal OffWallAmt { get; set; }


    }
    public class GetStockOrderReqIP
    {
        public string action { get; set; }
        public string Fcode { get; set; }
        public string ReqToType { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string OrderType { get; set; }
    }
    public class GetBatchwisestockIP
    {
        public string Action { get; set; }
        public string fcode { get; set; }
        public string Fid { get; set; }
        public Int32 Pid { get; set; }
        public string CFACode { get; set; }
    }
    public class Batchwisedata
    {
        public Int32 Pid { get; set; }
        public Int32 fid { get; set; }
        public string pcode { get; set; }
        public string pname { get; set; }
        public Int32 AQty { get; set; }
        public string Batchno { get; set; }
        public decimal MRP { get; set; }
        public decimal AP { get; set; }
        public decimal BV { get; set; }
        public decimal Rate { get; set; }
        public Int32 Avlqty { get; set; }
        public Int32 OrdQty { get; set; }
        public string mgdate { get; set; }
        public string expdate { get; set; }
    }
    public class ApprovedStockdorderIP
    {
        public string action { get; set; }
        public string RefNo { get; set; }
        public string fcode { get; set; }
        public string remarks { get; set; }
        public string AppRejby { get; set; }
        public string AppRejtype { get; set; }
        public string sesid { get; set; }
        public string Batchwisestock { get; set; }
    }
    public class GetProductBatchnoDatesIP
    { 
        public int Pid { get; set; }
        public string BatchNo { get; set; }
    }
    public class GetProductBatchnoDates
    {
        public string MgDate { get; set; }
        public string Expdate { get; set; }
    }
    public class StockOrderAvalQtyIP
    {
        public string action { get; set; }
        public string fcode { get; set; }
        public string refno { get; set; }
    }
    public class StockOrderAvalQty
    {
        public string ProductCode { get; set; }
        public Int32 BalanceQty { get; set; }
        public Int32 OrderQty { get; set; }
    }
}

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAYLO_Classes;
using PAYLO_Classes.Admin;
using PAYLO_Classes.Common;

namespace PAYLO_Dal.ItemFactories
{
    internal partial class AdminItemFactory
    {
        internal static UnitMaster_OP UnitMasterItemFactory(SqlDataReader reader)
        {
            UnitMaster_OP items = new UnitMaster_OP();

            if (!Convert.IsDBNull(reader["UnitId"]))
                items.UnitId = Convert.ToInt32(reader["UnitId"]);

            if (!Convert.IsDBNull(reader["UnitName"]))
                items.UnitName = reader["UnitName"].ToString();

            if (!Convert.IsDBNull(reader["ShortName"]))
                items.ShortName = reader["ShortName"].ToString();

            if (!Convert.IsDBNull(reader["Status"]))
                items.Status = Convert.ToInt32(reader["Status"]);

            if (!Convert.IsDBNull(reader["PStatus"]))
                items.PStatus = reader["PStatus"].ToString();

            return items;
        }
        internal static CommonMessage CommonMessageItemFactory(SqlDataReader reader)
        {
            CommonMessage Items = new CommonMessage();

            if (Convert.IsDBNull(reader["Result"]))
                Items.Result = null;
            else
                Items.Result = (string)reader["Result"];

            if (Convert.IsDBNull(reader["Message"]))
                Items.Message = null;
            else
                Items.Message = (string)reader["Message"];

            return Items;
        }
        internal static GetProductsStockInward_List GetProductsStockInwardItemFactory(SqlDataReader reader)
        {
            GetProductsStockInward_List items = new GetProductsStockInward_List();

            items.disabledates = (int)reader["disabledates"];
            items.checkbox = (int)reader["checkbox"];
            items.Pid = (Int32)reader["Pid"];

            if (Convert.IsDBNull(reader["Pcode"]))
                items.Pcode = null;
            else
                items.Pcode = (string)reader["Pcode"];

            if (Convert.IsDBNull(reader["Pname"]))
                items.Pname = null;
            else
                items.Pname = (string)reader["Pname"];

            if (Convert.IsDBNull(reader["ProductType"]))
                items.ProductType = null;
            else
                items.ProductType = (string)reader["ProductType"];

            items.Price = (decimal)reader["Price"];

            if (Convert.IsDBNull(reader["BatchNo"]))
                items.BatchNo = null;
            else
                items.BatchNo = (string)reader["BatchNo"];

            if (Convert.IsDBNull(reader["MfgDate"]))
                items.MfgDate = null;
            else
                items.MfgDate = (string)reader["MfgDate"];

            if (Convert.IsDBNull(reader["ExpiryDate"]))
                items.ExpiryDate = null;
            else
                items.ExpiryDate = (string)reader["ExpiryDate"];

            items.Quantity = (Int32)reader["Quantity"];

            return items;
        }
        internal static TempProductInward TempProductInwardItemFactory(SqlDataReader reader)
        {
            TempProductInward items = new TempProductInward();

            if (Convert.IsDBNull(reader["SubCategory"]))
                items.SubCategory = null;
            else
                items.SubCategory = (string)reader["SubCategory"];

            if (Convert.IsDBNull(reader["Pcode"]))
                items.Pcode = null;
            else
                items.Pcode = (string)reader["Pcode"];

            if (Convert.IsDBNull(reader["Pname"]))
                items.Pname = null;
            else
                items.Pname = (string)reader["Pname"];

            items.Quantity = (Int32)reader["Quantity"];
             items.Pid = (Int32)reader["Pid"];

            if (Convert.IsDBNull(reader["ProductType"]))
                items.ProductType = null;
            else
                items.ProductType = (string)reader["ProductType"];

            //items.QtyPerBox = (Int32)reader["QtyPerBox"];

            items.Price = (decimal)reader["Price"];
            items.TotalPrice = (decimal)reader["TotalPrice"];

            if (Convert.IsDBNull(reader["BatchNo"]))
                items.BatchNo = null;
            else
                items.BatchNo = (string)reader["BatchNo"];

            if (Convert.IsDBNull(reader["MfgDate"]))
                items.MfgDate = null;
            else
                items.MfgDate = (string)reader["MfgDate"];

            if (Convert.IsDBNull(reader["ExpiryDate"]))
                items.ExpiryDate = null;
            else
                items.ExpiryDate = (string)reader["ExpiryDate"];


            items.TaxAmt = (decimal)reader["TaxAmt"];
            items.NetAmt = (decimal)reader["NetAmt"];

            return items;
        }
        internal static ProductsRequestOrdersOP ProductsRequestOrdersItemFactory(SqlDataReader reader)
        {
            ProductsRequestOrdersOP Items = new ProductsRequestOrdersOP();

            Items.checkbox = (int)reader["checkbox"];
            Items.pid = (Int32)reader["pid"];

            if (Convert.IsDBNull(reader["Pcode"]))
                Items.Pcode = null;
            else
                Items.Pcode = (string)reader["Pcode"];

            if (Convert.IsDBNull(reader["Name"]))
                Items.Name = null;
            else
                Items.Name = (string)reader["Name"];

            Items.MRP = (decimal)reader["MRP"];
            Items.BV = (decimal)reader["BV"];
            Items.PV = (decimal)reader["PV"];
            Items.PurchasePrice = (decimal)reader["PurchasePrice"];
            Items.DP = (decimal)reader["DP"];
            Items.Qty = (Int32)reader["Qty"];
            Items.AvailQty = (Int32)reader["AvailQty"];
            Items.OrdQty = (Int32)reader["OrdQty"];

            if (Convert.IsDBNull(reader["SmallImage"]))
                Items.SmallImage = null;
            else
                Items.SmallImage = (string)reader["SmallImage"];

            Items.IsPackage = (Boolean)reader["IsPackage"];
            Items.StandardPack = (Int32)reader["StandardPack"];

            if (Convert.IsDBNull(reader["ProductType"]))
                Items.ProductType = null;
            else
                Items.ProductType = (string)reader["ProductType"];

            Items.BalanceQuantity = (Int32)reader["BalanceQuantity"];

            Items.FranchisePrice = (decimal)reader["FranchisePrice"];
            Items.SFPrice = (decimal)reader["SFPrice"];
            Items.CnfPrice = (decimal)reader["CnfPrice"];
            Items.ARSPrice = (decimal)reader["ARSPrice"];
            Items.SMMPrice = (decimal)reader["SMMprice"];
            Items.VDSPrice = (decimal)reader["VDSPrice"];

            Items.IsOffer = (int)reader["IsOffer"];
            if (Convert.IsDBNull(reader["OfferProduct"]))
                Items.OfferProduct = null;
            else
                Items.OfferProduct = (string)reader["OfferProduct"];

            return Items;
        }
        internal static TmpRPProductsItemsOP tmpRPProductsItemsItemFactory(SqlDataReader reader)
        {
            TmpRPProductsItemsOP Items = new TmpRPProductsItemsOP();

            if (Convert.IsDBNull(reader["result"]))
                Items.result = null;
            else
                Items.result = (string)reader["result"];

            Items.Pid = (Int32)reader["Pid"];

            if (Convert.IsDBNull(reader["Pcode"]))
                Items.Pcode = null;
            else
                Items.Pcode = (string)reader["Pcode"];

            if (Convert.IsDBNull(reader["PName"]))
                Items.PName = null;
            else
                Items.PName = (string)reader["PName"];

            Items.Qty = (Int32)reader["Qty"];
            Items.AvailQty = (Int32)reader["AvailQty"];
            Items.MRP = (decimal)reader["MRP"];
            Items.DP = (decimal)reader["DP"];
            Items.TotalDP = (decimal)reader["TotalDP"];
            Items.BasicPrice = (decimal)reader["BasicPrice"];
            Items.TotalBasicPrice = (decimal)reader["TotalBasicPrice"];
            Items.OfferDiscPer = (decimal)reader["OfferDiscPer"];
            Items.OfferBP = (decimal)reader["OfferBP"];
            Items.TotalOfferBP = (decimal)reader["TotalOfferBP"];
            Items.OfferDiscountAmt = (decimal)reader["OfferDiscountAmt"];
            Items.TotalOfferDiscountAmt = (decimal)reader["TotalOfferDiscountAmt"];
            Items.DiscountPer = (decimal)reader["DiscountPer"];
            Items.BP = (decimal)reader["BP"];
            Items.TotalBP = (decimal)reader["TotalBP"];
            Items.DiscountAmt = (decimal)reader["DiscountAmt"];
            Items.TotalDiscountAmt = (decimal)reader["TotalDiscountAmt"];
            Items.VAT = (decimal)reader["VAT"];
            Items.BV = (decimal)reader["BV"];
            Items.TotalBV = (decimal)reader["TotalBV"];
            Items.PV = (decimal)reader["PV"];
            Items.TotalPV = (decimal)reader["TotalPV"];
            Items.TaxAmt = (decimal)reader["TaxAmt"];

            if (Convert.IsDBNull(reader["TaxType"]))
                Items.TaxType = null;
            else
                Items.TaxType = (string)reader["TaxType"];

            Items.CCharges = (decimal)reader["CCharges"];

            Items.IsPackage = (Boolean)reader["IsPackage"];

            Items.IsOffer = (int)reader["IsOffer"];

            return Items;
        }
        internal static SalesInvoiceOP SalesInvoiceItemFactory(SqlDataReader reader)
        {
            SalesInvoiceOP Items = new SalesInvoiceOP();

            if (Convert.IsDBNull(reader["Billno"]))
                Items.Billno = null;
            else
                Items.Billno = (string)reader["Billno"];

            if (Convert.IsDBNull(reader["Result"]))
                Items.Result = null;
            else
                Items.Result = (string)reader["Result"];

            return Items;
        }
        internal static UserReport_OutPut DeleteItemFactory(SqlDataReader reader)
        {
            UserReport_OutPut Items = new UserReport_OutPut();

            if (Convert.IsDBNull(reader["result"]))
                Items.result = null;
            else
                Items.result = (string)reader["result"];

            return Items;
        }
        internal static UserReport_OutPut UserReportItemFactory(SqlDataReader reader)
        {

            UserReport_OutPut Items = new UserReport_OutPut();
            Items.CreatedBy = (Int32)reader["CreatedBy"];
            Items.Uid = (Int32)reader["Uid"];
            Items.StateId = (Int32)reader["StateId"];

            if (Convert.IsDBNull(reader["Flag"]))
                Items.Flag = null;
            else
                Items.Flag = (string)reader["Flag"];

            if (Convert.IsDBNull(reader["Name"]))
                Items.Name = null;
            else
                Items.Name = (string)reader["Name"];
            if (Convert.IsDBNull(reader["Mobile"]))
                Items.Mobile = null;
            else
                Items.Mobile = (string)reader["Mobile"];

            if (Convert.IsDBNull(reader["Address1"]))
                Items.Address1 = null;
            else
                Items.Address1 = (string)reader["Address1"];

            if (Convert.IsDBNull(reader["Address2"]))
                Items.Address2 = null;
            else
                Items.Address2 = (string)reader["Address2"];

            if (Convert.IsDBNull(reader["Address3"]))
                Items.Address3 = null;
            else
                Items.Address3 = (string)reader["Address3"];

            if (Convert.IsDBNull(reader["City"]))
                Items.City = null;
            else
                Items.City = (string)reader["City"];

            if (Convert.IsDBNull(reader["State"]))
                Items.State = null;
            else
                Items.State = (string)reader["State"];

            if (Convert.IsDBNull(reader["Pincode"]))
                Items.Pincode = 0;
            else
                Items.Pincode = (Int32)reader["Pincode"];

            if (Convert.IsDBNull(reader["Email"]))
                Items.Email = null;
            else
                Items.Email = (string)reader["Email"];

            if (Convert.IsDBNull(reader["UserName"]))
                Items.UserName = null;
            else
                Items.UserName = (string)reader["UserName"];

            if (Convert.IsDBNull(reader["PassWord"]))
                Items.PassWord = null;
            else
                Items.PassWord = (string)reader["PassWord"];
            if (Convert.IsDBNull(reader["pstatus"]))
                Items.pstatus = 0;
            else
                Items.pstatus = (byte)reader["pstatus"];

            return Items;
        }
        internal static Result resultItemFactory(SqlDataReader reader)
        {
            Result Items = new Result();

            if (Convert.IsDBNull(reader["result"]))
                Items.result = null;
            else
                Items.result = (string)reader["result"];

            return Items;
        }
        internal static GetStockOrderReq GetStockOrderReqItemFactory(SqlDataReader reader)
        {
            GetStockOrderReq items = new GetStockOrderReq();

            items.slno = (Int32)reader["slno"];
            if (Convert.IsDBNull(reader["RefNo"]))
                items.RefNo = null;
            else
                items.RefNo = (string)reader["RefNo"];

            if (Convert.IsDBNull(reader["RefDate"]))
                items.RefDate = null;
            else
                items.RefDate = (string)reader["RefDate"];


            if (Convert.IsDBNull(reader["Fcode"]))
                items.Fcode = null;
            else
                items.Fcode = (string)reader["Fcode"];

            if (Convert.IsDBNull(reader["fname"]))
                items.fname = null;
            else
                items.fname = (string)reader["fname"];

            if (Convert.IsDBNull(reader["Packcode"]))
                items.Packcode = null;
            else
                items.Packcode = (string)reader["Packcode"];

            items.qty = (Int32)reader["qty"];

            items.NetAmt = (decimal)reader["NetAmt"];
            items.TotBV = (decimal)reader["TotBV"];

            if (Convert.IsDBNull(reader["Remarks"]))
                items.Remarks = null;
            else
                items.Remarks = (string)reader["Remarks"];

            if (Convert.IsDBNull(reader["status"]))
                items.status = null;
            else
                items.status = (string)reader["status"];

            if (Convert.IsDBNull(reader["InvNo"]))
                items.InvNo = null;
            else
                items.InvNo = (string)reader["InvNo"];

            if (Convert.IsDBNull(reader["InvDate"]))
                items.InvDate = null;
            else
                items.InvDate = (string)reader["InvDate"];

            if (Convert.IsDBNull(reader["VerifyNo"]))
                items.VerifyNo = null;
            else
                items.VerifyNo = (string)reader["VerifyNo"];

            if (Convert.IsDBNull(reader["VerifyDate"]))
                items.VerifyDate = null;
            else
                items.VerifyDate = (string)reader["VerifyDate"];

            if (Convert.IsDBNull(reader["ReturnType"]))
                items.ReturnType = null;
            else
                items.ReturnType = (string)reader["ReturnType"];
            if (Convert.IsDBNull(reader["OffWallAmt"]))
                items.OffWallAmt = 0;
            else
                items.OffWallAmt = (decimal)reader["OffWallAmt"];
            return items;
        }
        internal static Batchwisedata GetBatchwisestockItemFactory(SqlDataReader reader)
        {
            Batchwisedata items = new Batchwisedata();

            items.Pid = (Int32)reader["Pid"];
            items.AQty = (Int32)reader["AQty"];
            items.Avlqty = (Int32)reader["Avlqty"];
            items.OrdQty = (Int32)reader["OrdQty"];

            if (Convert.IsDBNull(reader["expdate"]))
                items.expdate = null;
            else
                items.expdate = (string)reader["expdate"];
            if (Convert.IsDBNull(reader["mgdate"]))
                items.mgdate = null;
            else
                items.mgdate = (string)reader["mgdate"];

            if (Convert.IsDBNull(reader["Batchno"]))
                items.Batchno = null;
            else
                items.Batchno = (string)reader["Batchno"];

            items.MRP = (decimal)reader["MRP"];
            items.AP = (decimal)reader["AP"];
            items.BV = (decimal)reader["BV"];
            items.Rate = (decimal)reader["Rate"];

            if (Convert.IsDBNull(reader["pcode"]))
                items.pcode = null;
            else
                items.pcode = (string)reader["pcode"];

            if (Convert.IsDBNull(reader["pname"]))
                items.pname = null;
            else
                items.pname = (string)reader["pname"];
            return items;
        }
        internal static GetProductBatchnoDates GetProductBatchnoDatesItemFactory(SqlDataReader reader)
        {
            GetProductBatchnoDates items = new GetProductBatchnoDates();

            if (Convert.IsDBNull(reader["MgDate"]))
                items.MgDate = null;
            else
                items.MgDate = (string)reader["MgDate"];

            if (Convert.IsDBNull(reader["Expdate"]))
                items.Expdate = null;
            else
                items.Expdate = (string)reader["Expdate"];

            return items;
        }
        internal static StockOrderAvalQty StockOrderAvalQtyItemFactory(SqlDataReader reader)
        {
            StockOrderAvalQty items = new StockOrderAvalQty();


            if (Convert.IsDBNull(reader["ProductCode"]))
                items.ProductCode = null;
            else
                items.ProductCode = (string)reader["ProductCode"];

            items.OrderQty = (Int32)reader["OrderQty"];

            items.BalanceQty = (Int32)reader["BalanceQty"];

            return items;
        }
        internal static GetCustomers_OP GetCustomerFactory(SqlDataReader reader)
        {
            var customer = new GetCustomers_OP();

            customer.CustomerID = (int)reader["CustomerID"];
            customer.CustomerName = reader["CustomerName"] as string;
            customer.MobileNumber = reader["MobileNumber"] as string;
            customer.Email = reader["Email"] as string;
            customer.AadhaarNumber = reader["AadhaarNumber"] as string;
            customer.AadhaarImagePath = reader["AadhaarImagePath"] as string;
            customer.PANNumber = reader["PANNumber"] as string;
            customer.PANImagePath = reader["PANImagePath"] as string;
            customer.CustomerCode = reader["CustomerCode"] as string;
            customer.Status = (int)reader["Status"];

            if (Convert.IsDBNull(reader["CreatedDate"]))
                customer.CreatedDate = null;
            else
                customer.CreatedDate = (DateTime)reader["CreatedDate"];

            return customer;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class CancelInvoice_IP
    {
        public string Action { get; set; }
        public string InvNo { get; set; }
        public string Remarks { get; set; } = string.Empty;
        public string CanBy { get; set; }
    }
    public class CancelInvoice_OP
    {
        public string Result { get; set; }
        public string Idno { get; set; }
        public string InvNo { get; set; }
        public string InvDate { get; set; }
        public decimal TotBV { get; set; }
        public decimal NetAmt { get; set; }
        public string OrdType { get; set; }
        public string BillType { get; set; }
        public decimal OfferDiscountAmt { get; set; }
    }
    public class CancelInvoiceReport_IP
    {
        public string Action { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string Id { get; set; } = "";
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 100;
        public string SearchText { get; set; } = "";
    }
    public class CancelInvoiceReport_OP
    {
        public int TotalRecords { get; set; }
        public string InvoiceNo { get; set; } = "";
        public string FranchiseCode { get; set; } = "";
        public string ARCode { get; set; } = "";
        public string InvoiceDate { get; set; } = "";
        public decimal TotalBV { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; } = "";
        public string CancelledBy { get; set; } = "";
        public string BillCancelDate { get; set; } = "";
        public string Status { get; set; } = "";
    }
    public class CancelInvoiceReportResponse
    {
        public int TotalRecords { get; set; }
        public List<CancelInvoiceReport_OP> Data { get; set; } = new();
    }
}

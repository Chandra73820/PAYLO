using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class HamrovedaSalesReport_IP
    {
        public string FromDate { get; set; } = string.Empty;
        public string ToDate { get; set; } = string.Empty;
    }
    public class HamrovedaSalesReport_OP
    {
        public string BillNo { get; set; } = string.Empty;

        public string BillDate { get; set; } = string.Empty;

        public string BuyerType { get; set; } = string.Empty;

        public string TaxType { get; set; } = string.Empty;

        public string BuyerName { get; set; } = string.Empty;

        public string BuyerState { get; set; } = string.Empty;

        public string BuyerDistrict { get; set; } = string.Empty;

        public string BuyerCity { get; set; } = string.Empty;

        public string BuyerGSTNo { get; set; } = string.Empty;

        public decimal BV { get; set; }

        public decimal PV { get; set; }

        public decimal TaxableAmount { get; set; }

        public decimal CGST { get; set; }

        public decimal SGST { get; set; }

        public decimal IGST { get; set; }

        public decimal NetAmount { get; set; }

        public decimal TaxAmt0igst { get; set; }

        public decimal TaxAmt0gp { get; set; }

        public decimal TaxAmt5igst { get; set; }

        public decimal TaxAmt5gp { get; set; }

        public decimal TaxAmt12igst { get; set; }

        public decimal TaxAmt12gp { get; set; }

        public decimal TaxAmt13igst { get; set; }

        public decimal TaxAmt13gp { get; set; }

        public decimal OffWallAmt { get; set; }
    }
}

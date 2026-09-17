using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class HamrovedaPurchaseReport_IP
    {
        public string FromDate { get; set; } = string.Empty;
        public string ToDate { get; set; } = string.Empty;
    }
    public class HamrovedaPurchaseReport_OP
    {
        public string BillNo { get; set; } = string.Empty;

        public string BillDate { get; set; } = string.Empty;

        public string Sellertype { get; set; } = string.Empty;

        public string TaxType { get; set; } = string.Empty;

        public string Vendorname { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string GSTIN { get; set; } = string.Empty;

        public decimal TaxableAmount { get; set; }

        public decimal IGST { get; set; }

        public decimal NetAmt { get; set; }

        public decimal TaxAmt0igst { get; set; }

        public decimal TaxAmt0gp { get; set; }

        public decimal TaxAmt5igst { get; set; }

        public decimal TaxAmt5gp { get; set; }

        public decimal TaxAmt12igst { get; set; }

        public decimal TaxAmt12gp { get; set; }

        public decimal TaxAmt13igst { get; set; }

        public decimal TaxAmt13gp { get; set; }
    }
}

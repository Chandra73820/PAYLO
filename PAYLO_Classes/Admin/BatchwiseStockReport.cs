using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class BatchwiseStockReport_IP
    {
        public string action { get; set; } = string.Empty;
        public string CFACode { get; set; } = string.Empty;
    }
    public class BatchwiseStockReport_OP
    {
        public int Pid { get; set; } 

        public string pcode { get; set; } = string.Empty;

        public string pname { get; set; } = string.Empty;
        public decimal MRP { get; set; }

        public decimal BV { get; set; }

        public decimal AP { get; set; }

        public decimal Rate { get; set; }

        public string Batchno { get; set; } = string.Empty;

        public string mgdate { get; set; } = string.Empty;

        public string expdate { get; set; } = string.Empty;

        public int Avlqty { get; set; }
    }
}

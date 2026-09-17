using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Common
{
    public class CommonOutput
    {
        public string? Result { get; set; }
        public string? Message { get; set; }
        //public string? RefNo { get; set; }
        //public string? InvNo { get; set; }
    }
    public class Result
    {
        public string result { get; set; }
    }
    public class GetReceiptIP
    {
        public string action { get; set; }
        public string refno { get; set; }
    }

}

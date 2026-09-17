using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes
{
    public class StockOrder
    {
        public string Result { get; set; }
        public string RefNo { get; set; }
    }
    public class StockOrderIP
    {
        public string action { get; set; }
        public string Id { get; set; }
        public string Remarks { get; set; }
        public string jsonData { get; set; }
        public string Sessid { get; set; }
        public Int32 ReqTo { get; set; }
        public string OrderType { get; set; }

    }
}

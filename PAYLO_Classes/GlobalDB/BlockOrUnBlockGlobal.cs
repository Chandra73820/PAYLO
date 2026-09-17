using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.GlobalDB
{
    public class BlockOrUnBlockGlobal_IP
    {
        public int regid { get; set; }
        public int status { get; set; }
        public string remarks { get; set; } = string.Empty;
        public int thru { get; set; }
        public string filename { get; set; } = string.Empty;
        public string Sesid { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
    }
}

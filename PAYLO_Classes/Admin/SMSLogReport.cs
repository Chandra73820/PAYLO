using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class SMSLogReport_IP
    {
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
    }
    public class SMSLogReport_OP
    {
        public string HRID { get; set; } = "";
        public string Name { get; set; } = "";
        public string Mobile { get; set; } = "";
        public string Message { get; set; } = "";
        public string SMSType { get; set; } = "";
        public string SendDate { get; set; } = "";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class UserLoginReport_IP
    {
        public string FromDate { get; set; } = string.Empty;
        public string ToDate { get; set; } = string.Empty;
        public int UserID { get; set; } = 0;
    }

    public class UserLoginReport_OP
    {
        public string UserName { get; set; } = string.Empty;
        public string IPAddress { get; set; } = string.Empty;
        public string UserAgent { get; set; } = string.Empty;
        public string LoginDateTime { get; set; } = string.Empty;
        public string LoginStatus { get; set; } = string.Empty;
        public string FailReason { get; set; } = string.Empty;
    }
}

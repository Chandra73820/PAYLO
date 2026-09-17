using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.GlobalDB
{
    public class UserIDChangeGlobal_IP
    {
        public int Regid { get; set; }
        public string OldIdno { get; set; } = string.Empty;
        public string NewIdno { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public int GlobalUserId { get; set; }
        public string Session { get; set; } = string.Empty;
        public string IPAddress { get; set; } = string.Empty;
        public string RegFrom { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
    }
    public class UserIDChangeFromIndia_IP
    {
        public int Regid { get; set; }
        public string OldIdno { get; set; } = string.Empty;
        public string NewIdno { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public int GlobalUserId { get; set; }
        public string Session { get; set; } = string.Empty;
        public string IPAddress { get; set; } = string.Empty;
        public string RegFrom { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public int SprCnt { get; set; }
        public int RefCnt { get; set; }
    }
}

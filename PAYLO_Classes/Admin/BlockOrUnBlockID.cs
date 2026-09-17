using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class BlockOrUnBlockID_IP
    {
        public int regid { get; set; }
        public int status { get; set; }
        public string remarks { get; set; } = string.Empty;
        public int thru { get; set; }
        public string filename { get; set; } = string.Empty;
        public string Sesid { get; set; } = string.Empty;
        public string NewUserId { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
    }

    public class BlockOrUnBlockID_OP
    {
        public int regId { get; set; }

        public string actionType { get; set; } = string.Empty;

        public int newStatus { get; set; }

        public string remarks { get; set; } = string.Empty;

        public string result { get; set; } = string.Empty;
    }
    public class BlockOrUnBlockIDNew_IP
    {
        public int Regid { get; set; }
        public string Remarks { get; set; } = string.Empty;
        public int Thru { get; set; }
        public string Sesid { get; set; } = string.Empty;
        public int Status { get; set; }
        public string Action { get; set; } = string.Empty;
        public string NewUserId { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;

    }
    public class CommonResponse
    {
        public string result { get; set; } = string.Empty;
    }
}

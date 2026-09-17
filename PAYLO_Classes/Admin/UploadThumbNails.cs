using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class UploadThumbNails_IP
    {
        public string Action { get; set; } = "";

        public int PID { get; set; }

        public string ThumbFileName { get; set; } = "";

        public int Status { get; set; }

        public int CreatedBy { get; set; }

        public string IPAddress { get; set; } = "";

        public string SessionID { get; set; } = "";

        public int UploadTID { get; set; }
    }
    public class UploadThumbNails_OP
    {
        public int UploadTID { get; set; }

        public int PID { get; set; }

        public string ProductName { get; set; } = "";

        public string ProductCode { get; set; } = "";

        public string ThumbFileName { get; set; } = "";

        public string CreatedOn { get; set; } = "";

        public string Status { get; set; } = "";

        public int IsActive { get; set; }

        public string Result { get; set; } = "";
    }
}

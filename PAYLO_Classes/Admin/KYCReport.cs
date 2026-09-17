using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class MemberKycReport_IP
    {
        public string Action { get; set; } = "";

        public string FromDate { get; set; } = "";

        public string ToDate { get; set; } = "";

        public decimal regid { get; set; }

        public int status { get; set; } = -1;

        public int updatedby { get; set; }

        public string Remarks { get; set; } = "";
    }
    public class MemberKycReport_OP
    {
        public string Result { get; set; } = "";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Associate
{
    public class PANDetails_IP
    {
        public string Action { get; set; } = "";

        public decimal Regid { get; set; }

        public string PANCardNo { get; set; } = "";

        public string PANPhoto { get; set; } = "";

        //public string NameAsPerKYC { get; set; } = "";

        public string Remarks { get; set; } = "";

        public int UpdatedBy { get; set; }
    }

    public class PANDetails_OP
    {
        public string Result { get; set; } = "";
    }

    public class PANDetailsStatus_OP
    {
        public int Reqsts { get; set; }

        public string Remarks { get; set; } = "";

        public string PANCardNo { get; set; } = "";

        public string PANPhoto { get; set; } = "";

        //public string NameAsPerKYC { get; set; } = "";
    }
}

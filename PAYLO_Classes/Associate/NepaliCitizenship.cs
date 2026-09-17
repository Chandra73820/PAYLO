using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Associate
{
    public class NepaliCitizenship_IP
    {
        public string Action { get; set; } = "";
        public decimal regid { get; set; }
        public string filename { get; set; } = "";
        public string IdProofType { get; set; } = "";
        public string CitizenshipNo { get; set; } = "";
        public int updatedby { get; set; }
        public string Remarks { get; set; } = "";
    }

    public class NepaliCitizenship_OP
    {
        public string Result { get; set; } = "";
    }
    public class CitizenshipStatus_OP
    {
        public int Reqsts { get; set; }

        public string Remarks { get; set; } = "";
        public string IdProofType { get; set; } = "";

        public string CitizenshipNo { get; set; } = "";

        public string CitizenshipImage { get; set; } = "";
    }
    public class CitizenshipPendingReport_OP
    {
        public int MPID { get; set; }

        public decimal Regid { get; set; }

        public string Idno { get; set; } = "";

        public string Name { get; set; } = "";
        public string IdProofType { get; set; } = "";

        public string CitizenshipNo { get; set; } = "";

        public string CitizenshipImage { get; set; } = "";

        public string RequestDate { get; set; } = "";

        public string Remarks { get; set; } = "";

        public int Reqsts { get; set; }
    }
}

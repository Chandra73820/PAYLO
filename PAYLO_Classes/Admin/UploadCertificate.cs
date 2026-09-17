using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class UploadCertificate_IP
    {
        public string Action { get; set; } = "";

        public int CID { get; set; }

        public string CertificateName { get; set; } = "";

        public string UploadNewImage { get; set; } = "";

        public int CreatedBy { get; set; }

        public int UpdatedBy { get; set; }

        public int Status { get; set; }

        public string IPAddress { get; set; } = "";

        public string Session { get; set; } = "";
    }
}

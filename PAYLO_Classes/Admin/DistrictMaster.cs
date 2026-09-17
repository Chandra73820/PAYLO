using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class DistrictMaster_IP
    {
        public string Action { get; set; } = "";
        public int DistrictID { get; set; }
        public int StateID { get; set; }
        public string DistrictName { get; set; } = "";
        public int DStatus { get; set; }
        public int AddedBy { get; set; }
        public int ModifiedBy { get; set; }
        public string IpAddress { get; set; } = "";
    }

    public class DistrictMaster_OP
    {
        public bool Status { get; set; }
        public string Message { get; set; } = "";
        public int? DistrictID { get; set; }
    }

    public class DistrictMasterReport_OP
    {
        public int DistrictID { get; set; }
        public int StateID { get; set; }
        public string StateName { get; set; } = "";
        public string DistrictName { get; set; } = "";
        public string DStatus { get; set; } = "";
        public string AddedOn { get; set; } = "";
        public string EditedOn { get; set; } = "";
    }
}

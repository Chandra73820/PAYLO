using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class PincodeMaster_IP
    {
        public string Action { get; set; } = "";
        public int PinID { get; set; }
        public int StateID { get; set; }
        public int DistrictID { get; set; }
        public int PinCode { get; set; }
        public int PinStatus { get; set; }
        public int AddedBy { get; set; }
        public int ModifiedBy { get; set; } 
        public string IpAddress { get; set; } = "";
    }
    public class PincodeMaster_OP
    {
        public bool Status { get; set; }
        public string Message { get; set; } = "";
        public int? PinID { get; set; }
    }
    public class PincodeMasterReport_OP
    {
        public int PinID { get; set; }
        public int StateID { get; set; }
        public string StateName { get; set; } = "";
        public int DistrictID { get; set; }
        public string DistrictName { get; set; } = "";
        public int PinCode { get; set; }
        public string PinStatus { get; set; } = "";
        public string AddedOn { get; set; } = "";
        public string EditedOn { get; set; } = "";
    }
}

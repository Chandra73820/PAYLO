using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class UnitMaster_IP
    {
        public string Action { get; set; }
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public string ShortName { get; set; }
        public int Status { get; set; }
        public int AddedBy { get; set; }
        public string IPAddress { get; set; }
        public string SessionID { get; set; }
    }
    public class UnitMaster_OP
    {
        public string UnitName { get; set; }
        public string ShortName { get; set; }
        public int UnitId { get; set; }
        public int Status { get; set; }
        public string Remarks { get; set; }
        public string PStatus { get; set; }
    }
}

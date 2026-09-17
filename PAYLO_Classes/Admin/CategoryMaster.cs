using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class CategoryMaster_IP
    {
        public string Action { get; set; }
        public Int32 Id { get; set; }
        public string CategoryName { get; set; } = "";
        public string Description { get; set; } = "";
        public string Image { get; set; } = "";
        public int Addedby { get; set; }
        public Int32 Status { get; set; }
        public string IpAdd { get; set; } = "";
        public string SessionID { get; set; } = "";
    }
}

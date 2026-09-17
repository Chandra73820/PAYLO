using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class ProductAttributeOption_IP
    {
        public string Action { get; set; } = "";

        public int OptionID { get; set; }

        public int AttributeID { get; set; }

        public string OptionCode { get; set; } = "";

        public string OptionValue { get; set; } = "";

        public int AddedBy { get; set; }

        public int OptionIsActive { get; set; }

        public string IPAddress { get; set; } = "";

        public string SessionID { get; set; } = "";
    }
}

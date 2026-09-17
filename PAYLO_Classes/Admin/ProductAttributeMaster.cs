using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class ProductAttribute_IP
    {
        public string Action { get; set; } = "";

        public int AttributeID { get; set; }

        public string AttributeCode { get; set; } = "";

        public string AttributeName { get; set; } = "";

        public int AddedBy { get; set; }

        public int AttributeIsActive { get; set; }

        public string IPAddress { get; set; } = "";

        public string SessionID { get; set; } = "";
    }
}

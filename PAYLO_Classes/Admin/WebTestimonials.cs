using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class WebTestimonials_IP
    {
        public string Action { get; set; } = "";

        public int WTID { get; set; }

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public string Image { get; set; } = "";

        public string Link { get; set; } = "";

        public decimal Rating { get; set; }

        public int Status { get; set; }

        public int AddedBy { get; set; }

        public int UpdatedBy { get; set; }

        public string SessionID { get; set; } = "";

        public string IPAddress { get; set; } = "";
    }
}

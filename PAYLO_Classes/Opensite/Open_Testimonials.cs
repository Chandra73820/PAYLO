using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Opensite
{
    public class Open_Testimonials_IP
    {
        public string Action { get; set; }
    }
    public class Open_Testimonials_OP
    {
        public int WTID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Link { get; set; }
        public decimal Rating { get; set; }
    }
}
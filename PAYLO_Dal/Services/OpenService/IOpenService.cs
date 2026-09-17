using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAYLO_Classes.Admin;
using PAYLO_Classes.Associate;
using PAYLO_Classes.Opensite;

namespace PAYLO_Dal
{
    public interface IOpenService 
    {
        public string ProductDetails(string environment, OpenProductDetailsIP obj);
        public string TestimonialDetails(string environment, Open_Testimonials_IP obj);
        string ContactUs(string environment, ContactUs_IP obj);
    }
}

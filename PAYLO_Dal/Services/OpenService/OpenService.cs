using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAYLO_Classes.Admin;
using PAYLO_Classes.Opensite;
using PAYLO_Dal.CommandFactories;

namespace PAYLO_Dal
{
    public class OpenService:IOpenService
    {
        public string ProductDetails(string environment, OpenProductDetailsIP obj)
        {
            return SqlHelpers.GetObjects(environment, OpenCommandFactory.ProductDetails(obj));
        }
        public string ContactUs(string environment, ContactUs_IP obj)
        {
            return SqlHelpers.GetObjects(environment, OpenCommandFactory.ContactUs(obj));
        }
        public string TestimonialDetails(string environment, Open_Testimonials_IP obj)
        {
            return SqlHelpers.GetObjects(environment, OpenCommandFactory.TestimonialDetails(obj));
        }
    }
}

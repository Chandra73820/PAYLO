using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Opensite
{
    public class ContactUs_IP
    {
        public string Action { get; set; } = "";

        public string FullName { get; set; } = "";

        public string EmailAddress { get; set; } = "";

        public string MobileNumber { get; set; } = "";

        public string City { get; set; } = "";

        public string Message { get; set; } = "";

        public string IPAddress { get; set; } = "";
        public string DateType { get; set; } = "";
        public string OnDate { get; set; } = "";

        public string FromDate { get; set; } = "";

        public string ToDate { get; set; } = "";

        public int Status { get; set; } = -1;
    }
}

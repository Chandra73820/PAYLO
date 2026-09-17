using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes
{
    public class VendorReport_IP
    {
        public string Action { get; set; }
        public Int32 Vid { get; set; }
        public Int32 Deletedby { get; set; }
    }
    public class VendorCreation_IP
    {
        public string Vid { get; set; }
        public string Action { get; set; }
        public string Name { get; set; }
        public string Cperson { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Mobile { get; set; }
        public string AltMobile { get; set; }
        public string Email { get; set; }
        public string PanCard { get; set; }
        public string Accno { get; set; }
        public string IFSC { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string GST { get; set; }
        public string TIN { get; set; }
        public string CIN { get; set; }
        public string Status { get; set; }
        public string Sesid { get; set; }
        public int CreatedBy { get; set; }
    }
    public class CommonMessage
    {
        public string? Message { get; set; }

        public string? Result { get; set; }
    }
}

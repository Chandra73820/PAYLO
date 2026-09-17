
namespace PAYLO_Classes.Admin
{
    public class GetCustomers_OP
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string AadhaarNumber { get; set; }
        public string AadhaarImagePath { get; set; }
        public string PANNumber { get; set; }
        public string PANImagePath { get; set; }
        public string CustomerCode { get; set; }
        public int Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

    }

    public class CustomerMaster_IP : Session_IPAdd
    {
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string AadhaarNumber { get; set; }
        public string PANNumber { get; set; }
        public int Status { get; set; }
        public string AadhaarImagePath { get; set; }
        public string PANImagePath { get; set; }
        public string AadhaarImage { get; set; }
        public string PanImage { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}



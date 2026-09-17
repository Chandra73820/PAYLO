using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class RegistrationReport_IP
    {
        public string Action { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string Id { get; set; } = "";
        public int CountryId { get; set; } = 0;
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 100;
        public string SearchText { get; set; } = "";
    }

    public class RegistrationReport
    {
        public string Idno { get; set; } = "";
        public string Name { get; set; } = "";
        public string Mobile { get; set; } = "";
        public string State { get; set; } = "";
        public string City { get; set; } = "";
        public string TEHSIL { get; set; } = "";
        public string District { get; set; } = "";
        public string Joindate { get; set; } = "";
        public string Activedate { get; set; } = "";
        public string Sponsor { get; set; } = "";
        public string SponserID { get; set; } = "";
        public string ReferralID { get; set; } = "";
        public string Status { get; set; } = "";
        public string Photo { get; set; } = "";
        public string Aadhaar { get; set; } = "";
        public string AadhaarCardNo { get; set; } = "";
        public string IdProofType { get; set; } = "";
    }

    public class RegistrationReport_GBL
    {

        public int TotalRecords { get; set; }
        public string UserCode { get; set; } = "";
        public string UserName { get; set; } = "";
        public string CountryCode { get; set; } = "";
        public string CountryName { get; set; } = "";
        public string JoinDate { get; set; } = "";
        public string ActiveDate { get; set; } = "";
        public string Regid { get; set; } = "";
        public string Sponsor { get; set; } = "";
        public string SponsorFrom { get; set; } = "";      
        public string Referral { get; set; } = "";
        public string ReferralFrom { get; set; } = "";
        public string SponsorID { get; set; } = "";
        public string ReferralID { get; set; } = "";
        public string Status { get; set; } = "";
        public string Rank { get; set; } = "";
        public string CreatedDate { get; set; } = "";
        public string IpAddress { get; set; } = "";
    }
    public class RegistrationReportResponse_GBL
    {
        public int TotalRecords { get; set; }
        public List<RegistrationReport_GBL> Data { get; set; } = new();
    }
}

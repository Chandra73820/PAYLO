using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Associate
{
    public class MemberDashboard_IP
    {
        public string OnDate { get; set; } = "";
        public long RegId { get; set; }
    }

    public class MemberDashboardViewModel
    {
        public long RegId { get; set; }
        public string AssociateId { get; set; } = "";
        public string AssociateName { get; set; } = "";
        public string Mobile { get; set; } = "";
        public string JoiningDate { get; set; } = "";
        public string Status { get; set; } = "";
        public string Rank { get; set; } = "";
        public string Photo { get; set; } = "";
        public decimal Pbv { get; set; }
        public decimal Gbv { get; set; }
        public decimal Tbv { get; set; }
        public KycViewModel Kyc { get; set; } = new();
    }

    public class KycViewModel
    {
        public string Bank { get; set; } = "";
        public string Pan { get; set; } = "";
        public string Citizenship { get; set; } = "";
        public string Photo { get; set; } = "";
    }

}

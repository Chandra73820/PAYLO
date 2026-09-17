using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.GlobalDB
{
    public class ReferralReport_IP
    {
        public string UserID { get; set; } = "";
        public string FromDate { get; set; } = "";
        public string ToDate { get; set; } = "";
        public string RegFrom { get; set; } = "";
        public string Type { get; set; } = "";
        public int PayNo { get; set; }
        public string SearchFrom { get; set; } = "";
        public string MainID { get; set; } = "";
        public int IncludeBV { get; set; }
    }

    public class ReferralReport_OP
    {
        public string IdType { get; set; } = "";
        public int Sno { get; set; }
        public string UserID { get; set; } = "";
        public string ActualUserID { get; set; } = "";
        public string Name { get; set; } = "";
        public string Mobile { get; set; } = "";
        public string Status { get; set; } = "";
        public string Rank { get; set; } = "";
        public int DirectReferrals { get; set; }
        public int TeamRecruits { get; set; }
        public int TotalRecruits { get; set; }
        public string ImagePath { get; set; } = "";
        public int IsLock { get; set; }
        public int DesgNo { get; set; }
    }
}

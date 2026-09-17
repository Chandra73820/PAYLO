using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Associate
{
    public class BankDetails_IP
    {
        public string Action { get; set; } = "";

        public decimal Regid { get; set; }

        public string AccountNumber { get; set; } = "";

        public string IFSCCode { get; set; } = "";

        public string NameAsPerBank { get; set; } = "";

        //public string BankName { get; set; } = "";

        //public string BranchName { get; set; } = "";
        public int BankId { get; set; }

        public int BranchId { get; set; }

        public string AccountType { get; set; } = "";

        public string BankImage { get; set; } = "";

        public string Remarks { get; set; } = "";

        public int UpdatedBy { get; set; }
    }

    public class BankDetails_OP
    {
        public string Result { get; set; } = "";
    }

    public class BankDetailsStatus_OP
    {
        public int Reqsts { get; set; }

        public string Remarks { get; set; } = "";

        public string AccountNumber { get; set; } = "";

        public string IFSCCode { get; set; } = "";

        public string NameAsPerBank { get; set; } = "";

        public string BankName { get; set; } = "";

        public string BranchName { get; set; } = "";
        public int BankId { get; set; }

        public int BranchId { get; set; }
        public string AccountType { get; set; } = "";

        public string BankImage { get; set; } = "";
    }
}

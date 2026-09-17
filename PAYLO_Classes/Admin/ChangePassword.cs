using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Admin
{
    public class ChangePassword_IP
    {
        public string action { get; set; } = "";

        public int regid { get; set; }

        public string oldpwd { get; set; } = "";

        public string newpwd { get; set; } = "";

        public int thru { get; set; }
    }
    public class ChangePassword_OP
    {
        public string Result { get; set; } = "";
    }
}

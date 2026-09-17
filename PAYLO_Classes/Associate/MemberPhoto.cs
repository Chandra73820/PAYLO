using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Associate
{
    public class MemberPhoto_IP
    {
        public string Action { get; set; } = "";

        public decimal Regid { get; set; }

        public string MPhoto { get; set; } = "";

        public string Remarks { get; set; } = "";

        public int UpdatedBy { get; set; }
    }

    public class MemberPhoto_OP
    {
        public string Result { get; set; } = "";
    }

    public class MemberPhotoStatus_OP
    {
        public int Reqsts { get; set; }

        public string Remarks { get; set; } = "";

        public string MPhoto { get; set; } = "";
    }

    public class MemberPhotoPendingList_OP
    {
        public int MPID { get; set; }

        public decimal Regid { get; set; }

        public string Idno { get; set; } = "";

        public string Name { get; set; } = "";

        public string MPhoto { get; set; } = "";

        public string RequestDate { get; set; } = "";
    }
}

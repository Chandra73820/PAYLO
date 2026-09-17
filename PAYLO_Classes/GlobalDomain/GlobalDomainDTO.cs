using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.GlobalDomain
{
    public class GlobalDomainDTO : Session_IPAdd
    {
        public string FranchiseId { get; set; }

        public string PassKey { get; set; }

        public string UserType { get; set; }

        public string LoginFrom { get; set; }
        public string userAgent { get; set; }
    }
    public class GlobalDomainLoginIP: Session_IPAdd
    {
        public string DistributorId { get; set; }

        public string PassKey { get; set; }

        public string UserType { get; set; }

        public string LoginFrom { get; set; }
        public string userAgent { get; set; }
    }
}

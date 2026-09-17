using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Common
{
    public class UserDetails
    {

        public int regID { get; set; }
        public string memberID { get; set; }
        public string name { get; set; }
        public string msg { get; set; }
        public string accessToken { get; set; }
        public DateTime accessTokenExpiry { get; set; }
        public string sessionId { get; set; }
    }

}

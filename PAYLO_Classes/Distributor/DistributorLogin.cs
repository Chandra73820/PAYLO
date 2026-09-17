
using PAYLO_Classes.Enums;

namespace PAYLO_Classes
{
    public class DistributorLogin : Session_IPAdd
    {
        public string DistributorId { get; set; }

        public string PassKey { get; set; }
        
        public UserTypes UserType { get; set; }

        public LoginFrom LoginFrom { get; set; }

    }


    public class MobDistributorLogin : DistributorLogin
    {
        public int Version { get; set; }
        public string MobileInfo { get; set; }
        public string FCMID { get; set; }
        public bool? ISFCMChanged { get; set; }
    }
    public class SignupIP
    {
        public string JsonObj { get; set; }

        public string Idno { get; set; }

        public string RegMobile { get; set; }

        public string RegFrom { get; set; }
        public string IpAddrss { get; set; }

    }

    public class PincodeCheckIP
    {
        public string Action { get; set; }

        public string PinCode { get; set; }

    }


}

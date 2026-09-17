using PAYLO_Classes;
using PAYLO_Classes.Admin;
using PAYLO_Classes.Associate;
using PAYLO_Classes.Common;
using PAYLO_Classes.Distributor;
using PAYLO_Classes.GlobalDB;

namespace PAYLO_Dal
{
    public interface IDistributorService
    {
        /// <summary>
        /// Verify Distributor User exists or Not
        /// </summary>
        /// <param name="environment"><c>environment is Dev, Stag OR Prod</c></param>
        /// <param name="userName">MemberId no of the Logged Member</param>
        /// <param name="passKey">PassKey is password of the Logged Member</param>
        /// <returns></returns>

        public string VerifyDistributorLogin(string environment, AssociateLoginIP obj);

        public string VerifyMobDistributorLogin(string environment, MobDistributorLogin obj);
        string MemberDashboard(string environment, MemberDashboard_IP obj);
        public string PreferredCustomerProfileDetails(string environment, DistributorID obj);
        //public OpenReg_OP CheckOpeRegDownlineID(string environment, string MemberID, string DownMemberID);

        //public OpenRegDownlinecheck_OP CheckDownlineOpenSignup(string environment, string MemberID, string DownMemberID,string Placement);
        public string CustomerProfileDetails(string environment, DistributorID obj);
       
       
        public string GetAuthenticationDistributor(string environment, DistributorLogin obj);

        public string Signup(string environment, SignupIP obj);
        public string PincodeCheck(string environment, PincodeCheckIP obj);
        public string CheckUserInfo(string environment, CheckUserInfo_IP obj);
        public string SendOTP(string environment, SendOTP_IP obj);
        List<MemberProfile_OutPut> MemberProfile(string environment, MemberProfile_IP encInfo);
        string GetCitizenshipStatus(string environment,NepaliCitizenship_IP obj);
        string UploadCitizenshipRequest(string environment,NepaliCitizenship_IP obj);
        string UploadBankDetails(string environment, BankDetails_IP obj);
        string UploadPANDetails(string environment, PANDetails_IP obj);
        string UploadMemberPhoto(string environment,MemberPhoto_IP obj);
        string ForgotPassword(string environment, ForgotPassword_IP obj);
    }

}


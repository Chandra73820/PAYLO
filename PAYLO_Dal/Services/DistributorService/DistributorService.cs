using PAYLO_Classes;
using PAYLO_Classes.Admin;
using PAYLO_Classes.Associate;
using PAYLO_Classes.Common;
using PAYLO_Classes.Distributor;
using PAYLO_Classes.GlobalDB;
using PAYLO_Dal.CommandFactories;
using PAYLO_Dal.ItemFactories;


namespace PAYLO_Dal
{

    public class DistributorService : IDistributorService
    {
        public string VerifyDistributorLogin(string environment, AssociateLoginIP obj)
        {
            return SqlHelpers.GetValue<string>(environment, CommandFactory.VerifyDistributorLogin(obj));
        }

        public string VerifyMobDistributorLogin(string environment, MobDistributorLogin obj)
        {
            return SqlHelpers.GetValue<string>(environment, CommandFactory.VerifyMobDistributorLogin(obj));
        }

        public string MemberDashboard(string environment, MemberDashboard_IP obj)
        {
            return SqlHelpers.GetValue<string>(environment, CommandFactory.MemberDashboard(obj));
        }

        //public string ViewProfileDetails(string environment, DistributorID obj)
        //{
        //    return SqlHelpers.GetValue<string>(environment, CommandFactory.ViewProfileDetails(obj));

        //}
        //public string EditProfileData(string environment, DistEditProfileInput obj)
        //{
        //    return SqlHelpers.GetValue<string>(environment, CommandFactory.EditProfileData(obj));

        //}
        public string PreferredCustomerProfileDetails(string environment, DistributorID obj)
        {
            return SqlHelpers.GetValue<string>(environment, CommandFactory.PreferredCustomerProfileDetails(obj));

        }
     
        public string CustomerProfileDetails(string environment, DistributorID obj)
        {
            return SqlHelpers.GetValue<string>(environment, CommandFactory.CustomerProfileDetails(obj));

        }
       
        public string GetAuthenticationDistributor(string environment, DistributorLogin obj)
        {
            return SqlHelpers.GetValue<string>(environment, CommandFactory.GetAuthenticationDistributor(obj));
        }
        public string Signup(string environment, SignupIP obj)
        {
            return SqlHelpers.GetValue<string>(environment, CommandFactory.Signup(obj));
        }
        public string PincodeCheck(string environment, PincodeCheckIP obj)
        {
            return SqlHelpers.GetValue<string>(environment, CommandFactory.PincodeCheck(obj));
        }
        public string CheckUserInfo(string environment, CheckUserInfo_IP obj)
        {
            return SqlHelpers.GetValue<string>(environment, CommandFactory.CheckUserInfo(obj));
        }
        public string SendOTP(string environment, SendOTP_IP obj)
        {
            return SqlHelpers.GetValue<string>(environment, CommandFactory.SendOTP(obj));
        }
        public List<MemberProfile_OutPut> MemberProfile(string environment, MemberProfile_IP encInfo)
        {
            return SqlHelpers.GetObjects<MemberProfile_OutPut>(environment, CommandFactory.MemberProfile(encInfo),
                ObjectFactory.MemberProfileItemFactory);
        }
        public string GetCitizenshipStatus(string environment,NepaliCitizenship_IP obj)
        {
            return SqlHelpers.GetObjects(environment, CommandFactory.GetCitizenshipStatus(obj));
        }
        public string UploadCitizenshipRequest(string environment,NepaliCitizenship_IP obj)
        {
            return SqlHelpers.GetObjects(environment, CommandFactory.UploadCitizenshipRequest(obj));
        }
        public string UploadBankDetails(string environment, BankDetails_IP obj)
        {
            return SqlHelpers.GetObjects(environment, CommandFactory.UploadBankDetails(obj));
        }
        public string UploadPANDetails(string environment, PANDetails_IP obj)
        {
            return SqlHelpers.GetObjects(environment, CommandFactory.UploadPANDetails(obj));
        }
        public string UploadMemberPhoto(string environment,MemberPhoto_IP obj)
        {
            return SqlHelpers.GetObjects(environment,CommandFactory.UploadMemberPhoto(obj));
        }
        public string ForgotPassword(string environment, ForgotPassword_IP obj)
        {
            return SqlHelpers.GetValue<string>(environment, CommandFactory.ForgotPassword(obj));
        }
    }
}

using System.Data;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using PAYLO_Classes;
using PAYLO_Classes.Admin;
using PAYLO_Classes.Associate;
using PAYLO_Classes.Distributor;
using PAYLO_Classes.GlobalDB;

namespace PAYLO_Dal
{
    internal partial class CommandFactory
    {
        /// <summary>
        /// Get Sponser details using store procedure by id
        /// </summary>
        /// <returns></returns>



        internal static SqlCommand GetAuthenticationDistributor(DistributorLogin obj)
        {

            var parameters = new[]
            {
                CreateParameter("@MemberID", SqlDbType.VarChar,obj.DistributorId),
                CreateParameter("@password", SqlDbType.VarChar, obj.PassKey)
            };
            return CreateCommand("usp_Verify_Login", parameters);
        }



        /// <summary>
        /// Call the stroed procedure usp_Verify_Login and 
        /// get Distributor User Data
        /// </summary>
        /// <param name="userName">MemberId is string value of MemberId of the login Distributor User</param>
        /// <param name="passKey">passKey is string value of passKey of the login Distributor User</param>
        /// <returns><c>returns sqlcommand</c></returns>
        internal static SqlCommand VerifyDistributorLogin(AssociateLoginIP obj)
        {
            var parameters = new[]
            {
                 CreateParameter("@Action", SqlDbType.VarChar,obj.Action),
                CreateParameter("@Idno", SqlDbType.VarChar,obj.DistributorId),
                CreateParameter("@Password", SqlDbType.VarChar, obj.Password),
                CreateParameter("@UserType", SqlDbType.VarChar, obj.UserType),
                CreateParameter("@LoginFrom", SqlDbType.VarChar, obj.LoginFrom),
            };
            return CreateCommand("usp_Verify_Login", parameters);
        }


        internal static SqlCommand VerifyMobDistributorLogin(MobDistributorLogin obj)
        {
            var parameters = new[]
            {
                CreateParameter("@MemberID", SqlDbType.VarChar,obj.DistributorId),
                CreateParameter("@password", SqlDbType.VarChar, obj.PassKey),
                CreateParameter("@MobileInfo",SqlDbType.VarChar,obj.MobileInfo),
                CreateParameter("@Version", SqlDbType.Int, obj.Version),
                CreateParameter("@FCMID", SqlDbType.VarChar,obj.FCMID),
                CreateParameter("@LoginFrom", SqlDbType.VarChar, obj.LoginFrom),
                CreateParameter("@IPAddress", SqlDbType.VarChar, obj.IPAddress),
                CreateParameter("@SessionID", SqlDbType.VarChar, obj.SessionID),
                CreateParameter("@ISFCMChanged", SqlDbType.Bit, obj.ISFCMChanged)
             };
            return CreateCommand("usp_Mobile_Associate_Login", parameters);
        }

        internal static SqlCommand MemberDashboard(MemberDashboard_IP obj)
        {
            var parameters = new[]
            {
              CreateParameter("@OnDate",SqlDbType.DateTime,Convert.ToDateTime(obj.OnDate)),
             
              CreateParameter("@RegId",SqlDbType.BigInt,obj.RegId)
           };

            return CreateCommand("MemberDashboard_SP", parameters);
        }





        //internal static SqlCommand ViewProfileDetails(DistributorID obj)
        //{
        //    var parameters = new[]
        //    {
        //        CreateParameter("@ID", SqlDbType.VarChar,obj.DistributorId)
        //    };

        //    return CreateCommand("usp_Distributor_GetDetails", parameters);
        //}
        //internal static SqlCommand EditProfileData(DistEditProfileInput obj)
        //{
        //    var parameters = new[]
        //    {
        //        CreateParameter("@MemberID", SqlDbType.VarChar,obj.MemberID),
        //        CreateParameter("@Name", SqlDbType.VarChar,obj.Name),
        //        CreateParameter("@Title", SqlDbType.VarChar,obj.Title),
        //        CreateParameter("@Gender", SqlDbType.VarChar,obj.Gender),
        //        CreateParameter("@Dob", SqlDbType.Date,obj.Dob),
        //        CreateParameter("@Residence", SqlDbType.VarChar,obj.Residence),
        //        CreateParameter("@City", SqlDbType.Int,obj.City),
        //        CreateParameter("@State", SqlDbType.Int,obj.State),
        //        CreateParameter("@CityName", SqlDbType.VarChar,obj.CityName),
        //        CreateParameter("@StateName",SqlDbType.VarChar,obj.StateName),
        //        CreateParameter("@DistrictName",SqlDbType.VarChar,obj.DistrictName),
        //        CreateParameter("@PinCode", SqlDbType.Int,obj.PinCode),
        //        CreateParameter("@Email", SqlDbType.VarChar,obj.Email),
        //        CreateParameter("@Mobile", SqlDbType.VarChar,obj.Mobile),
        //        CreateParameter("@Chgthru", SqlDbType.VarChar,obj.Chgthru),
        //        CreateParameter("@NomName", SqlDbType.VarChar,obj.NomName),
        //        CreateParameter("@NomRelation", SqlDbType.VarChar,obj.NomRelation),
        //        CreateParameter("@NomAge", SqlDbType.Int,obj.NomAge),
        //        CreateParameter("@SessionID", SqlDbType.VarChar,obj.SessionID),
        //        CreateParameter("@IPAddress", SqlDbType.VarChar,obj.IPAddress),
        //        CreateParameter("@RelationType", SqlDbType.VarChar,obj.RelationType),
        //        CreateParameter("@RelativeName", SqlDbType.VarChar,obj.RelativeName),
        //    };

        //    return CreateCommand("usp_Distributor_ChangeProfile", parameters);
        //}
        internal static SqlCommand PreferredCustomerProfileDetails(DistributorID obj)
        {
            var parameters = new[]
            {
                CreateParameter("@CustID", SqlDbType.VarChar,obj.DistributorId)
            };

            return CreateCommand("usp_PreferredCustomer_GetDetails", parameters);
        }

        internal static SqlCommand CustomerProfileDetails(DistributorID obj)
        {
            var parameters = new[]
            {
                CreateParameter("@CustID", SqlDbType.VarChar,obj.DistributorId)
            };

            return CreateCommand("usp_Customer_GetDetails", parameters);
        }



        internal static SqlCommand GetSponsorsReportData(DistributorRegID obj)
        {
            var parameters = new[]
            {
                 CreateParameter("@RegID", SqlDbType.Int,obj.DistributorRegid)
            };

            return CreateCommand("usp_Distributor_SponsorReport", parameters);
        }


        internal static SqlCommand GetReferralReportData(DistributorRegID obj)
        {
            var parameters = new[]
            {
                CreateParameter("@RegID", SqlDbType.Int,obj.DistributorRegid)
            };

            return CreateCommand("usp_Distributor_ReferralReport", parameters);
        }

        internal static SqlCommand Signup(SignupIP obj)
        {

            var parameters = new[]
            {
          CreateParameter("@JsonObj", SqlDbType.VarChar,obj.JsonObj),
          CreateParameter("@Idno", SqlDbType.VarChar, obj.Idno),
          CreateParameter("@RegMobile", SqlDbType.VarChar,obj.RegMobile),
          CreateParameter("@RegFrom", SqlDbType.VarChar,obj.RegFrom),
          CreateParameter("@IpAddrss", SqlDbType.VarChar, obj.IpAddrss)
           };
            return CreateCommand("Registration_SP_NPL", parameters);
        }
        internal static SqlCommand PincodeCheck(PincodeCheckIP obj)
        {
            var parameters = new[]
            {
          CreateParameter("@Action", SqlDbType.VarChar,obj.Action),
          CreateParameter("@PinCode", SqlDbType.VarChar, obj.PinCode),
            };
            return CreateCommand("PincodeCheck_SP", parameters);
        }
        internal static SqlCommand CheckUserInfo(CheckUserInfo_IP obj)
        {
            var parameters = new[]
            {
                CreateParameter("@Action", SqlDbType.VarChar,obj.Action),
                CreateParameter("@Input", SqlDbType.VarChar,obj.Input),
            };

            return CreateCommand("usp_CheckUserInfo", parameters);
        }
        internal static SqlCommand SendOTP(SendOTP_IP obj)
        {
            var parameters = new[]
            {
                CreateParameter("@Action", SqlDbType.VarChar,obj.Action),
                CreateParameter("@Input", SqlDbType.VarChar,obj.Input),
            };

            return CreateCommand("usp_SendOTP", parameters);
        }
        internal static SqlCommand MemberProfile(MemberProfile_IP cInfo)
        {
            var parameters = new[]
            {
                CreateParameter("@regid", SqlDbType.VarChar, Convert.ToInt32(cInfo.regid))
            };
            return CreateCommand("MemberProfile_Sp", parameters);
        }

        internal static SqlCommand GetCitizenshipStatus(NepaliCitizenship_IP obj)
        {
            var parameters = new[]
            {
              CreateParameter("@regid",SqlDbType.Decimal,obj.regid)
            };

            return CreateCommand("GetCitizenshipStatus_SP", parameters
            );
        }
        internal static SqlCommand UploadCitizenshipRequest(NepaliCitizenship_IP obj)
        {
            var parameters = new[]
            {
              CreateParameter("@regid",SqlDbType.Decimal,obj.regid),
              CreateParameter("@filename",SqlDbType.VarChar,obj.filename),
               CreateParameter("@IdType",SqlDbType.VarChar,obj.IdProofType),
              CreateParameter("@CitizenshipNo",SqlDbType.VarChar,obj.CitizenshipNo),
              CreateParameter("@updatedby",SqlDbType.Int,obj.updatedby),
              CreateParameter("@Remarks",SqlDbType.VarChar,obj.Remarks),
              CreateParameter("@Action",SqlDbType.VarChar,obj.Action)
            };

            return CreateCommand("UploadCitizenshipRequest_SP", parameters);
        }

        internal static SqlCommand UploadBankDetails(BankDetails_IP obj)
        {
            var parameters = new[]
            {
               CreateParameter("@Regid",SqlDbType.Decimal,obj.Regid),
               CreateParameter("@AccountNumber",SqlDbType.VarChar,obj.AccountNumber),
               CreateParameter("@IFSCCode",SqlDbType.VarChar,obj.IFSCCode),
               CreateParameter("@NameAsPerBank",SqlDbType.VarChar,obj.NameAsPerBank),
               //CreateParameter("@BankName",SqlDbType.VarChar,obj.BankName),
               //CreateParameter("@BranchName",SqlDbType.VarChar,obj.BranchName),
               CreateParameter("@BankId",SqlDbType.Int,obj.BankId),
               CreateParameter("@BranchId",SqlDbType.Int,obj.BranchId),
               CreateParameter("@AccountType",SqlDbType.VarChar,obj.AccountType),
               CreateParameter("@BankImage",SqlDbType.VarChar,obj.BankImage),
               CreateParameter("@Remarks",SqlDbType.VarChar,obj.Remarks),
               CreateParameter("@UpdatedBy",SqlDbType.Int,obj.UpdatedBy),
               CreateParameter("@Action",SqlDbType.VarChar,obj.Action)
           };

            return CreateCommand("UploadBankDetails_SP", parameters);
        }
        internal static SqlCommand UploadPANDetails(PANDetails_IP obj)
        {
            var parameters = new[]
            {
              CreateParameter("@Regid",SqlDbType.Decimal,obj.Regid),
              
              CreateParameter("@PANCardNo",SqlDbType.VarChar,obj.PANCardNo),
              
              CreateParameter("@PANPhoto",SqlDbType.VarChar,obj.PANPhoto),
              
              //CreateParameter("@NameAsPerKYC",SqlDbType.VarChar,obj.NameAsPerKYC),
              
              CreateParameter("@Remarks",SqlDbType.VarChar,obj.Remarks),
              
              CreateParameter("@UpdatedBy",SqlDbType.Int,obj.UpdatedBy),
              
              CreateParameter("@Action",SqlDbType.VarChar,obj.Action)
           };

            return CreateCommand("UploadPANDetails_SP", parameters);
        }
        internal static SqlCommand UploadMemberPhoto(MemberPhoto_IP obj)
        {
            var parameters = new[]
            {
                CreateParameter("@Regid",SqlDbType.Decimal, obj.Regid),

                CreateParameter("@MPhoto",SqlDbType.VarChar, obj.MPhoto),

                CreateParameter("@Remarks",SqlDbType.VarChar,obj.Remarks),

                CreateParameter("@UpdatedBy",SqlDbType.Int,obj.UpdatedBy),

                CreateParameter("@Action",SqlDbType.VarChar,obj.Action)
            };

            return CreateCommand("UploadMemberPhoto_SP", parameters);
        }
        internal static SqlCommand ForgotPassword(ForgotPassword_IP obj)
        {
            var parameters = new[]
            {
                CreateParameter("@HRID", SqlDbType.VarChar,obj.HRID),
                CreateParameter("@MobileNo", SqlDbType.VarChar,obj.MobileNo),
                CreateParameter("@NewPassword", SqlDbType.VarChar,obj.NewPassword)
            };

            return CreateCommand("usp_ForgotPassword", parameters);
        }
    }

}

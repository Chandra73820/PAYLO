using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PAYLO_Classes.Enums;

namespace PAYLO_Classes.Associate
{
    public class AssociateLogin: Session_IPAdd
    {
        public string DistributorId { get; set; }

        public string PassKey { get; set; }

        public string UserType { get; set; }

        public string LoginFrom { get; set; }
        public string userAgent { get; set; }
    }
    public class AssociateLoginIP
    {
        public string DistributorId { get; set; }
        public string Password { get; set; }
        public string? UserType { get; set; }
        public string? LoginFrom { get; set; }
        public string? Action { get; set; }
    }
    public class MemberProfile_IP
    {
        public int regid { get; set; }
        public int CustId { get; set; }
    }
    public class MemberProfile_OutPut
    {
        public int RegId { get; set; }
        public int SprNo { get; set; }

        public string Sponsor { get; set; } = string.Empty;
        public string SponsorName { get; set; } = string.Empty;

        public string Idno { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        public string FName { get; set; } = string.Empty;
        public string LName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;

        public string MaritalStatus { get; set; } = string.Empty;
        public string MaidenName { get; set; } = string.Empty;
        public string Maiden { get; set; } = string.Empty;

        public string LPassword { get; set; } = string.Empty;
        public string TPassword { get; set; } = string.Empty;

        public string Dob { get; set; } = string.Empty;

        public int Sex { get; set; }
        public string Gender { get; set; } = string.Empty;

        public string Panno { get; set; } = string.Empty;
        public string AadhaarNo { get; set; } = string.Empty;

        public string Memdate { get; set; } = string.Empty;
        public string DOJ { get; set; } = string.Empty;

        public string Add1 { get; set; } = string.Empty;
        public string Add2 { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;
        public string TEHSIL { get; set; } = string.Empty;

        public string DistrictName { get; set; } = string.Empty;

        public int State { get; set; }
        public string StateName { get; set; } = string.Empty;

        public int Pin { get; set; }

        public string Mobile { get; set; } = string.Empty;
        public string TelNo { get; set; } = string.Empty;
        public string EMail { get; set; } = string.Empty;

        public string Referral { get; set; } = string.Empty;

        public string Nominee { get; set; } = string.Empty;
        public string Relation { get; set; } = string.Empty;

        public string PayeeName { get; set; } = string.Empty;
        public string Bank { get; set; } = string.Empty;
        public string Accno { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public string Ifscode { get; set; } = string.Empty;

        public string Mstatus { get; set; } = string.Empty;
        public int Stsid { get; set; }

        public string RankName { get; set; } = string.Empty;
        public string ValidDate { get; set; } = string.Empty;

        public bool IsLock { get; set; }

        public bool ARWaletID { get; set; } 

        public string MPhoto { get; set; } = string.Empty;

        public string ReferralName { get; set; } = string.Empty;
        public string Referralid { get; set; } = string.Empty;

        public string ISFarm { get; set; } = string.Empty;

        public string TypeOfFarm { get; set; } = string.Empty;

        public string GSTNo { get; set; } = string.Empty;

    }

    public class GlobalMemberProfile_IP
    {
        public int regid { get; set; }
        public string idno { get; set; }
        public string type { get; set; }
    }
    public class GlobalMemberProfile_OP
    {
        public string? Result { get; set; }
        public string? Message { get; set; }
        public string? UserCode { get; set; }
        public string? Username { get; set; }
        public int? CountryUserRegId { get; set; }
        public int? CountryId { get; set; }
        public string? CountryCode { get; set; }
        public int? sponsor { get; set; }
        public string? SponsorName { get; set; }
        public string? RefferalName { get; set; }
        public string? SponsorUserCode { get; set; }
        public string? RefferalUserCode { get; set; }
        public string? SponsorCountryCode { get; set; }
        public string? RefferalCountryCode { get; set; }
        public string? MStatus { get; set; }
        public string? SponsorID { get; set; }
    }
}

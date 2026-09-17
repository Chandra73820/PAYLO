using PAYLO_Classes.Enums;

namespace PAYLO_Classes;
public class DistributorDetails
{
    public int RegID { get; set; }
    public string MemberID { get; set; }
    public string Name { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Msg { get; set; }
    public int IsFirstLogin { get; set; }
    public string NomineeName { get; set; }
    public string NomineeRelation { get; set; }
    public int? NomineeAge { get; set; }
    public string? SecurityToken { get; set; }
    public string? ProfileImage { get; set; }
    public bool IsCustomer { get; set; }
    public bool IsLoginFromOpenSite { get; set; }

    public string? TwoFactorSecret { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public TwoFactorEnum TwoFactorType { get; set; }

    //public TwoFactorSetupInfo? TwoFactorInfo { get; set; }
    public string? Gender { get; set; }
    public int Rank{ get; set; }
    public string? RankName { get; set; }
    public bool TwoFAVerification { get; set; }
    public bool TwoFAVerificationView { get; set; }
    public bool MissingDetails { get; set; }
    public int AssociateID { get; set; } = 0;
    public string? LinkMemberID { get; set;} = string.Empty;
    public string? Pincode { get; set; }
    public int SprRegID { get; set; } = 0;
    public string? SprMemberID { get; set; } = string.Empty;
    public int RefferralID { get; set; } = 0;
    public string? RefferralMemberID { get; set; } = string.Empty;
    public string? District { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int CityID { get; set; }
    public int StateID { get; set; }
    public string Residence { get; set; }
    public int? IsLoginFrom { get; set; }=0;
    public int? Status { get; set; }
    public int? RankOrder_LM { get; set; }
    public int? IsProdShare { get; set; } = 0;
    public string? WAMobileNo { get; set; }=string.Empty;

    public int? IsLeadcode { get; set; } = 0;
    public string JoinDate { get; set; }
    public string UserType { get; set; } = string.Empty;

}
public class AssociateSearchInput
{
    public string SearchDetails { get; set; }

    public string Action { get; set; }
}
public class RegistrationResult
{
    public string Result { get; set; }

    public string Regid { get; set; }

    public string MemberID { get; set; }

    public string? Passkey { get; set; }
}
public class AssociateSearchDetails
{
    public int RegID { get; set; }

    public string MemberID { get; set; }

    public string Name { get; set; }

    public int Status { get; set; }

    public string LastPurchaseDate { get; set; }

    public decimal PBV { get; set; }
}

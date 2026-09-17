using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace PAYLO_Classes
{
    public class CheckUserID_OutPut
    {
        public Int32 regid { get; set; }
        public string result { get; set; }
    }
    public class CheckUserID_IP
    {
        public string action { get; set; }
        public string idnnumber { get; set; }
    }
    public class MemberAddress_IP
    {
        public string action { get; set; }
        public int Regid { get; set; }
    }
    public class CheckDownline_IP
    {
        public string action { get; set; }
        public string idno { get; set; }
        public string downlineID { get; set; }
    }
    public class Grivence_Input
    {
        public string Action { get; set; }
        public string? IdNo { get; set; }
        public string? GriType { get; set; }
        public string? Subject { get; set; }
        public string? Description { get; set; }
        public string? SessionId { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? FileName { get; set; }
        public int? AddedBy { get; set; }
    }
    public class IdVerification_IP
    {
        public string IdNo { get; set; }
        public string Mobile { get; set; }
    }
    public class IdVerification_OP
    {
        public string IdNo { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
    }
    public class UserCreation_IP
    {
        public int Uid { get; set; }
        public string Action { get; set; }
        public string Name { get; set; }
        public string DoorNo { get; set; }
        public string Lane { get; set; } = "";
        public string Street { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CreatedBy { get; set; }
        public string Flag { get; set; }
        public byte pstatus { get; set; }
        public string sesid { get; set; }
        public string Pincode { get; set; } = "";
    }
    public class UserReport_IP
    {
        public string Action { get; set; }
        public Int32 Uid { get; set; }
        public Int32 DeletedBy { get; set; }
    }
    public class UserReport_OutPut
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Flag { get; set; }
        public string result { get; set; }
        public string PassWord { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Int32 Pincode { get; set; }
        public string Contact_Name { get; set; }
        public string Email { get; set; }
        public Int32 StateId { get; set; }
        public Int32 CreatedBy { get; set; }
        public Int32 Uid { get; set; }
        public byte pstatus { get; set; }
    }
    public class LinksPremissionIP
    {
        public string uid { get; set; }
        public string usertype { get; set; }
        public string action { get; set; }
    }
    public class UpdateLinksPremissionIP
    {
        public string uid { get; set; }
        public string usertype { get; set; }
        public string lids { get; set; }
        public string Updatedby { get; set; }
        public string sessid { get; set; }
    }
    public class LinksPremission_OutPut
    {
        public Int32 Lid { get; set; }
        public Int32 Parent { get; set; }
        public Int32 flag { get; set; }
        public Int32 sorting { get; set; }
        public string LinkName { get; set; }
    }
    public class CreditRequestReport_IP
    {
        public string action { get; set; }
        public string Fromdate { get; set; }
        public string Todate { get; set; }
        public string Id { get; set; }
        public Int32 ReqTo { get; set; }
        public string ReqToType { get; set; }
        public Int32 Status { get; set; }
    }
    public class CreditRequestReport_OP
    {
        public string depslip { get; set; }
        public string UserID { get; set; }
        public string City { get; set; }
        public string Mobile { get; set; }
        public string Name { get; set; }
        public string ReqCode { get; set; }
        public string Reqdate { get; set; }
        public string DepositeDate { get; set; }
        public decimal ReqAmt { get; set; }
        public string MOP { get; set; }
        public string InsNo { get; set; }
        public string Branch { get; set; }
        public string MOPDet { get; set; }
        public string Depdet { get; set; }
        public string Sts { get; set; }
        public string Upby { get; set; }
        public string Updated { get; set; }
        public string ReqTo { get; set; }
        public string ReqToType { get; set; }
        public string Remarks { get; set; }
        public string? DepBank { get; set; }

    }
    public class StockOrderReport_IP
    {
        public string action { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string? Fcode { get; set; }
        public string? cnFCode { get; set; }
        public string? Status { get; set; }
        public string? OrderType { get; set; }
    }
    public class StockOrderReport_OP
    {
        public string RefNo { get; set; }
        public string RefDate { get; set; }
        public string InvNo { get; set; }
        public string InvDate { get; set; }
        public string? VerifyNo { get; set; }
        public string FCode { get; set; }
        public int Qty { get; set; }
        public decimal NetAmt { get; set; }
        public decimal TotBV { get; set; }
        public decimal TCSTax { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string CourierDetailes { get; set; }
        public string IsEInv { get; set; }
        public string IsEStatus { get; set; }
        public string ErrorResp { get; set; }
        public decimal UnitWeight { get; set; }
        public decimal PrdWeight { get; set; }
        public string ReturnType { get; set; }
        public decimal OffWallAmt { get; set; }
    }
    public class SearchProfile_IP
    {
        public string action { get; set; }
        public string SearchBy { get; set; }
        public string Searchvalue { get; set; }

    }
    public class SearchProfile_OP
    {
        public int Regid { get; set; }
        public string? Idno { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? StatusDate { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Panno { get; set; }
        public string? EMail { get; set; }
        public string? SponsorDetailes { get; set; }
        public string? BankDetailes { get; set; }

    }
    public class ShowLoginPassword_IP
    {
        public string UserID { get; set; }
        public int regid { get; set; }
        public string type { get; set; }

    }

    public class ShowLoginPassword_OP
    {
        public string? Result { get; set; }
        public string? Message { get; set; }

        public int Regid { get; set; }
        public string? Idno { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? LPassword { get; set; }
        public string? City { get; set; }
        public string? Mobile { get; set; }
    }
    public class SponsorReport_IP
    {
        public string UserId { get; set; }
        public string action { get; set; }
        public int regid { get; set; }
        public string Fromdate { get; set; }
        public string Todate { get; set; }
        public string Type { get; set; }
    }
    public class SponsorReport_OP
    {
        public string? Result { get; set; }
        public string? Message { get; set; }
        public string? UserCode { get; set; }
        public string? Name { get; set; }
        public string? JoinDate { get; set; }
        public string? ActiveDate { get; set; }
        public string? Placement { get; set; }
        public decimal? CurMonTeamBV { get; set; }
        public string? Lvl { get; set; }
        public string? ImagePath { get; set; }
    }
    public class EwalletSummaryReport_IP
    {
        public string action { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public int Id { get; set; }
        public int ReqTo { get; set; }

    }
    public class EwalletSummaryReport_OP
    {
        public int SNo { get; set; }
        public string dated { get; set; }
        public string PostingDate { get; set; }
        public decimal OpenBal { get; set; }
        public decimal inamt { get; set; }
        public decimal outamt { get; set; }
        public decimal Balance { get; set; }
        public string descr { get; set; }
        public string remarks { get; set; }
        public string TypeOfInc { get; set; }
        public string ReqCode { get; set; }
    }

    public class FranchiseSummaryReport_OP
    {
        public int RegId { get; set; }
        public string Idno { get; set; }
        public string Name { get; set; }
        public decimal OpenBal { get; set; }
        public decimal InAmt { get; set; }
        public decimal OutAmt { get; set; }
        public decimal Balance { get; set; }
        public string City { get; set; }
        public string Mobile { get; set; }
    }
    public class ProfileUpdate_IP
    {
        public int Regid { get; set; }

        public string? Title { get; set; }

        public string? FName { get; set; }

        public string? LName { get; set; }

        public string? MaidenName { get; set; }

        public string? Dob { get; set; }

        public int? Sex { get; set; } = 0;

        public string? MartialStatus { get; set; }

        public string? Add1 { get; set; }

        public string? Add2 { get; set; }

        public string? City { get; set; }

        public string? TEHSIL { get; set; }

        public string? District { get; set; }

        public int StateId { get; set; }

        public int Pin { get; set; }

        public string? Mobile { get; set; }

        public string? TelNo { get; set; }

        public string? EMail { get; set; }

        public string? Nominee { get; set; }

        public string? Relation { get; set; }

        public decimal UpdatedBy { get; set; }

        public string? Maiden { get; set; }

        public string? MiddleName { get; set; }

        public string? ReferralID { get; set; }

        public string? Gender { get; set; }
    }
    public class ProfileUpdate_OP
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string? Regid { get; set; }
    }
        public class TransportMaster_IP_OP
    {
        public string? Name { get; set; }

        public string? GSTNo { get; set; }

        public string? Mode { get; set; }

        public string? Mobile { get; set; }

        public string? Email { get; set; }

        public string? Remarks { get; set; }

        public string? Addedby { get; set; } 

        public string? Action { get; set; }

        public int Status { get; set; } = 0;
        public string? Statusval { get; set; } 
        public int? Sno { get; set; } = 0;
        
        public string? portal { get; set; }

        public int Portalid { get; set; } = 0;
    }
    
      public class CompanyBanks_IP
    {
        public string? Action { get; set; }

        public int? CBId { get; set; } = 0;

        public int? Fid { get; set; } = 0;

        public string? usertype { get; set; }

        public int? reqto { get; set; } = 0;
    }
    public class CompanyBanks_OP
    {
        public int CBId { get; set; }

        public string? Bank { get; set; } 

        public string? Branch { get; set; }

        public string? Accno { get; set; }
        public string? IFSC { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int StateId { get; set; }
        public int CBStatus { get; set; }
        public string? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public string? CPName { get; set; }
    }
    public class CreateBankDetails_IP
    {
        public int Cbid { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string Accno { get; set; }
        public string Ifsc { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int CBStatus { get; set; }
        public int CreatedBy { get; set; }
        public string Sesid { get; set; }
        public int AccTo { get; set; }
        public string AccTotype { get; set; }
        public string CPName { get; set; } = string.Empty;
    }

    public class Grievance_IP
    {
        public string? Idno { get; set; } = string.Empty;
        public string Name { get; set; }
        public string Mobile { get; set; } 
        public string Email { get; set; } 
        public string GriType { get; set; }
        public string Subject { get; set; } 
        public string Description { get; set; } 
        public string RequestFrom { get; set; } 
        public string GPhoto { get; set; } = string.Empty;
    }
    public class GrievanceReport_OP
    {
        public string GriNo { get; set; }
        public string Idno { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Dated { get; set; }
        public int GStatus { get; set; }
        public string GrievanceStatus { get; set; }
        public string photo { get; set; }
        public string? Remarks { get; set; }
        public string? Action { get; set; }

    }
    public class GrievanceReport_IP
    {
        public string? Action { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string? Id { get; set; }
        public int GStatus { get; set; }

    }
    public class GrievanceUpdate_IP
    {
        public string? GriNo { get; set; }
        public string? Remarks { get; set; }
        public int ResolvedBy { get; set; }
    }
    public class DownloadManager_IP
    {
        public string? action { get; set; }
        public string? Subject { get; set; }
        public string? Image { get; set; }
        public int? Uid { get; set; } = 0;
        public string? PopUpStartDate { get; set; }
        public string? PopUpEndDate { get; set; }
    }
    public class DownloadManager_OP
    {
        public int? SNo { get; set; }
        public string? FileName { get; set; }
        public string? Subject { get; set; }
        public string? UserType { get; set; }
    }
    public class RemoveKYC_IP
    {
        public string action { get; set; }
        public int regid { get; set; }
        public string remarks { get; set; }
        public int thru { get; set; } 
        public string Sesid { get; set; }
        public string IpAdd { get; set; }
    }
    public class UplelvelReport_OP
    {
        public string IdType { get; set; }
        public int Lvl { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Rank { get; set; }
        public string JoinDate { get; set; }
        public string ActiveDate { get; set; }
        public string SponsorID { get; set; }
        public string SponsorName { get; set; }
        public string LegID { get; set; }
        public string LegName { get; set; }
        public decimal CurrBV { get; set; }
        public decimal TotalBV { get; set; }
        public string? Result { get; set; }
        
    }

}


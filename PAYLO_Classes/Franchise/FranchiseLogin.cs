using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Franchise
{
    public class FranchiseLogin : Session_IPAdd
    {
        public string FranchiseId { get; set; }

        public string PassKey { get; set; }

        public string UserType { get; set; }

        public string LoginFrom { get; set; }
        public string userAgent { get; set; }
    }
    public class FranchiseLoginIP
    {
        public string FranchiseId { get; set; }
        public string Password { get; set; }
        public string? UserType { get; set; }
        public string? LoginFrom { get; set; }
        public string? Action { get; set; }
    }
    public class FranchiseProfile_IP
    {
       public string type { get; set; }
        public int regid { get; set; }
    }
        public class FranchiseProfile_OP
    {
        public int FID { get; set; }
        public string FCode { get; set; }
        public string FName { get; set; }
        public string UserName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string AlternateMobile { get; set; }
        public string POffice { get; set; }
        public string PResidence { get; set; }
        public string CPName { get; set; }
        public string GSTNo { get; set; }
        public string GstType { get; set; }
        public string PanNo { get; set; }
        public string FssaiNo { get; set; }
        public string FSSAIExp { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string AccountNo { get; set; }
        public string IFSC { get; set; }
        public string AccType { get; set; }
        public string BankAddress { get; set; }
        public string JoinDate { get; set; }
        public string Status { get; set; }
        public int Stocklimit { get; set; }
        public int Salelimit { get; set; }
        public string Remarks { get; set; }
        public string CreationDate { get; set; }
    }
    public class CreateFranchise_IP
    {
        public int FID { get; set; }

        public string Action { get; set; }

        public string? upliner { get; set; }

        public string? FCode { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public string? SponsorId { get; set; }

        public string? ReferalId { get; set; }

        public string? SelfId { get; set; }

        public string Add1 { get; set; }

        public string? City { get; set; }

        public string? Tehsil { get; set; }

        public string State { get; set; }

        public string PIN { get; set; }

        public string Mobile { get; set; }

        public string? AlternateMobile { get; set; }

        public string? Email { get; set; }

        public string Password { get; set; }

        public int Status { get; set; }

        public int CreatedBy { get; set; }

        public string CPName { get; set; }

        public string? Bank { get; set; }

        public string? Branch { get; set; }

        public string? AccNo { get; set; }

        public string? IFSC { get; set; }

        public string? Pan { get; set; }

        public string pwd { get; set; }

        // public DateTime? joindate { get; set; }

        public string? GstType { get; set; }

        public string? GSTNo { get; set; }

        public string? uplinertype { get; set; }

        public int DispayInWebsite { get; set; } = 0;

        public string? AccType { get; set; }

        public string? District { get; set; }

        public int Stocklimit { get; set; } = 0;

        public int Salelimit { get; set; } = 0;

        public string? Remarks { get; set; }

        public int Certid { get; set; } = 0;

        public int Stkrtnid { get; set; } = 0;

        public string? FssaiNo { get; set; }

        public DateTime? FSSAIExp { get; set; }
    }
    public class FranchiseCreate_OP
    {
        public int Result { get; set; }
        public string Message { get; set; }
    }
    public class EwalletBalance_IP
    {
        public string action { get; set; }
        public string Id { get; set; }
    }
    public class EwalletBalance_OP
    {
        public decimal Balance { get; set; }
    }
    public class WalletCreditRequest_IP
    {
        public string Action { get; set; }
        public string UserType { get; set; }
        public decimal RP { get; set; }
        public int Status { get; set; }
        public string ReqID { get; set; }
        public string UpdatedBy { get; set; }
        public string? AdminRemarks { get; set; }
        public string? Remarks { get; set; }
        public decimal OutAmt { get; set; }
        public string ReqCode { get; set; }
        public string sessionid { get; set; }
        public string IPAdd { get; set; }
        public int drpuplineId { get; set; }
        public int StoreReqTo { get; set; }
        public string? StoreReqToType { get; set; }

    }
    public class WalletCreditRequest_OP
    {
        public string? Result { get; set; }
        public string? Message { get; set; }
        public int RequeststsFOR { get; set; }
        

    }
    public class FranchiseCreditRequest_IP
    {
        public string? Action { get; set; }
        public string? UserType { get; set; }
        public decimal RP { get; set; }
        public string? MOP { get; set; }
        public string? BANKNAME { get; set; }
        public string? BRANCH { get; set; }
        public string? City { get; set; }
        public string? DOPDATE { get; set; }
        public int Status { get; set; }
        public string ReqID { get; set; }
        public string? FileName { get; set; }
        public string? VocharNo { get; set; }

        public string? InsBank { get; set; }
        public string? InsBranch { get; set; }

        public string? InsDate { get; set; }

        public string? UpdatedBy { get; set; }

        public string? AdminRemarks { get; set; }
        public string? Remarks { get; set; }

        public decimal OutAmt { get; set; }

        public string ReqCode { get; set; }
        public string? sessionid { get; set; }
        public string? IPAdd { get; set; }

        public int drpuplineId { get; set; } = 0;

        public int StoreReqTo { get; set; } = 0;

        public string? StoreReqToType { get; set; }
    }
}

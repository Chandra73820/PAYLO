using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using PAYLO_Classes;
using PAYLO_Classes.Associate;
using PAYLO_Classes.Common;
using PAYLO_Classes.Distributor;
using PAYLO_Classes.Enums;


namespace PAYLO_Dal
{
    internal partial class ObjectFactory
    {

        internal static DistributorProfileInfo GetProfileDataByRegID(SqlDataReader reader)
        {
            DistributorProfileInfo distributorProfileInfo = new DistributorProfileInfo();

            if (Convert.IsDBNull(reader["RegID"]))
                distributorProfileInfo.RegID = 0;
            else
                distributorProfileInfo.RegID = (int)reader["RegID"];

            if (Convert.IsDBNull(reader["MemberID"]))
                distributorProfileInfo.MemberID = string.Empty;
            else
                distributorProfileInfo.MemberID = (string)reader["MemberID"];

            if (Convert.IsDBNull(reader["Name"]))
                distributorProfileInfo.Name = string.Empty;
            else
                distributorProfileInfo.Name = (string)reader["Name"];

            if (Convert.IsDBNull(reader["RelationName"]))
                distributorProfileInfo.RelationName = string.Empty;
            else
                distributorProfileInfo.RelationName = (string)reader["RelationName"];

            if (Convert.IsDBNull(reader["State"]))
                distributorProfileInfo.State = string.Empty;
            else
                distributorProfileInfo.State = (string)reader["State"];

            if (Convert.IsDBNull(reader["Mobile"]))
                distributorProfileInfo.Mobile = string.Empty;
            else
                distributorProfileInfo.Mobile = (string)reader["Mobile"];

            if (Convert.IsDBNull(reader["Email"]))
                distributorProfileInfo.Email = string.Empty;
            else
                distributorProfileInfo.Email = (string)reader["Email"];

            if (Convert.IsDBNull(reader["ProfileImage"]))
                distributorProfileInfo.ProfileImage = string.Empty;
            else
                distributorProfileInfo.ProfileImage = (string)reader["ProfileImage"];

            if (Convert.IsDBNull(reader["RelationType"]))
                distributorProfileInfo.RelationType = string.Empty;
            else
                distributorProfileInfo.RelationType = (string)reader["RelationType"];

            if (Convert.IsDBNull(reader["District"]))
                distributorProfileInfo.District = string.Empty;
            else
                distributorProfileInfo.District = (string)reader["District"];

            if (Convert.IsDBNull(reader["IDExpiry"]))
                distributorProfileInfo.IDExpiry = string.Empty;
            else
                distributorProfileInfo.IDExpiry = (string)reader["IDExpiry"];

            if (Convert.IsDBNull(reader["FPOExpiry"]))
                distributorProfileInfo.FPOExpiry = string.Empty;
            else
                distributorProfileInfo.FPOExpiry = (string)reader["FPOExpiry"];
            if (Convert.IsDBNull(reader["WAMobileNo"]))
                distributorProfileInfo.WAMobileNo = string.Empty;
            else
                distributorProfileInfo.WAMobileNo = (string)reader["WAMobileNo"];

            return distributorProfileInfo;
        }
        
        internal static UserData GetDirectDownlineByRegID(SqlDataReader reader)
        {
            UserData userData = new UserData();

            if (Convert.IsDBNull(reader["RegID"]))
                userData.RegID = 0;
            else
                userData.RegID = (int)reader["RegID"];

            if (Convert.IsDBNull(reader["Name"]))
                userData.Name = string.Empty;
            else
                userData.Name = (string)reader["Name"];

            if (Convert.IsDBNull(reader["MemberID"]))
                userData.MemberID = string.Empty;
            else
                userData.MemberID = (string)reader["MemberID"];

            if (Convert.IsDBNull(reader["Count"]))
                userData.Count = 0;
            else
                userData.Count = (int)reader["Count"];

            if (Convert.IsDBNull(reader["Level"]))
                userData.Level = 0;
            else
                userData.Level = Math.Round((decimal)reader["Level"], 2);

            if (Convert.IsDBNull(reader["Status"]))
                userData.Status = string.Empty;
            else
                userData.Status = (string)reader["Status"];

           

           

            if (Convert.IsDBNull(reader["RankName"]))
                userData.RankName = string.Empty;
            else
                userData.RankName = (string)reader["RankName"];

            if (Convert.IsDBNull(reader["RankNo"]))
                userData.Rank = 0;
            else
                userData.Rank = (Int16)reader["RankNo"];

            if (Convert.IsDBNull(reader["SponsorCheck"]))
                userData.SponsorCheck = 0;
            else
                userData.SponsorCheck = (Int32)reader["SponsorCheck"];

            if (Convert.IsDBNull(reader["RankOrder_LM"]))
                userData.RankOrder_LM = 0;
            else
                userData.RankOrder_LM = (Int16)reader["RankOrder_LM"]; 

            if (Convert.IsDBNull(reader["CurrentLevel"]))
                userData.CurrentLevel = 0;
            else
                userData.CurrentLevel = Math.Round((decimal)reader["CurrentLevel"], 2); ;

            return userData;
        }


       
        internal static DownlineMember CheckDownlineID(SqlDataReader reader)
        {
            DownlineMember DownlineMember = new DownlineMember();

            if (Convert.IsDBNull(reader["RegID"]))
                DownlineMember.RegID = 0;
            else
                DownlineMember.RegID = (int)reader["RegID"];

            if (Convert.IsDBNull(reader["MemberID"]))
                DownlineMember.MemberID = string.Empty;
            else
                DownlineMember.MemberID = (string)reader["MemberID"];

            if (Convert.IsDBNull(reader["Name"]))
                DownlineMember.Name = string.Empty;
            else
                DownlineMember.Name = (string)reader["Name"];

            if (Convert.IsDBNull(reader["Mobile"]))
                DownlineMember.Mobile = string.Empty;
            else
                DownlineMember.Mobile = (string)reader["Mobile"];

            return DownlineMember;
        }
      
        internal static DistributorPhotoIdCard_OP DistributorPhotoIdOBJFactory(SqlDataReader reader)
        {
            DistributorPhotoIdCard_OP Items = new DistributorPhotoIdCard_OP();

            if (Convert.IsDBNull(reader["Result"]))
                Items.Result = null;
            else
                Items.Result = (string)reader["Result"];

            return Items;

        }

       

       
        internal static DistributorFields GetRedIdAssociateDetails(SqlDataReader reader)
        {
            DistributorFields distributorFields = new DistributorFields();

            if (Convert.IsDBNull(reader["RegID"]))
                distributorFields.RegID = 0;
            else
                distributorFields.RegID = (int)reader["RegID"];

            if (Convert.IsDBNull(reader["MemberID"]))
                distributorFields.MemberID = string.Empty;
            else
                distributorFields.MemberID = (string)reader["MemberID"];

            if (Convert.IsDBNull(reader["Name"]))
                distributorFields.Name = string.Empty;
            else
                distributorFields.Name = (string)reader["Name"];

            if (Convert.IsDBNull(reader["State"]))
                distributorFields.State = string.Empty;
            else
                distributorFields.State = (string)reader["State"];

            if (Convert.IsDBNull(reader["Mobile"]))
                distributorFields.Mobile = string.Empty;
            else
                distributorFields.Mobile = (string)reader["Mobile"];

            if (Convert.IsDBNull(reader["City"]))
                distributorFields.District = string.Empty;
            else
                distributorFields.District = (string)reader["City"];

            if (Convert.IsDBNull(reader["DOJ"]))
                distributorFields.DateOfJoin = string.Empty;
            else
                distributorFields.DateOfJoin = Convert.ToDateTime(reader["DOJ"]).ToString("dd/MM/yyyy");

            return distributorFields;
        }
        internal static MemberProfile_OutPut MemberProfileItemFactory(SqlDataReader reader)
        {
            MemberProfile_OutPut Items = new MemberProfile_OutPut();

            if (Convert.IsDBNull(reader["RegId"]))
                Items.RegId = 0;
            else
                Items.RegId = (int)reader["RegId"];

            if (Convert.IsDBNull(reader["SprNo"]))
                Items.SprNo = 0;
            else
                Items.SprNo = (int)reader["SprNo"];

            if (Convert.IsDBNull(reader["Sponsor"]))
                Items.Sponsor = null;
            else
                Items.Sponsor = (string)reader["Sponsor"];

            if (Convert.IsDBNull(reader["SponsorName"]))
                Items.SponsorName = null;
            else
                Items.SponsorName = (string)reader["SponsorName"];

            if (Convert.IsDBNull(reader["Idno"]))
                Items.Idno = null;
            else
                Items.Idno = (string)reader["Idno"];

            if (Convert.IsDBNull(reader["Title"]))
                Items.Title = null;
            else
                Items.Title = (string)reader["Title"];

            if (Convert.IsDBNull(reader["FName"]))
                Items.FName = null;
            else
                Items.FName = (string)reader["FName"];

            if (Convert.IsDBNull(reader["LName"]))
                Items.LName = null;
            else
                Items.LName = (string)reader["LName"];

            if (Convert.IsDBNull(reader["MiddleName"]))
                Items.MiddleName = null;
            else
                Items.MiddleName = (string)reader["MiddleName"];

            if (Convert.IsDBNull(reader["MaritalStatus"]))
                Items.MaritalStatus = null;
            else
                Items.MaritalStatus = (string)reader["MaritalStatus"];

            if (Convert.IsDBNull(reader["MaidenName"]))
                Items.MaidenName = null;
            else
                Items.MaidenName = (string)reader["MaidenName"];

            if (Convert.IsDBNull(reader["Maiden"]))
                Items.Maiden = null;
            else
                Items.Maiden = (string)reader["Maiden"];

            if (Convert.IsDBNull(reader["LPassword"]))
                Items.LPassword = null;
            else
                Items.LPassword = (string)reader["LPassword"];

            if (Convert.IsDBNull(reader["TPassword"]))
                Items.TPassword = null;
            else
                Items.TPassword = (string)reader["TPassword"];

            if (Convert.IsDBNull(reader["Dob"]))
                Items.Dob = null;
            else
                Items.Dob = (string)reader["Dob"];

            if (Convert.IsDBNull(reader["Sex"]))
                Items.Sex = 0;
            else
                Items.Sex = (int)reader["Sex"];

            if (Convert.IsDBNull(reader["Gender"]))
                Items.Gender = null;
            else
                Items.Gender = (string)reader["Gender"];

            if (Convert.IsDBNull(reader["Panno"]))
                Items.Panno = null;
            else
                Items.Panno = (string)reader["Panno"];

            if (Convert.IsDBNull(reader["AadhaarNo"]))
                Items.AadhaarNo = null;
            else
                Items.AadhaarNo = (string)reader["AadhaarNo"];

            if (Convert.IsDBNull(reader["Memdate"]))
                Items.Memdate = null;
            else
                Items.Memdate = (string)reader["Memdate"];

            if (Convert.IsDBNull(reader["DOJ"]))
                Items.DOJ = null;
            else
                Items.DOJ = (string)reader["DOJ"];

            if (Convert.IsDBNull(reader["Add1"]))
                Items.Add1 = null;
            else
                Items.Add1 = (string)reader["Add1"];

            if (Convert.IsDBNull(reader["Add2"]))
                Items.Add2 = null;
            else
                Items.Add2 = (string)reader["Add2"];

            if (Convert.IsDBNull(reader["City"]))
                Items.City = null;
            else
                Items.City = (string)reader["City"];

            if (Convert.IsDBNull(reader["TEHSIL"]))
                Items.TEHSIL = null;
            else
                Items.TEHSIL = (string)reader["TEHSIL"];

            if (Convert.IsDBNull(reader["DistrictName"]))
                Items.DistrictName = null;
            else
                Items.DistrictName = (string)reader["DistrictName"];

            if (Convert.IsDBNull(reader["State"]))
                Items.State = 0;
            else
                Items.State = (int)reader["State"];

            if (Convert.IsDBNull(reader["StateName"]))
                Items.StateName = null;
            else
                Items.StateName = (string)reader["StateName"];

            if (Convert.IsDBNull(reader["Pin"]))
                Items.Pin = 0;
            else
                Items.Pin = (int)reader["Pin"];

            if (Convert.IsDBNull(reader["Mobile"]))
                Items.Mobile = null;
            else
                Items.Mobile = (string)reader["Mobile"];

            if (Convert.IsDBNull(reader["TelNo"]))
                Items.TelNo = null;
            else
                Items.TelNo = (string)reader["TelNo"];

            if (Convert.IsDBNull(reader["EMail"]))
                Items.EMail = null;
            else
                Items.EMail = (string)reader["EMail"];

            if (Convert.IsDBNull(reader["Referral"]))
                Items.Referral = null;
            else
                Items.Referral = (string)reader["Referral"];

            if (Convert.IsDBNull(reader["Nominee"]))
                Items.Nominee = null;
            else
                Items.Nominee = (string)reader["Nominee"];

            if (Convert.IsDBNull(reader["Relation"]))
                Items.Relation = null;
            else
                Items.Relation = (string)reader["Relation"];

            if (Convert.IsDBNull(reader["PayeeName"]))
                Items.PayeeName = null;
            else
                Items.PayeeName = (string)reader["PayeeName"];

            if (Convert.IsDBNull(reader["Bank"]))
                Items.Bank = null;
            else
                Items.Bank = (string)reader["Bank"];

            if (Convert.IsDBNull(reader["Accno"]))
                Items.Accno = null;
            else
                Items.Accno = (string)reader["Accno"];

            if (Convert.IsDBNull(reader["Branch"]))
                Items.Branch = null;
            else
                Items.Branch = (string)reader["Branch"];

            if (Convert.IsDBNull(reader["Ifscode"]))
                Items.Ifscode = null;
            else
                Items.Ifscode = (string)reader["Ifscode"];

            if (Convert.IsDBNull(reader["Mstatus"]))
                Items.Mstatus = null;
            else
                Items.Mstatus = (string)reader["Mstatus"];

            if (Convert.IsDBNull(reader["Stsid"]))
                Items.Stsid = 0;
            else
                Items.Stsid = (int)reader["Stsid"];

            if (Convert.IsDBNull(reader["RankName"]))
                Items.RankName = null;
            else
                Items.RankName = (string)reader["RankName"];

            if (Convert.IsDBNull(reader["ValidDate"]))
                Items.ValidDate = null;
            else
                Items.ValidDate = (string)reader["ValidDate"];

            if (Convert.IsDBNull(reader["IsLock"]))
                Items.IsLock = false;
            else
                Items.IsLock = (bool)reader["IsLock"];

            if (Convert.IsDBNull(reader["ARWaletID"]))
                Items.ARWaletID = false;
            else
                Items.ARWaletID = (bool)reader["ARWaletID"];

            if (Convert.IsDBNull(reader["MPhoto"]))
                Items.MPhoto = null;
            else
                Items.MPhoto = (string)reader["MPhoto"];

            if (Convert.IsDBNull(reader["ReferralName"]))
                Items.ReferralName = null;
            else
                Items.ReferralName = (string)reader["ReferralName"];

            if (Convert.IsDBNull(reader["Referralid"]))
                Items.Referralid = null;
            else
                Items.Referralid = (string)reader["Referralid"];

            if (Convert.IsDBNull(reader["ISFarm"]))
                Items.ISFarm = null;
            else
                Items.ISFarm = (string)reader["ISFarm"];

            if (Convert.IsDBNull(reader["TypeOfFarm"]))
                Items.TypeOfFarm = null;
            else
                Items.TypeOfFarm = (string)reader["TypeOfFarm"];

            if (Convert.IsDBNull(reader["GSTNo"]))
                Items.GSTNo = null;
            else
                Items.GSTNo = (string)reader["GSTNo"];

            return Items;
        }
        //internal static SponsorRptOutput ReferralRptObjectFactory(SqlDataReader reader)
        //{
        //    SponsorRptOutput obj = new SponsorRptOutput();

        //    if (Convert.IsDBNull(reader["CustID"]))
        //        obj.Regid = 0;
        //    else
        //        obj.Regid = (int)reader["CustID"];


        //    if (Convert.IsDBNull(reader["MemberID"]))
        //        obj.MemberID = string.Empty;
        //    else
        //        obj.MemberID = (string)reader["MemberID"];

        //    if (Convert.IsDBNull(reader["Name"]))
        //        obj.Name = string.Empty;
        //    else
        //        obj.Name = (string)reader["Name"];

        //    if (Convert.IsDBNull(reader["State"]))
        //        obj.State = string.Empty;
        //    else
        //        obj.State = (string)reader["State"];

        //    if (Convert.IsDBNull(reader["City"]))
        //        obj.City = string.Empty;
        //    else
        //        obj.City = (string)reader["City"];

        //    if (Convert.IsDBNull(reader["Mobile"]))
        //        obj.Mobile = string.Empty;
        //    else
        //        obj.Mobile = (string)reader["Mobile"];

        //    //obj.CurrentMonthBv = new CurrentMonthBV();

        //    //obj.CurrentMonthBv.PBv = new PBV();

        //    //if (Convert.IsDBNull(reader["CurrentMonBV"]))
        //    //    obj.CurrentMonthBv.PBv.PBv = 0;
        //    //else
        //    //    obj.CurrentMonthBv.PBv.PBv = (decimal)reader["CurrentMonBV"];

        //    //if (Convert.IsDBNull(reader["CurrentMonthAmount"]))
        //    //    obj.CurrentMonthBv.PBv.Amount = 0;
        //    //else
        //    //    obj.CurrentMonthBv.PBv.Amount = (decimal)reader["CurrentMonthAmount"];

        //    //obj.TotalCumulativeBv = new TotalCumulativeBV();
        //    //if (Convert.IsDBNull(reader["TotCummBV"]))
        //    //    obj.TotalCumulativeBv.CummPBv = 0;
        //    //else
        //    //    obj.TotalCumulativeBv.CummPBv = (decimal)reader["TotCummBV"];

        //    //if (Convert.IsDBNull(reader["TotCummAmount"]))
        //    //    obj.TotalCumulativeBv.Amount = 0;
        //    //else
        //    //    obj.TotalCumulativeBv.Amount = (decimal)reader["TotCummAmount"];

        //    if (Convert.IsDBNull(reader["Status"]))
        //        obj.Status = string.Empty;
        //    else
        //        obj.Status = (string)reader["Status"];

        //    if (Convert.IsDBNull(reader["JoinDate"]))
        //        obj.JoinDate = string.Empty;
        //    else
        //        obj.JoinDate = Convert.ToDateTime(reader["JoinDate"]).ToString("dd/MMM/yyyy");

        //    if (Convert.IsDBNull(reader["ProfileImage"]))
        //        obj.ProfileImage = string.Empty;
        //    else
        //        obj.ProfileImage = (string)reader["ProfileImage"];

        //    return obj;

        //}


    }
}

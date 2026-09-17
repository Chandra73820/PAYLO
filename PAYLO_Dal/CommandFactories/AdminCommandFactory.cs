using Microsoft.Data.SqlClient;
using PAYLO_Classes;
using PAYLO_Classes.Admin;
using PAYLO_Classes.Associate;
using System.Data;
namespace PAYLO_Dal.CommandFactories
{
    internal class AdminCommandFactory : CommandFactory
    {
        internal static SqlCommand GetAuthenticationAssociate(AssociateLogin obj)
        {

            var parameters = new[]
            {
                CreateParameter("@Username", SqlDbType.VarChar,obj.DistributorId),
                CreateParameter("@Password", SqlDbType.VarChar, obj.PassKey),
                CreateParameter("@IpAddress", SqlDbType.VarChar, obj.IPAddress),
                CreateParameter("@UserAgent", SqlDbType.VarChar, obj.userAgent),
            };
            return CreateCommand("AdminLogin_Sp", parameters);
        }

        internal static SqlCommand UpdateLinksPremission(UpdateLinksPremissionIP cInfo)
        {
            var parameters = new[]
            {
                CreateParameter("@uid", SqlDbType.VarChar, cInfo.uid),
                CreateParameter("@usertype", SqlDbType.VarChar, cInfo.usertype ) ,
                CreateParameter("@lids", SqlDbType.VarChar, cInfo.lids ) ,
                CreateParameter("@Updatedby", SqlDbType.VarChar, cInfo.Updatedby ) ,
                CreateParameter("@sessid", SqlDbType.VarChar, cInfo.sessid )
            };
            return CreateCommand("UpdateLinksPremission_SP", parameters);
        }

        internal static SqlCommand LinksPremission(LinksPremissionIP obj)
        {
            var parameters = new[]
            {
                CreateParameter("@action", SqlDbType.VarChar, obj.action ) ,
                CreateParameter("@uid", SqlDbType.VarChar, obj.uid),
                CreateParameter("@usertype", SqlDbType.VarChar, obj.usertype )
            };

            return CreateCommand("LinksPremission_SP", parameters);
        }

        internal static SqlCommand UsersReport(UserReport_IP obj)
        {
            var parameters = new[]
            {
                CreateParameter("@Uid", SqlDbType.Int, obj.Uid) ,
                CreateParameter("@Action", SqlDbType.VarChar, obj.Action),
                CreateParameter("@DeletedBy", SqlDbType.Int,obj.DeletedBy),
            };

            return CreateCommand("UsersReport_Sp", parameters);
        }

        internal static SqlCommand GetLinks(LinksParam obj)
        {
            var parameters = new[]
            {
        CreateParameter("@Action", SqlDbType.VarChar, obj.Action),
        CreateParameter("@Id", SqlDbType.VarChar, obj.Id),
        //CreateParameter("@type", SqlDbType.VarChar, obj.type),
    };
            return CreateCommand("GetLinks_SP", parameters);
        }
        internal static SqlCommand CreateOrUpdateUser(UserCreation_IP cInfo, string IpAddress)
        {
            var parameters = new[]
            {
                CreateParameter("@Uid", SqlDbType.Int,cInfo.Uid),
                CreateParameter("@Action", SqlDbType.VarChar,cInfo.Action),
                CreateParameter("@Name", SqlDbType.VarChar,cInfo.Name) ,
                CreateParameter("@DoorNo", SqlDbType.VarChar,cInfo.DoorNo),
                CreateParameter("@Lane", SqlDbType.VarChar,cInfo.Lane),
                CreateParameter("@Street", SqlDbType.VarChar, cInfo.Street),
                CreateParameter("@City", SqlDbType.VarChar, cInfo.City),
                CreateParameter("@State", SqlDbType.VarChar, cInfo.State),
                CreateParameter("@Email", SqlDbType.VarChar, cInfo.Email),
                CreateParameter("@Mobile", SqlDbType.VarChar, cInfo.Mobile),
                CreateParameter("@UserName", SqlDbType.VarChar, cInfo.UserName),
                CreateParameter("@PassWord", SqlDbType.VarChar, cInfo.Password),
                CreateParameter("@CreatedBy", SqlDbType.Int, cInfo.CreatedBy),
                CreateParameter("@sesid",SqlDbType.VarChar, cInfo.sesid),
                CreateParameter("@Ipaddress",SqlDbType.VarChar,IpAddress),
                CreateParameter("@Flag",SqlDbType.VarChar,cInfo.Flag),
                CreateParameter("@pstatus",SqlDbType.TinyInt,cInfo.pstatus),
                CreateParameter("@Pincode",SqlDbType.Int,Convert.ToInt32(cInfo.Pincode)),
            };

            return CreateCommand("CreatOrUpdateUsers_SP", parameters);
        }

        internal static SqlCommand GetCustomers()
        {
            return CreateCommand("Usp_GetCustomers");
        }
        internal static SqlCommand CreateOrUpdateCustomer(CustomerMaster_IP obj)
        {
            var parameters = new[]
            {
                CreateParameter("@CustomerName", SqlDbType.VarChar, obj.CustomerName),
                CreateParameter("@MobileNumber", SqlDbType.VarChar, obj.MobileNumber),
                CreateParameter("@Email", SqlDbType.VarChar, obj.Email),
                CreateParameter("@AadhaarNumber", SqlDbType.VarChar, obj.AadhaarNumber),
                CreateParameter("@AadhaarImagePath", SqlDbType.VarChar, obj.AadhaarImagePath),
                CreateParameter("@PANNumber", SqlDbType.VarChar, obj.PANNumber),
                CreateParameter("@PANImagePath", SqlDbType.VarChar, obj.PANImagePath),
                CreateParameter("@Status", SqlDbType.Int, obj.Status),
                CreateParameter("@CreatedBy", SqlDbType.Int, obj.CreatedBy),
                CreateParameter("@IPAddress", SqlDbType.VarChar, obj.IPAddress),
                CreateParameter("@SessionID", SqlDbType.VarChar, obj.SessionID)
            };
            return CreateCommand("InsertCustomer_SP", parameters);
        }
    }
}

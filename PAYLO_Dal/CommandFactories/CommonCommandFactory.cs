using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PAYLO_Classes;
using PAYLO_Classes.Admin;
using PAYLO_Classes.Common;
using PAYLO_Classes.GlobalDB;


namespace PAYLO_Dal
{
    internal partial class CommandFactory
    {

        internal static SqlCommand InsertErrorLog(ErrorLogEntry entry)
        {
            var parameters = new[]
            {
            CreateParameter("@CorrelationId",    SqlDbType.VarChar, entry.CorrelationId),
            CreateParameter("@MachineName",      SqlDbType.VarChar, entry.MachineName),
            CreateParameter("@Application",      SqlDbType.VarChar, entry.Application),
            CreateParameter("@Environment",      SqlDbType.VarChar, entry.Environment),
            CreateParameter("@HttpMethod",       SqlDbType.VarChar, entry.HttpMethod),
            CreateParameter("@RequestPath",      SqlDbType.NVarChar, entry.RequestPath),
            CreateParameter("@QueryString",      SqlDbType.NVarChar, entry.QueryString),
           CreateParameter("@StatusCode", SqlDbType.Int,entry.StatusCode.HasValue? (object)entry.StatusCode.Value: DBNull.Value),
            CreateParameter("@ClientIp",         SqlDbType.VarChar, entry.ClientIp),
            CreateParameter("@UserAgent",        SqlDbType.NVarChar, entry.UserAgent),
            CreateParameter("@UserIdentity",     SqlDbType.VarChar, entry.UserIdentity),
            CreateParameter("@ExceptionType",    SqlDbType.VarChar, entry.ExceptionType),
            CreateParameter("@ExceptionMessage", SqlDbType.NVarChar, entry.ExceptionMessage),
            CreateParameter("@StackTrace",       SqlDbType.NVarChar, entry.StackTrace),
            CreateParameter("@InnerException",   SqlDbType.NVarChar, entry.InnerException),
            CreateParameter("@RequestBody",      SqlDbType.NVarChar, entry.RequestBody),
            CreateParameter("@AdditionalData",   SqlDbType.NVarChar, entry.AdditionalData)
        };
            return CreateCommand("Usp_InsertErrorLog_GBL", parameters);
        }
        internal static SqlCommand RevokePendingAsync()
        {

            return CreateCommand("usp_UserRefreshTokens_RevokePending");
        }
        internal static SqlCommand SoftRevoke(SessionRef obj)
        {
            var parameters = new[]
            {
                CreateParameter("@MultiSessionId", SqlDbType.VarChar, obj.MultiSessionId),
                CreateParameter("@UserType", SqlDbType.VarChar, obj.UserType),
            };
            return CreateCommand("usp_UserRefreshTokens_SoftRevoke", parameters);
        }
        internal static SqlCommand CancelSoftRevoke(SessionRef obj)
        {
            var parameters = new[]
            {
            CreateParameter("@MultiSessionId", SqlDbType.VarChar, obj.MultiSessionId),
            CreateParameter("@UserType",       SqlDbType.VarChar, obj.UserType),
            };
            return CreateCommand("usp_UserRefreshTokens_CancelSoftRevoke", parameters);
        } 

        internal static SqlCommand GetProductCategories()
        {
            return CreateCommand("usp_Open_GetSubCategory");
        }
        internal static SqlCommand GetProductsBySearch(SearchProductsInput obj)
        {

            var parameters = new[]
           {
             CreateParameter("@SearchText", SqlDbType.VarChar, obj.SearchText),
             CreateParameter("@RegID", SqlDbType.Int, obj.RegID),
             CreateParameter("@UserType", SqlDbType.Int, obj.UserType)
           };

            return CreateCommand("usp_Open_GetProductsBySearch", parameters);
        }

        internal static SqlCommand CloseSession(SessionInInputParams obj)
        {
            var parameters = new[]
            {
                CreateParameter("@LSID", SqlDbType.Int, obj.LSID),
                CreateParameter("@SessionID", SqlDbType.VarChar, obj.SessionID),
            };

            return CreateCommand("usp_Session_LogOut", parameters);
        }

        internal static SqlCommand LoginSession(SessionInInputParams obj)
        {

            var parameters = new[]
            {
                  CreateParameter("@LSID", SqlDbType.Int, obj.LSID),
                  CreateParameter("@SessionID", SqlDbType.VarChar, obj.SessionID),
                  CreateParameter("@IPAddress", SqlDbType.VarChar, obj.IPAddress),
                  CreateParameter("@LogType", SqlDbType.VarChar, obj.LogType),
                  CreateParameter("@LogFromId", SqlDbType.Int, obj.LogFromId),
                  CreateParameter("@LoginFrom", SqlDbType.Int, obj.LoginFrom),
            };

            return CreateCommand("usp_Session_LogIn", parameters);
        }

        internal static SqlCommand GetProducts()
        {
            return CreateCommand("usp_Open_GetProducts");
        }
        internal static SqlCommand GetProductsBySubCategoryID(SubCatIDInput obj)
        {
            var parameters = new[]
           {
                CreateParameter("@SubCatID", SqlDbType.Int, obj.SubCatID),
                CreateParameter("@RegID", SqlDbType.Int, obj.RegID),
                CreateParameter("@UserType", SqlDbType.Int, obj.UserType),
           };

            return CreateCommand("usp_Open_GetProductsBySubCategoryID", parameters);
        }
        internal static SqlCommand GetProductsByFilter(FilterProducts obj)
        {
            var parameters = new[]
           {
                CreateParameter("@SubCatIDs", SqlDbType.VarChar, obj.id),
                CreateParameter("@MinAmt", SqlDbType.Money, obj.minAmt),
                CreateParameter("@MaxAmt", SqlDbType.Money, obj.maxAmt),
                CreateParameter("@RegID", SqlDbType.Int, obj.RegID),
                CreateParameter("@UserType", SqlDbType.Int, obj.UserType),
                CreateParameter("@Action", SqlDbType.VarChar, obj.Action),
                CreateParameter("@SCMID", SqlDbType.Int, obj.SCMID),
                //CreateParameter("@AddressID", SqlDbType.Int, obj.AddressID)
           };

            return CreateCommand("usp_Open_GetProductsByFilter", parameters);
        }
        internal static SqlCommand GetDownloadsListData()
        {
            return CreateCommand("usp_Open_GetDownloadFilesList");
        }

        internal static SqlCommand GetZonesData()
        {
            return CreateCommand("usp_Mas_GetZones");
        }
        internal static SqlCommand VendorReport(VendorReport_IP obj)
        {

            var parameters = new[]
           {
              CreateParameter("@Action", SqlDbType.VarChar, obj.Action),
                CreateParameter("@Vid", SqlDbType.Int, obj.Vid),
                CreateParameter("@DeletedBy", SqlDbType.Int , obj.Deletedby),
           };

            return CreateCommand("VendorReport_Sp", parameters);
        }





        internal static SqlCommand CheckUserID(CheckUserID_IP cInfo)
        {
            var parameters = new[]
            {
                CreateParameter("@action", SqlDbType.VarChar, cInfo.action),
                CreateParameter("@idno", SqlDbType.VarChar, cInfo.idnnumber ?? "")
            };

            return CreateCommand("CheckUserID_Sp", parameters);
        }
        internal static SqlCommand MemberAddress(MemberAddress_IP cInfo)
        {
            var parameters = new[]
            {
                CreateParameter("@action", SqlDbType.VarChar, cInfo.action),
                CreateParameter("@Regid", SqlDbType.VarChar, cInfo.Regid )
            };

            return CreateCommand("MemberAddress_SP", parameters);
        }

        internal static SqlCommand GetSupportTktTypes(LoginTypeIput obj)
        {
            var parameters = new[]
            {
             CreateParameter("@LoginType", SqlDbType.VarChar, obj.LoginFrom)
             };

            return CreateCommand("usp_Mas_GetSupportTicketTypes", parameters);
        }



        internal static SqlCommand SaveSEODetails(string seoDetails)
        {
            var parameters = new[]
            {
                 CreateParameter("@MetaTags", SqlDbType.VarChar, seoDetails),
                 CreateParameter("@ReturnMessage", SqlDbType.VarChar,100,ParameterDirection.Output, ""),
            };

            return CreateCommand("usp_SEO_UpdateMetaTags", parameters);
        }

        internal static SqlCommand GetSeoTagsByID(int prodDetailedID, int IsProduct)
        {
            var parameters = new[]
            {
                CreateParameter("@ProdDetID", SqlDbType.Int, prodDetailedID),
                CreateParameter("@IsProduct", SqlDbType.Int, IsProduct)
            };

            return CreateCommand("usp_SEO_GetSeoTagsByID", parameters);
        }

        internal static SqlCommand GetImageCollectionByImgCatID(int imgCatID)
        {
            var parameters = new[]
            {
                CreateParameter("@ImageCategoryID", SqlDbType.Int, imgCatID)
            };

            return CreateCommand("usp_CMS_GetImageCollection", parameters);
        }
        internal static SqlCommand UpdateImageCollectionDetails(string imageCollectionDetails)
        {
            var parameters = new[]
            {
                 CreateParameter("@ImageItems", SqlDbType.VarChar, imageCollectionDetails),
                 CreateParameter("@ReturnMessage", SqlDbType.VarChar,100,ParameterDirection.Output, ""),
            };
            return CreateCommand("usp_CMS_UpdateImageCollection", parameters);
        }

        internal static SqlCommand SaveImageCollection(string imageCollection)
        {
            var parameters = new[]
            {
                 CreateParameter("@ImageItems", SqlDbType.VarChar, imageCollection),
                 CreateParameter("@ReturnMessage", SqlDbType.VarChar,100,ParameterDirection.Output, ""),
            };

            return CreateCommand("usp_CMS_InsertImageCollection", parameters);
        }
        internal static SqlCommand GetSeoProductTagsByID()
        {
            return CreateCommand("usp_SEO_GetSeoTagsForProducts");
        }
        internal static SqlCommand ProductDetailsForSEO()
        {
            return CreateCommand("usp_ProductWiseDetails");
        }
        internal static SqlCommand GetProductDetails(ProductIDInput obj)
        {
            var parameters = new[]
           {
                CreateParameter("@ProdDetID", SqlDbType.Int, obj.ProductID),
                CreateParameter("@RegID", SqlDbType.Int, obj.RegID),
                CreateParameter("@UserType", SqlDbType.Int, obj.UserType),
           };

            return CreateCommand("usp_Open_GetProductDetailsByProdDetID", parameters);
        }
        internal static SqlCommand AddProductDetailsInfo(string itemCollection)
        {
            var parameters = new[]
            {
                 CreateParameter("@AddItems", SqlDbType.VarChar, itemCollection),
                 CreateParameter("@ReturnMessage", SqlDbType.VarChar,100,ParameterDirection.Output, ""),
            };
            return CreateCommand("usp_Prd_SEOInfo", parameters);
        }



        //internal static SqlCommand SaveAPITokenDetails(SaveAuthResult saveAuthResult)
        //{
        //    var parameters = new[]
        //    {
        //         CreateParameter("@Access_Token", SqlDbType.VarChar, saveAuthResult.access_token),
        //         CreateParameter("@Token_Type", SqlDbType.VarChar, saveAuthResult.token_type),
        //         CreateParameter("@Expiry", SqlDbType.VarChar, saveAuthResult.expiry),
        //         CreateParameter("@IPAddress", SqlDbType.VarChar, saveAuthResult.IPAddress),
        //         CreateParameter("@SessionID", SqlDbType.VarChar, saveAuthResult.SessionID),
        //         CreateParameter("@ReturnMessage", SqlDbType.VarChar,100,ParameterDirection.Output, "")
        //    };

        //    return CreateCommand("usp_Reg_AutoKycApiTokenDetails", parameters);
        //}

        internal static SqlCommand GetAutoKycApiTokenDetails()
        {
            return CreateCommand("usp_Reg_GetAutoKycApiTokenDetails");
        }






        internal static SqlCommand SaveSMSLog(SMSLog sMSLog)
        {
            var parameters = new[]{
                CreateParameter("@SenderID", SqlDbType.VarChar, sMSLog.SenderID),
                CreateParameter("@Mobile", SqlDbType.VarChar, sMSLog.MobileNo),
                CreateParameter("@Message", SqlDbType.VarChar, sMSLog.Message),
                CreateParameter("@TemplateID", SqlDbType.VarChar, sMSLog.TemplateID),
                CreateParameter("@RegID", SqlDbType.Int, sMSLog.RegID),
                CreateParameter("@MemberID", SqlDbType.VarChar, sMSLog.MemberID),
                CreateParameter("@SendFrom", SqlDbType.VarChar, sMSLog.SendFrom),
                CreateParameter("@Remarks", SqlDbType.VarChar, sMSLog.Remarks),
                CreateParameter("@IPAddress", SqlDbType.VarChar, sMSLog.IPAddress),
                CreateParameter("@SessionID", SqlDbType.VarChar, sMSLog.SessionID),
                CreateParameter("@RtnMsg", SqlDbType.VarChar,100,ParameterDirection.Output, "")
            };

            return CreateCommand("usp_Log_SaveSMS", parameters);
        }

        internal static SqlCommand SaveApiLog(ApiLog apiLog)
        {
            var parameters = new[]{
                CreateParameter("@ApiType", SqlDbType.VarChar, apiLog.ApiType),
                CreateParameter("@ApiResponse", SqlDbType.VarChar, apiLog.ApiResponse),
                CreateParameter("@Exception", SqlDbType.VarChar, apiLog.Exception),
                CreateParameter("@ApiStatus", SqlDbType.VarChar, apiLog.ApiStatus),
                CreateParameter("@IPAddress", SqlDbType.VarChar, apiLog.IPAddress),
                CreateParameter("@SessionID", SqlDbType.VarChar, apiLog.SessionID),
                 CreateParameter("@RtnMsg", SqlDbType.VarChar,100,ParameterDirection.Output, "")
            };

            return CreateCommand("usp_common_SaveApiLog", parameters);
        }

        internal static SqlCommand HomepageProducts(HomePageProducts_IP obj)
        {
            var parameters = new[]
            {
                CreateParameter("@UserType", SqlDbType.Int, obj.UserType),
                CreateParameter("@RegID", SqlDbType.Int, obj.RegID),
            };

            return CreateCommand("usp_Open_HomePageProducts", parameters);
        }

        internal static SqlCommand GenerateCourierSlipDetails(int BillID)
        {
            var parameters = new[]
            {
                CreateParameter("@BillID", SqlDbType.Int, BillID)
            };

            return CreateCommand("USP_ECOM_CourierDeliverySlip", parameters);
        }
        internal static SqlCommand ComboGetProductsByFilter()
        {

            return CreateCommand("usp_Open_ComboOfferProducts");
        }

        internal static SqlCommand ComboGetProductsByFilterNew(DistributorRegID obj)
        {
            var parameters = new[]
            {
               CreateParameter("@UserType", SqlDbType.Int, obj.UserType),
                CreateParameter("@RegID", SqlDbType.Int, obj.DistributorRegid)
            };

            return CreateCommand("usp_Open_ComboOfferProducts", parameters);
        }

        internal static SqlCommand GetDropDown(GetDropDown_IP cInfo)
        {
            var parameters = new[]
           {
               CreateParameter("@Action", SqlDbType.VarChar, cInfo.Action) ,
               CreateParameter("@Condition", SqlDbType.VarChar, cInfo.Condition),
               CreateParameter("@ItemID", SqlDbType.Int,cInfo.ItemID)
           };
            return CreateCommand("GetDropDown_SP", parameters);
        }
        internal static SqlCommand GetReceipt(GetReceiptIP _obj)
        {
            var parameters = new[]
            {
                CreateParameter("@action", SqlDbType.VarChar, _obj.action),
                CreateParameter("@refno",SqlDbType.VarChar,_obj.refno)
            };

            return CreateCommand("GetReceipt_SP", parameters);
        }
        //internal static SqlCommand SendOTP(SendOTP_IP obj)
        //{
        //    var parameters = new[]
        //    {
        //        CreateParameter("@action", SqlDbType.VarChar, obj.action),
        //        CreateParameter("@idno", SqlDbType.VarChar, obj.idno),
        //        CreateParameter("@otp", SqlDbType.VarChar, obj.otp),
        //    };
        //    return CreateCommand("SendOtp_Sp", parameters);
        //}

        internal static SqlCommand UserIDChangeFromIndia(UserIDChangeFromIndia_IP obj)
        {
            var parameters = new[]
            {
               CreateParameter("@Regid", SqlDbType.Int, obj.Regid),
               CreateParameter("@OldIdno", SqlDbType.VarChar, obj.OldIdno),
               CreateParameter("@NewIdno", SqlDbType.VarChar, obj.NewIdno),
               CreateParameter("@Remarks", SqlDbType.VarChar, obj.Remarks),
               CreateParameter("@GlobalUserId", SqlDbType.Int, obj.GlobalUserId),
               CreateParameter("@Session", SqlDbType.VarChar, obj.Session),
               CreateParameter("@IPAddress", SqlDbType.VarChar, obj.IPAddress),
               CreateParameter("@RegFrom", SqlDbType.VarChar, obj.RegFrom),
               CreateParameter("@Action", SqlDbType.VarChar, obj.Action),
               CreateParameter("@SprCnt", SqlDbType.Int, obj.SprCnt),
               CreateParameter("@RefCnt", SqlDbType.Int, obj.RefCnt)
            };

            return CreateCommand("ChangeUserFromIndia_SP", parameters);
        }

    }
}

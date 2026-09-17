using PAYLO_Classes;
using PAYLO_Classes.Common;
using PAYLO_Classes.Common.CMS;
using Microsoft.Data.SqlClient;
using PAYLO_Classes.Admin;

namespace PAYLO_Dal
{
    internal partial class ObjectFactory
    {
        internal static ResultData CommonOutput(SqlDataReader reader)
        {
            ResultData obj = new ResultData();

            if (Convert.IsDBNull(reader["Result"]))
                obj.result = string.Empty;
            else
                obj.result = (string)reader["Result"];
            return obj;
        }

        internal static SEOMeta SeoTagsBy(SqlDataReader reader)
        {
            SEOMeta seoMeta = new SEOMeta();

            if (Convert.IsDBNull(reader["ProdSEOID"]))
                seoMeta.ProdSEOID = 0;
            else
                seoMeta.ProdSEOID = (int)reader["ProdSEOID"];

            if (Convert.IsDBNull(reader["ProdDetID"]))
                seoMeta.ProdDetID = 0;
            else
                seoMeta.ProdDetID = (int)reader["ProdDetID"];

            if (Convert.IsDBNull(reader["PageTitle"]))
                seoMeta.PageTitle = string.Empty;
            else
                seoMeta.PageTitle = (string)reader["PageTitle"];

            if (Convert.IsDBNull(reader["Routing"]))
                seoMeta.Routing = string.Empty;
            else
                seoMeta.Routing = (string)reader["Routing"];

            if (Convert.IsDBNull(reader["Title"]))
                seoMeta.Title = string.Empty;
            else
                seoMeta.Title = (string)reader["Title"];

            if (Convert.IsDBNull(reader["Url"]))
                seoMeta.Url = string.Empty;
            else
                seoMeta.Url = (string)reader["Url"];

            if (Convert.IsDBNull(reader["Description"]))
                seoMeta.Description = string.Empty;
            else
                seoMeta.Description = (string)reader["Description"];

            if (Convert.IsDBNull(reader["Keyword"]))
                seoMeta.Keyword = string.Empty;
            else
                seoMeta.Keyword = (string)reader["Keyword"];

            return seoMeta;
        }

        internal static ImageCollection ImageCollectionByImgCatID(SqlDataReader reader)
        {
            ImageCollection imageCollection = new ImageCollection();

            if (Convert.IsDBNull(reader["ImageID"]))
                imageCollection.ImageID = 0;
            else
                imageCollection.ImageID = (int)reader["ImageID"];

            if (Convert.IsDBNull(reader["Title"]))
                imageCollection.Title = string.Empty;
            else
                imageCollection.Title = (string)reader["Title"];

            if (Convert.IsDBNull(reader["AltText"]))
                imageCollection.AltText = string.Empty;
            else
                imageCollection.AltText = (string)reader["AltText"];

            if (Convert.IsDBNull(reader["ImageUrl"]))
                imageCollection.ImageUrl = string.Empty;
            else
                imageCollection.ImageUrl = (string)reader["ImageUrl"];

            if (Convert.IsDBNull(reader["DisplayStatus"]))
                imageCollection.DisplayStatus = 0;
            else
                imageCollection.DisplayStatus = (int)reader["DisplayStatus"];

            if (Convert.IsDBNull(reader["DisplayOrder"]))
                imageCollection.DisplayOrder = 0;
            else
                imageCollection.DisplayOrder = (int)reader["DisplayOrder"];

            return imageCollection;
        }

        internal static DropDownCommonOutputParams Admin_GetSCMForFPO(SqlDataReader reader)
        {
            DropDownCommonOutputParams obj = new DropDownCommonOutputParams();

            if (Convert.IsDBNull(reader["Name"]))
                obj.Name = string.Empty;
            else
                obj.Name = (string)reader["Name"];

            if (Convert.IsDBNull(reader["ID"]))
                obj.ID = 0;
            else
                obj.ID = (int)reader["ID"];

            return obj;
        }
        internal static DropDownCommonOutputParams CommonDropDown(SqlDataReader reader)
        {
            DropDownCommonOutputParams obj = new DropDownCommonOutputParams();

            if (Convert.IsDBNull(reader["Name"]))
                obj.Name = string.Empty;
            else
                obj.Name = (string)reader["Name"];

            if (Convert.IsDBNull(reader["ID"]))
                obj.ID = 0;
            else
                obj.ID = (int)reader["ID"];

            return obj;
        }
        
        //internal static AuthResult GetTokenDetails(SqlDataReader reader)
        //{
        //    AuthResult authResult = new AuthResult();

        //    if (Convert.IsDBNull(reader["Access_Token"]))
        //        authResult.access_token = string.Empty;
        //    else
        //        authResult.access_token = (string)reader["Access_Token"];

        //    if (Convert.IsDBNull(reader["Token_Type"]))
        //        authResult.token_type = string.Empty;
        //    else
        //        authResult.token_type = (string)reader["Token_Type"];

        //    if (Convert.IsDBNull(reader["Expiry"]))
        //        authResult.expiry = string.Empty;
        //    else
        //        authResult.expiry = (string)reader["Expiry"];

        //    return authResult;
        //}
       
        //internal static CommonOutput CommonOutputObjectFactory(SqlDataReader reader)
        //{
        //    CommonOutput obj = new CommonOutput();

        //    if (Convert.IsDBNull(reader["Result"]))
        //        obj.Result = string.Empty;
        //    else
        //        obj.Result = (string)reader["Result"];

        //    if (Convert.IsDBNull(reader["Message"]))
        //        obj.Message = string.Empty;
        //    else
        //        obj.Message = (string)reader["Message"];


        //    if (ColumnExists(reader, "RefNo"))
        //    {
        //        obj.RefNo = Convert.IsDBNull(reader["RefNo"]) ? string.Empty : (string)reader["RefNo"];
        //    }
        //    else
        //    {
        //        obj.RefNo = string.Empty;
        //    }
        //    if (ColumnExists(reader, "InvNo"))
        //    {
        //        obj.InvNo = Convert.IsDBNull(reader["InvNo"]) ? string.Empty : (string)reader["InvNo"];
        //    }
        //    else
        //    {
        //        obj.InvNo = string.Empty;
        //    }



        //    return obj;
        //}
        public static bool ColumnExists(SqlDataReader reader, string columnName)
        {
            try
            {
                return reader.GetOrdinal(columnName) >= 0;
            }
            catch (IndexOutOfRangeException)
            {
                return false; // Column does not exist
            }
        }

       

        internal static IdVerification_OP IdVerificationItem(SqlDataReader reader)
        {
            //Idno	Name	Mobile	Address	Status

            IdVerification_OP Items = new IdVerification_OP();

            if (Convert.IsDBNull(reader["Idno"]))
                Items.IdNo = null;
            else
                Items.IdNo = (string)reader["Idno"];

            if (Convert.IsDBNull(reader["Name"]))
                Items.Name = null;
            else
                Items.Name = (string)reader["Name"];

            if (Convert.IsDBNull(reader["Mobile"]))
                Items.Mobile = null;
            else
                Items.Mobile = (string)reader["Mobile"];

            if (Convert.IsDBNull(reader["Address"]))
                Items.Address = null;
            else
                Items.Address = (string)reader["Address"];


            if (Convert.IsDBNull(reader["Status"]))
                Items.Status = null;
            else
                Items.Status = (string)reader["Status"];

            return Items;
        }

        internal static LinksOutput LinksItemFactory(SqlDataReader reader)
        {
            //IESPUser espuserItem = new ESPUser();
            LinksOutput menuItem = new LinksOutput();

            menuItem.Lid = (Int32)reader["Lid"];
            if (Convert.IsDBNull(reader["LinkName"]))
                menuItem.LinkName = null;
            else
                menuItem.LinkName = (string)reader["LinkName"];

            if (Convert.IsDBNull(reader["Pagename"]))
                menuItem.Pagename = null;
            else
                menuItem.Pagename = (string)reader["Pagename"];

            if (Convert.IsDBNull(reader["DispPage"]))
                menuItem.DispPage = null;
            else
                menuItem.DispPage = (string)reader["DispPage"];

            if (Convert.IsDBNull(reader["Icon"]))
                menuItem.Icon = null;
            else
                menuItem.Icon = (string)reader["Icon"];

            menuItem.Parent = (Int32)reader["Parent"];
            menuItem.sorting = (Int32)reader["sorting"];

            return menuItem;
        }
        internal static DropDownDetails_OP DropdownItemFactory(SqlDataReader reader)
        {
            DropDownDetails_OP dd = new DropDownDetails_OP();

            dd.Value = (int)reader["Value"];

            if (Convert.IsDBNull(reader["Text"]))
                dd.Text = null;
            else
                dd.Text = (string)reader["Text"];

            return dd;
        }
        internal static CheckUserID_OutPut CheckUserIDItemFactory(SqlDataReader reader)
        {
            CheckUserID_OutPut Items = new CheckUserID_OutPut();

            Items.regid = (Int32)reader["regid"];

            if (Convert.IsDBNull(reader["result"]))
                Items.result = null;
            else
                Items.result = (string)reader["result"];

            return Items;
        }
    }

}

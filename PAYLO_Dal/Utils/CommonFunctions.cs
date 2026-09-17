using System.Text;

namespace PAYLO_Dal
{
    public class CommonFunctions
    {


        public string GetRandomNumber(int maxlen)
        {

            var rnd = new Random();
            int length = maxlen;
            string charPool = "1234567890";
            var rs = new StringBuilder();
            while (length-- > 0)
                rs.Append(charPool[(int)(rnd.NextDouble() * charPool.Length)]);
            return rs.ToString();
        }

        public string GetRandomString(int maxlen)
        {

            var rnd = new Random();
            int length = maxlen;
            string charPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var rs = new StringBuilder();
            while (length-- > 0)
                rs.Append(charPool[(int)(rnd.NextDouble() * charPool.Length)]);
            return rs.ToString();
        }


        //public string E_InvoiceInsert(string ReqData, string GSTNo, string Email, string OAuthToken, string OrderNo, int CreatedBy, string UserType, string UserName, string Password, string ClientId, string ClientSecret, string Action)
        //{

        //    string resultdata = "ERROR";
        //    string URL = "";
        //    string OAuthURL = "";
        //    string OAuthResponse = "";
        //    //E_InvoiceOAuthResponse OAutEInvoiceResp = new E_InvoiceOAuthResponse();

        //    try
        //    {
        //        if (OAuthToken == "")
        //        {
        //            if (ConEnvironment.ToUpper().Equals("STAG") || ConEnvironment.ToUpper().Equals("DEV"))   //Staging
        //            {
        //                OAuthURL = "https://api.mastergst.com/einvoice/authenticate";

        //            }
        //            else if (ConEnvironment.ToUpper().Equals("PROD"))   //Live
        //            {
        //                OAuthURL = "";
        //            }

        //            OAuthResponse = TokenAuthentication(OAuthURL, "GET", GSTNo, Email, UserName, Password, ClientId, ClientSecret);
        //            E_InvoiceOAuthResponse? OAutEInvoiceResp = JsonConvert.DeserializeObject<E_InvoiceOAuthResponse>(OAuthResponse);
        //            resultdata = VLCCWellScienceDal.Instance.CommonService.E_Inv_Gen(ConEnvironment, "Insert", OAuthResponse, OAutEInvoiceResp.data.AuthToken, OAutEInvoiceResp.data.TokenExpiry, CreatedBy, GSTNo);

        //            E_InvoicePlayLoadData? dt = JsonConvert.DeserializeObject<E_InvoicePlayLoadData>(VLCCWellScienceDal.Instance.CommonService.E_Inv_GenData(ConEnvironment, Action, OrderNo, UserType));

        //            if (dt.Result == "SUCCESS")
        //            {
        //                GSTNo = dt.E_GSTIN;
        //                ReqData = dt.InvBody;
        //                OAuthToken = dt.E_OAuthKey;
        //                UserName = dt.UserName;
        //                Password = dt.Password;
        //                ClientId = dt.ClientID;
        //                ClientSecret = dt.ClientSecret;
        //                OAuthToken = dt.E_OAuthKey;
        //            }
        //        }

        //        if (OAuthToken != "")
        //        {
        //            if (ConEnvironment.ToUpper().Equals("STAG") || ConEnvironment.ToUpper().Equals("DEV"))   //Staging
        //            {
        //                URL = "https://api.mastergst.com/einvoice/type/GENERATE/version/V1_03";
        //            }
        //            else if (ConEnvironment.ToUpper().Equals("PROD"))   //Live
        //            {
        //                URL = "";
        //            }
        //            string responseData = CallRestJsonServiceWithString(URL, ReqData, "POST", OAuthToken, GSTNo, Email, UserName, Password, ClientId, ClientSecret);

        //            E_InvRes? r = JsonConvert.DeserializeObject<E_InvRes>(responseData);
        //            string AcKNo = "";
        //            string AcKDate = null;
        //            string EwbValidTill = null;
        //            string IRN = "";
        //            string SignedInvoice = "";
        //            string SignedQrCode = "";
        //            if (r.status_cd == "1")
        //            {
        //                AcKNo = r.data.AckNo;
        //                AcKDate = r.data.AckDt;
        //                IRN = r.data.Irn;
        //                SignedInvoice = r.data.SignedInvoice;
        //                SignedQrCode = r.data.SignedQRCode;
        //                resultdata = VLCCWellScienceDal.Instance.CommonService.EInvResponseDetails(ConEnvironment, OrderNo, URL, ReqData, GSTNo, OAuthToken, responseData, AcKNo, AcKDate, EwbValidTill, IRN, SignedInvoice, SignedQrCode, "E_INVGEN", CreatedBy, UserType);
        //            }
        //            else
        //            {

        //                resultdata = VLCCWellScienceDal.Instance.CommonService.EInvResponseDetails(ConEnvironment, OrderNo, URL, ReqData, GSTNo, OAuthToken, responseData, AcKNo, AcKDate, EwbValidTill, IRN, SignedInvoice, SignedQrCode, "E_INVGEN", CreatedBy, UserType);
        //                resultdata = "ERROR";
        //            }

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        resultdata = e.Message.ToString();
        //    }
        //    return resultdata;
        //}

        //public string E_InvoiceCancel(string ReqData, string GSTNo, string Email, string OAuthToken, string OrderNo, int CreatedBy, string UserType, string UserName, string Password, string ClientId, string ClientSecret, string Action)
        //{

        //    string resultdata = "ERROR";
        //    string URL = "";
        //    string OAuthURL = "";
        //    string OAuthResponse = "";
        //    // E_InvoiceOAuthResponse OAutEInvoiceResp = new E_InvoiceOAuthResponse();

        //    try
        //    {
        //        if (OAuthToken == "")
        //        {
        //            if (ConEnvironment.ToUpper().Equals("STAG") || ConEnvironment.ToUpper().Equals("DEV"))   //Staging
        //            {
        //                OAuthURL = "https://api.mastergst.com/einvoice/authenticate";

        //            }
        //            else if (ConEnvironment.ToUpper().Equals("PROD"))   //Live
        //            {
        //                OAuthURL = "";
        //            }

        //            OAuthResponse = TokenAuthentication(OAuthURL, "GET", GSTNo, Email, UserName, Password, ClientId, ClientSecret);
        //            E_InvoiceOAuthResponse? OAutEInvoiceResp = JsonConvert.DeserializeObject<E_InvoiceOAuthResponse>(OAuthResponse);
        //            resultdata = VLCCWellScienceDal.Instance.CommonService.E_Inv_Gen(ConEnvironment, "Insert", OAuthResponse, OAutEInvoiceResp.data.AuthToken, OAutEInvoiceResp.data.TokenExpiry, CreatedBy, GSTNo);

        //            E_InvoicePlayLoadData? dt = JsonConvert.DeserializeObject<E_InvoicePlayLoadData>(VLCCWellScienceDal.Instance.CommonService.E_Inv_GenData(ConEnvironment, Action, OrderNo, UserType));

        //            if (dt.Result == "SUCCESS")
        //            {
        //                GSTNo = dt.E_GSTIN;
        //                ReqData = dt.InvBody;
        //                OAuthToken = dt.E_OAuthKey;
        //                UserName = dt.UserName;
        //                Password = dt.Password;
        //                ClientId = dt.ClientID;
        //                ClientSecret = dt.ClientSecret;
        //                OAuthToken = dt.E_OAuthKey;
        //            }
        //        }

        //        if (OAuthToken != "")
        //        {
        //            if (ConEnvironment.ToUpper().Equals("STAG") || ConEnvironment.ToUpper().Equals("DEV"))   //Staging
        //            {
        //                URL = "https://api.mastergst.com//einvoice/type/CANCEL/version/V1_03";
        //            }
        //            else if (ConEnvironment.ToUpper().Equals("PROD"))   //Live
        //            {
        //                URL = "";
        //            }
        //            string responseData = CallRestJsonServiceWithString(URL, ReqData, "POST", OAuthToken, GSTNo, Email, UserName, Password, ClientId, ClientSecret);

        //            E_InvRes? r = JsonConvert.DeserializeObject<E_InvRes>(responseData);
        //            string AcKNo = "";
        //            string AcKDate = null;
        //            string EwbValidTill = null;
        //            string IRN = "";
        //            string SignedInvoice = "";
        //            string SignedQrCode = "";
        //            if (r.status_cd == "1")
        //            {
        //                AcKNo = "";
        //                EwbValidTill = r.data.CancelDate;
        //                IRN = r.data.Irn;
        //                SignedInvoice = "";
        //                SignedQrCode = "";
        //                resultdata = VLCCWellScienceDal.Instance.CommonService.EInvResponseDetails(ConEnvironment, OrderNo, URL, ReqData, GSTNo, OAuthToken, responseData, AcKNo, AcKDate, EwbValidTill, IRN, SignedInvoice, SignedQrCode, "E_INVCAN", CreatedBy, UserType);
        //            }
        //            else
        //            {

        //                resultdata = VLCCWellScienceDal.Instance.CommonService.EInvResponseDetails(ConEnvironment, OrderNo, URL, ReqData, GSTNo, OAuthToken, responseData, AcKNo, AcKDate, EwbValidTill, IRN, SignedInvoice, SignedQrCode, "E_INVCAN", CreatedBy, UserType);
        //                resultdata = "ERROR";
        //            }

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        resultdata = e.Message.ToString();
        //    }
        //    return resultdata;
        //}


        //public string E_WayBillInsert(string ReqData, string GSTNo, string Email, string OAuthToken, string OrderNo, int CreatedBy, string UserType, string UserName, string Password, string ClientId, string ClientSecret, string Action)
        //{

        //    string resultdata = "ERROR";
        //    string URL = "";
        //    string OAuthURL = "";
        //    string OAuthResponse = "";
        //    // E_InvoiceOAuthResponse OAutEInvoiceResp = new E_InvoiceOAuthResponse();

        //    try
        //    {
        //        if (OAuthToken == "")
        //        {
        //            if (ConEnvironment.ToUpper().Equals("STAG") || ConEnvironment.ToUpper().Equals("DEV"))   //Staging
        //            {
        //                OAuthURL = "https://api.mastergst.com/einvoice/authenticate";

        //            }
        //            else if (ConEnvironment.ToUpper().Equals("PROD"))   //Live
        //            {
        //                OAuthURL = "";
        //            }

        //            OAuthResponse = TokenAuthentication(OAuthURL, "GET", GSTNo, Email, UserName, Password, ClientId, ClientSecret);
        //            E_InvoiceOAuthResponse? OAutEInvoiceResp = JsonConvert.DeserializeObject<E_InvoiceOAuthResponse>(OAuthResponse);
        //            resultdata = VLCCWellScienceDal.Instance.CommonService.E_Inv_Gen(ConEnvironment, "Insert", OAuthResponse, OAutEInvoiceResp.data.AuthToken, OAutEInvoiceResp.data.TokenExpiry, CreatedBy, GSTNo);

        //            E_InvoicePlayLoadData? dt = JsonConvert.DeserializeObject<E_InvoicePlayLoadData>(VLCCWellScienceDal.Instance.CommonService.E_Inv_GenData(ConEnvironment, Action, OrderNo, UserType));

        //            if (dt.Result == "SUCCESS")
        //            {
        //                GSTNo = dt.E_GSTIN;
        //                ReqData = dt.InvBody;
        //                OAuthToken = dt.E_OAuthKey;
        //                UserName = dt.UserName;
        //                Password = dt.Password;
        //                ClientId = dt.ClientID;
        //                ClientSecret = dt.ClientSecret;
        //                OAuthToken = dt.E_OAuthKey;
        //            }
        //        }

        //        if (OAuthToken != "")
        //        {
        //            if (ConEnvironment.ToUpper().Equals("STAG") || ConEnvironment.ToUpper().Equals("DEV"))   //Staging
        //            {
        //                URL = "https://api.mastergst.com/einvoice/type/GENERATE_EWAYBILL/version/V1_03";
        //            }
        //            else if (ConEnvironment.ToUpper().Equals("PROD"))   //Live
        //            {
        //                URL = "";
        //            }
        //            string responseData = CallRestJsonServiceWithString(URL, ReqData, "POST", OAuthToken, GSTNo, Email, UserName, Password, ClientId, ClientSecret);

        //            E_InvRes? r = JsonConvert.DeserializeObject<E_InvRes>(responseData);
        //            string AcKNo = "";
        //            string AcKDate = null;
        //            string EwbValidTill = null;
        //            string IRN = "";
        //            string SignedInvoice = "";
        //            string SignedQrCode = "";
        //            if (r.status_cd == "1")
        //            {
        //                AcKNo = r.data.EwbNo;
        //                AcKDate = r.data.EwbDt;
        //                EwbValidTill = r.data.EwbValidTill;
        //                IRN = r.data.Irn;
        //                SignedInvoice = "";
        //                SignedQrCode = "";
        //                resultdata = VLCCWellScienceDal.Instance.CommonService.EInvResponseDetails(ConEnvironment, OrderNo, URL, ReqData, GSTNo, OAuthToken, responseData, AcKNo, AcKDate, EwbValidTill, IRN, SignedInvoice, SignedQrCode, "E_WAYBill", CreatedBy, UserType);
        //            }
        //            else
        //            {

        //                resultdata = VLCCWellScienceDal.Instance.CommonService.EInvResponseDetails(ConEnvironment, OrderNo, URL, ReqData, GSTNo, OAuthToken, responseData, AcKNo, AcKDate, EwbValidTill, IRN, SignedInvoice, SignedQrCode, "E_WAYBill", CreatedBy, UserType);
        //                resultdata = "ERROR";
        //            }

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        resultdata = e.Message.ToString();
        //    }
        //    return resultdata;
        //}


        
       
    }
}

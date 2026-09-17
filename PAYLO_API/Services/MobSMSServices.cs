namespace PAYLO_API.Services
{
    public class MobSMSServices
    {
        //public async static Task<JsonResult> SendOTPSMS(SMSData SMS, SMSLog sMSLog,string  ConEnvironment)
        //{
        //    try
        //    {
        //        var SMSAPISettings = Config.GetSection("SMSAPIData").Get<SMSOTPKeys>();

        //        string Url = SMSAPISettings.Url;
        //        string UserName = SMSAPISettings.UserName;
        //        string Password = SMSAPISettings.Password;

        //        string SMSUrl = $"{Url}?username={UserName}&password={Password}&source={sMSLog.SenderID}&dmobile={SMS.MobileNo}&dlttempid={sMSLog.TemplateID}&message={SMS.Message}";

        //        using var client = new HttpClient();
        //        client.BaseAddress = new Uri(Url);
        //        var response = await client.GetAsync(SMSUrl);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result = new { Status = "SUCCESS", Msg = "OTP Sent to Mobile Number" };

        //            sMSLog.Remarks = $"{result.Status} - {result.Msg}";
        //            SaveSMSLog(sMSLog, ConEnvironment);

        //            return new JsonResult(result);
        //        }
        //        else
        //        {
        //            var result = new { Status = "FAILED", Msg = "OTP Sent Failed" };

        //            sMSLog.Remarks = $"{result.Status} - {result.Msg}";
        //            SaveSMSLog(sMSLog, ConEnvironment);

        //            return new JsonResult(result);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var result = new { Status = "FAILED", Msg = "OTP Sent Failed" };

        //        sMSLog.Remarks = $"{result.Status} - SendOTPSMS - {ex.Message}";
        //        SaveSMSLog(sMSLog, ConEnvironment);

        //        return new JsonResult(result);
        //    }
        //}




        //public static string SaveSMSLog(SMSLog sMSLog,string ConEnvironment)
        //{
        //    string apiResponse = string.Empty;

        //    PAYLODAL.Instance.CommonService.SaveSMSLog(ConEnvironment, sMSLog, out IDictionary<String, Object> outParameters);

        //    if (outParameters != null)
        //    {
        //        foreach (var outParameter in outParameters)
        //        {
        //            if (outParameter.Key.Equals("@RtnMsg"))
        //                apiResponse = outParameter.Value.ToString();
        //        }
        //    }
        //    else
        //    {
        //        apiResponse = "0";
        //    }



        //    return apiResponse;
        //}


        //public async static Task<JsonResult> SendSMS(SMSData SMS, SMSLog sMSLog, string ConEnvironment)
        //{
        //    try
        //    {
        //        var SMSAPISettings = Config.GetSection("SMSAPIData").Get<SMSOTPKeys>();

        //        string Url = SMSAPISettings.Url;
        //        string UserName = SMSAPISettings.UserName;
        //        string Password = SMSAPISettings.Password;

        //        string SMSUrl = $"{Url}?username={UserName}&password={Password}&source={sMSLog.SenderID}&dmobile={SMS.MobileNo}&dlttempid={sMSLog.TemplateID}&message={SMS.Message}";

        //        using var client = new HttpClient();
        //        client.BaseAddress = new Uri(Url);
        //        var response = await client.GetAsync(SMSUrl);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result = new { Status = "SUCCESS", Msg = "SMS Sent Successfully" };

        //            sMSLog.Remarks = $"{result.Status} - {result.Msg}";
        //            SaveSMSLog(sMSLog, ConEnvironment);

        //            return new JsonResult(result);
        //        }
        //        else
        //        {
        //            var result = new { Status = "FAILED", Msg = "SMS Sent Failed" };

        //            sMSLog.Remarks = $"{result.Status} - {result.Msg}";
        //            SaveSMSLog(sMSLog, ConEnvironment);

        //            return new JsonResult(result);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var result = new { Status = "FAILED", Msg = "SMS Sent Failed" };

        //        sMSLog.Remarks = $"{result.Status} - SendSMS - {ex.Message}";
        //        SaveSMSLog(sMSLog, ConEnvironment);

        //        return new JsonResult(result);
        //    }
        //}
    }
}

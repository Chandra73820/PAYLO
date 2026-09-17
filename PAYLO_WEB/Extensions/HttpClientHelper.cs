namespace PAYLO_WEB.Extensions
{
    public class HttpClientHelper
    {
        public static HttpClient GetHttpClient()
        {
            var MyHttpClient = new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true
            });
            return MyHttpClient;

        }
    }
}

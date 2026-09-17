using System.Text.Json;

namespace PAYLO_API.Models
{
    public class ErrorDetails
    {
        /// <summary>
        /// Get or Set the Error Code
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Get or Set the Error Message
        /// </summary>
        public string Message { get; set; }
        public string CorrelationId { get; set; } = "";
        public ErrorDetails()
        {
            StatusCode = 0;
            Message = string.Empty;
        }

        public ErrorDetails(int statusCode, string code, string message)
        {
            StatusCode = statusCode;
            Message = string.Format("{0}{1}: {2}", code, statusCode, message);
        }

        public override string ToString()
        {
            ////var json = Newtonsoft.Json.JsonConvert.SerializeObject(response);
            return JsonSerializer.Serialize(this);
        }
    }
}

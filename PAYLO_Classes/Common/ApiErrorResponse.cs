
namespace PAYLO_Classes.Common
{
    public class ApiErrorResponse : IApiErrorResponse
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = "";
        public string CorrelationId { get; set; } = "";

        public void SetErrorMessage(string message) => Message = message;
    }
}

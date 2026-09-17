namespace PAYLO_Classes.Common
{
    public class ApiLog : Session_IPAdd
    {
        public string ApiType { get; set; }
        public string ApiResponse { get; set; }
        public string Exception { get; set; }
        public string ApiStatus { get; set; }

    }
}

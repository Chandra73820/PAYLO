using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Common
{
    public class ErrorLogEntry
    {
        public string CorrelationId { get; set; }
        public string MachineName { get; set; }
        public string Application { get; set; }
        public string Environment { get; set; }
        public string HttpMethod { get; set; }
        public string RequestPath { get; set; }
        public string QueryString { get; set; }
        public int? StatusCode { get; set; }
        public string ClientIp { get; set; }
        public string UserAgent { get; set; }
        public string UserIdentity { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }
        public string RequestBody { get; set; }
        public string AdditionalData { get; set; }
    }
}

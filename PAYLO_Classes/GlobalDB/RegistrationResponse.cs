using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAYLO_Classes.Common;

namespace PAYLO_Classes
{
    public class RegistrationResponse : IApiErrorResponse
    {
        public string Meg { get; set; } = "FAILED";
        public string Result { get; set; } = "";
        public int ResAutoid { get; set; } = 0;
        public int Regid { get; set; } = 0;
        public void SetErrorMessage(string message) => Result = message;
    }
}

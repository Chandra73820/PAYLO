using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAYLO_Classes.Common;

namespace PAYLO_Classes.GlobalDB
{
    public class SendOTPResponse : IApiErrorResponse
    {
        public int OTP { get; set; } = 0;
        public string Message { get; set; } = "";
        public string Result { get; set; } = "";
        public void SetErrorMessage(string message) => Message = message;

    }
}

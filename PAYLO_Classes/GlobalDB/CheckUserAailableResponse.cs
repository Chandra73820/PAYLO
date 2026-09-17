using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAYLO_Classes.Common;

namespace PAYLO_Classes.GlobalDB
{
    public class CheckUserAailableResponse : IApiErrorResponse
    {
        public int Success { get; set; } = 0;
        public string Message { get; set; } = "";
        public void SetErrorMessage(string message)=>Message = message;
         
    }
}

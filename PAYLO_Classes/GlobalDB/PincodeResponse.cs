using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAYLO_Classes.Common;

namespace PAYLO_Classes
{
    public class PincodeResponse : IApiErrorResponse
    {
        public string Message { get; set; } = "";
        public int PinCode { get; set; }

        public int DistrictID { get; set; }

        public string? DistrictName { get; set; }

        public int StateId { get; set; }

        public string? StateName { get; set; }
        public void SetErrorMessage(string message) => Message = message;
    }
}

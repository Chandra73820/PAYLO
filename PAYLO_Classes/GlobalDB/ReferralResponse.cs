using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAYLO_Classes.Common;

namespace PAYLO_Classes
{
    public class ReferralResponse : IApiErrorResponse
    {
        public string Message { get; set; } = "";
        public int Sprno { get; set; } = 0;
        public string SprId { get; set; } = "";
        public string SprName { get; set; } = "";
        public string IdRegFrom { get; set; } = "";

        public void SetErrorMessage(string message) => Message = message;
    }
}

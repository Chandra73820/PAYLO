using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAYLO_Classes.Common;

namespace PAYLO_Classes
{
    public class SponserResponse: IApiErrorResponse
    {
        public string Message { get; set; } = "";
        public int Sprno { get; set; } = 0;
        public string SprId { get; set; } = "";
        public string SprName { get; set; } = "";
        public string SprFrom { get; set; } = "";
        public string Downto { get; set; } = "";
        public string DowntoName { get; set; } = "";
        public string DwnFrom { get; set; } = "";

        public void SetErrorMessage(string message) => Message = message;
    }
}

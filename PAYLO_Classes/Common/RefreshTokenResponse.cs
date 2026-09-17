using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYLO_Classes.Common
{
    public class RefreshTokenResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public string AccessTokenExpiry { get; set; } = string.Empty;  //  string not DateTime
        public string SessionId { get; set; } = string.Empty;  //  add sessionId
        public string RefreshToken { get; set; } = string.Empty;
        public string RefreshTokenExpiry { get; set; } = string.Empty;  //  string not DateTime
    }
}

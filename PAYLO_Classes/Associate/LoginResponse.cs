using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAYLO_Classes.Enums;

namespace PAYLO_Classes.Associate
{
    public class LoginResponse
    {


        public int RegID { get; set; }
        public string MemberID { get; set; }
        public string Name { get; set; }
        public string Msg { get; set; }
        public string? accessToken { get; set; }
        public string? accessTokenExpiry { get; set; }
        public string? sessionId { get; set; }
        public string? UserType { get; set; }
        public string? RefreshToken { get; set; }
        public string? RefreshTokenExpiry { get; set; }

    }

}

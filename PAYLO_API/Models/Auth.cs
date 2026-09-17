using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PAYLO_API.Models
{
    public class Auth : IAuth
    {
        private readonly string Key;

        public Auth(string key)
        {
            this.Key = key;
        }

        public string Authentication(string UserName, string Idno)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // UTF-8 encoding — safe for all Unicode key characters
            var tokenKey = Encoding.UTF8.GetBytes(Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, UserName),
                    new Claim("IdNo", Idno)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Util
{
    public class StringUtil
    {
        private IConfiguration _config;
        public StringUtil(IConfiguration config)
        {
            _config = config;
        }
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        public string GenerateToken(string email, long idPersona)
        {
            var key = _config["JWT:Key"];
            var Issuer = _config["JWT:Issuer"];
            var Audience = _config["JWT:Audience"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("email",email),
                new Claim("idPersona",idPersona.ToString()),
            };
            var token = new JwtSecurityToken(Issuer,
                Audience,
                claims,
                expires: DateTime.Now.AddMinutes(150),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }

}

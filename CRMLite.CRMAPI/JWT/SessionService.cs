using CRMLite.CRMCore.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CRMLite.CRMAPI.JWT
{
    public class SessionService: ISessionService
    {
        private readonly AppSettings _appSettings;

        public SessionService(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        public async Task<string> CreateAuthTokenAsync(Lead lead)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var claims = lead.Role.Select(role => new Claim(ClaimTypes.Role, role.ToString())).ToList();
            claims.Add(new Claim(ClaimTypes.Name, lead.Id.ToString()));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

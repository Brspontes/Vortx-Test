using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VxTel.API.Configs;
using VxTel.Domain.Commands.Outputs;

namespace VxTel.API.Services
{
    public class TokenService
    {
        private readonly IOptions<KeySecret> keySecret;

        public TokenService(IOptions<KeySecret> keySecret)
        {
            this.keySecret = keySecret;
        }

        public string GenerateToken(OutLogin user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(keySecret.Value.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Login.ToString()),
                    new Claim(ClaimTypes.Role, user.Permissoes.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

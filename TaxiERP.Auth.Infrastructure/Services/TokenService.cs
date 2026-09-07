using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaxiERP.Auth.Application.Interfaces;
using TaxiERP.Auth.Domain.Entities;

namespace TaxiERP.Auth.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public string GerarToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var chaveSecreta = Encoding.ASCII.GetBytes(_configuration["JWT_SECRET"]);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email.ToString()),
                new Claim("OrganizacaoId", usuario.OrganizacaoId.ToString()),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(
                   new SymmetricSecurityKey(chaveSecreta),
                   SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

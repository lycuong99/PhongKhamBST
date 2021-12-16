using Data.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Services.Implementations
{
    public class TokenService : ITokenService
    {
        private const double EXP_DURATION_MINUTES = 30;
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> BuildToken(string key, string issuer, User user)
        {
            var claims = new[]
            {
               new Claim(ClaimTypes.Name, user.Email),
               new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
               new Claim(ClaimTypes.Role, user.Role),
           };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:AuthCustom:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new JwtSecurityToken( issuer: issuer, 
                                                        audience: issuer, 
                                                        claims, 
                                                        expires: DateTime.Now.AddMinutes(EXP_DURATION_MINUTES),
                                                        signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}

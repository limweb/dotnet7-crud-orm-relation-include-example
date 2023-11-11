using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using crudapp.Models;
using Microsoft.IdentityModel.Tokens;

namespace crudapp.Services
{
     public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string  GenJwtToken(LoginModel user) {

                var claims = new List<Claim>();
                claims.Add(new Claim("id", "1"));
                claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.username));
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                claims.Add(new Claim(ClaimTypes.GivenName, "Super"));
                claims.Add(new Claim(ClaimTypes.Surname, "User"));

                string[] roles = new string[] { "admin","dev" };
                foreach (var role in roles)
                    claims.Add(new Claim("roles", role));

                var secureKey = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var securityKey = new SymmetricSecurityKey(secureKey);
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
                var jwtTokenHandler = new JwtSecurityTokenHandler();
                //https://datatracker.ietf.org/doc/html/rfc7519#section-4.1.1
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddMinutes(15),
                    Audience = audience,
                    Issuer = issuer,
                    SigningCredentials = credentials
                };
                var token = jwtTokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = jwtTokenHandler.WriteToken(token);
                return jwtToken;
        }


    }
}
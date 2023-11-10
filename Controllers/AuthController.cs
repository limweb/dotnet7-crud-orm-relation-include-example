using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using crudapp.Models;
using crudapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace crudapp.Controllers
{
    [ApiController]
    [Route("api")]
    public class AuthController : ControllerBase
    {
         private readonly IConfiguration _configuration;
         private IJwtService  _jwtservice;

        public AuthController(IConfiguration congig,IJwtService jwtsrv)
        {
            _configuration = congig;
            _jwtservice = jwtsrv;
        }

        
        [HttpPost("/login")]
        public IActionResult login(LoginModel user)
        {
            try {       

                var claims = new List<Claim>();
                claims.Add(new Claim("id", "1"));
                claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.username));
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                claims.Add(new Claim(ClaimTypes.GivenName, user.username));
                claims.Add(new Claim(ClaimTypes.Surname, user.password));

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
                // string jwtToken = await _jwtservice.GenJwtToken(user);
                return Ok(new  {
                    success = true,
                    status = 1,
                    message = "success",
                    datas = user,
                    token = jwtToken
                });

            } catch(System.Exception ex)  {
                return BadRequest(new
                {
                    status = 0,
                    success = false,
                    datas = new int[0],
                    message = ex.Message
                });
            }
        }

        [HttpPost("/verify")]
        public IActionResult login(string token){
            return Ok(token);
        }
    }
}
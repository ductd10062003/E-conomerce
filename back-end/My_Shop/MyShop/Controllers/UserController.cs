using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyShop.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyShopContext db;
        private readonly string secretKey;

        public UserController(IConfiguration configuration)
        {
            db = new MyShopContext();
            secretKey = configuration["AppSettings:SecretKey"];
        }

        [HttpPost("login")]
        public IActionResult Validate(User user)
        {
            var _user = db.Users.FirstOrDefault(u => u.UserEmail == user.UserEmail && u.UserPassword == user.UserPassword);
            if (_user == null)
            {
                return Ok(new
                {
                    Success = false,
                    Message = "Invalid username/password"
                });
            }

            return Ok(new
            {
                Success = true,
                Message = "Success",
                Data = GenerateToken(_user)
            });
        }

        private string GenerateToken(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("userId", user.UserId.ToString()),
                    new Claim("userName", user.UserName),
                    new Claim(ClaimTypes.Email, user.UserEmail),
                    new Claim("role", user.UserRole.ToString()),

                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);


            return jwtTokenHandler.WriteToken(token);
        }
    }
}

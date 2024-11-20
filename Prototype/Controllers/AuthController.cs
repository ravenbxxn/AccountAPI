using APIPrototype.Data;
using APIPrototype.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

namespace APIPrototype.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _configuration; // เพิ่ม IConfiguration

        public AuthController(AppDbContext db, IConfiguration configuration) // เพิ่ม IConfiguration ใน Constructor
        {
            _db = db;
            _configuration = configuration; // กำหนดค่า IConfiguration
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // ตรวจสอบว่ามีข้อมูลใน model หรือไม่
            if (model == null || string.IsNullOrWhiteSpace(model.Username) || string.IsNullOrWhiteSpace(model.Password))
            {
                return BadRequest("Username and password are required.");
            }

            // ค้นหาผู้ใช้จากฐานข้อมูล
            var user = _db.Mas_User.SingleOrDefault(u => u.Username == model.Username);
            if (user == null || !VerifyPasswordHash(model.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid username or password.");
            }

            // สร้าง JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]); // ดึง SecretKey จาก appsettings.json
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["JwtSettings:Issuer"], // ดึง Issuer
                Audience = _configuration["JwtSettings:Audience"] // ดึง Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            // ส่งคืน token และข้อมูลผู้ใช้
            return Ok(new 
            { 
                token = tokenHandler.WriteToken(token),
                user = new
                {
                    userID = user.Username 
                }
            });
        }

        private static bool VerifyPasswordHash(string password, string storedHash)
        {
            using (var sha256 = SHA256.Create())
            {
                var passwordBytes = Encoding.UTF8.GetBytes(password);
                var computedHash = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(computedHash) == storedHash;
            }
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            // ตรวจสอบว่ามีชื่อผู้ใช้ในระบบแล้วหรือไม่
            var existingUser = _db.Mas_User.SingleOrDefault(u => u.Username == model.Username);
            if (existingUser != null)
            {
                return Conflict("Username already exists.");
            }

            // แฮชรหัสผ่าน
            var passwordHash = HashPassword(model.Password);

            // สร้างผู้ใช้ใหม่
            var newUser = new Mas_User
            {
                Username = model.Username,
                PasswordHash = passwordHash
            };

            // เพิ่มผู้ใช้ใหม่ลงในฐานข้อมูล
            _db.Mas_User.Add(newUser);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Login), new { username = model.Username });
        }

        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var passwordBytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}

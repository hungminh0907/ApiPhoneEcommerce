using ApiPhoneEcommerce.Models.Authentication;
using ApiPhoneEcommerce.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace ApiPhoneEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly PhoneEcommerceContext _context;
        public AuthenticationController(IConfiguration configuration, PhoneEcommerceContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("auth")]
        public async Task<IActionResult> XacThuc([FromForm] InputUser input)
        {
            var item = await _context.TaiKhoans.FirstOrDefaultAsync(c => c.Email == input.Email
            && c.UserName == input.Username
            && c.PasswordHash == input.Password);

            if (item == null) return Unauthorized();

            var role = await _context.Roles.FirstOrDefaultAsync(r => r.UserName == input.Username);

            var token = GenerateJWT(item, role);

            return Ok(new OutputToken
            {
                Token = token,
                RefreshToken = null,
                InvokeToken = null,
                Times = null
            });
        }

        private string GenerateJWT(TaiKhoan taikhoan, Role role)
        {
            var security = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(security, SecurityAlgorithms.HmacSha256Signature);
            //var role = _context.Roles.FirstOrDefault(c => c.Id == taikhoan.Id);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Sid, taikhoan.Id),
                new Claim(ClaimTypes.Name, taikhoan.UserName),
                //new Claim(ClaimTypes.Role, "admin,users"),
                new Claim(ClaimTypes.Role, role.RoleName),
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Issuer"],
                claims,
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddMinutes(10)).DateTime,
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}

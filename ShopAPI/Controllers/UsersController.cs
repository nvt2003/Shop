using BusinessObjects.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Repositories.IRepository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        public UsersController(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            if (ModelState.IsValid)
            {
                UserViewModel user = _userRepository.Login(loginRequest);
                if (user == null)
                {
                    return Unauthorized("Invalid user credentials.");
                }

                var token = IssueToken(user);
                return Ok(new { Token = token });
            };
            return BadRequest("Invalid Request Body");
        }
        private string IssueToken(UserViewModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim("MyappUserId",user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Username),
                new Claim(JwtRegisteredClaimNames.Sub,user.Id.ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires:DateTime.Now.AddHours(1),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterRequest registerRequest)
        {
            if (_userRepository.Register(registerRequest))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Cannot created user.");
            }
        }
        [HttpGet]
        [Authorize]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userRepository.GetAllUsers();
                return Ok(users);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

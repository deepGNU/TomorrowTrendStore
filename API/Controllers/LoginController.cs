using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private const string secretPath = "Authentication:Secret";
        private const string issuerPath = "Authentication:Issuer";
        private const string audiencePath = "Authentication:Audience";
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public LoginController(IUserRepository repository, IConfiguration configuration, ILogger<LoginController> logger)
        {
            _userRepo = repository ?? throw new ArgumentNullException(nameof(repository));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        [HttpPost]
        public IActionResult Login(LoginInfo loginInfo)
        {
            try
            {
                User? user = _userRepo.GetAuthenticatedUser(loginInfo);

                if (user == null)
                {
                    return Unauthorized();
                }

                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration[secretPath] ?? throw new ArgumentNullException("Null configuration", nameof(_configuration))));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim("sub", user.Id.ToString()),
                    new Claim("username", user.Username),
                    new Claim("given_name", user.FirstName),
                    new Claim("family_name", user.LastName),
                    new Claim("role", user.Type.ToString()),
                };

                var token = new JwtSecurityToken(
                    _configuration[issuerPath],
                    _configuration[audiencePath],
                    claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: creds
                    );

                var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(tokenStr);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Error: {mssg}", ex.Message);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}

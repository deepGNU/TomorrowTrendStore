using API.Models;
using API.Repositories;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(IUserRepository userRepository, ILogger<RegisterController> logger)
        {
            _userRepo = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody] User user)
        {
            try
            {
                if (user is null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                bool alreadyExists = _userRepo.FindByCondition(u => u.Username == user.Username).Any();

                if (alreadyExists)
                {
                    return StatusCode(409, $"'{user.Username}' is already in use.");
                }

                user.PasswordHash = PasswordHashingService.HashPassword(user.PasswordHash);

                var newUser = _userRepo.Create(user);

                return Ok(newUser);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to register user: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }

        [HttpGet("Validate/{userName}")]
        public IActionResult CheckUsernameAvailability(string userName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName))
                {
                    return BadRequest();
                }

                bool alreadyExists = _userRepo.FindByCondition(u => u.Username == userName).Any();

                if (alreadyExists)
                {
                    return StatusCode(409, $"'{userName}' is already in use.");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to check username availability: {}", ex);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}

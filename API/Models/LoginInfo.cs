using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class LoginInfo
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}

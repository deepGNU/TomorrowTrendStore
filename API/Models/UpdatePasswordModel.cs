using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class UpdatePasswordModel
    {
        [Required]
        public string OldPassword { get; set; } = null!;

        [Required]
        public string NewPassword { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Models.Enums;

namespace API.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [EnumDataType(typeof(UserType))]
        public UserType Type { get; set; }

        public UserAddress Address { get; set; } = null!;

        //public List<UserReview> Reviews { get; set; } = new();

        public List<ShopOrder> Orders { get; set; } = new();

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Email { get; set; } = null!;

        [MaxLength(50)]
        public string? PhoneNumber { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; } = null!;

        [MaxLength(200)]
        public string? ProfileImageURL { get; set; }
    }
}

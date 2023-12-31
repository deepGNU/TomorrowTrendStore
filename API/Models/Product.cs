using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public int ProductCategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        
        [Required]
        [MaxLength(200)]
        public string ShortDescription { get; set; } = null!;

        [Required]
        [MaxLength(5000)]
        public string LongDescription { get; set; } = null!;

        [MaxLength(200)]
        public string? ImageURL { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        [Range(0, 99999999.99)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 5)]
        [Column(TypeName = "decimal(2,1)")]
        public decimal AverageRating { get; set; }

        public int? NumberOfRatings { get; set; } = null;

        [Required]
        public bool IsFeatured { get; set; } = false;
    }
}

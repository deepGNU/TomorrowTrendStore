using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        public int? ParentCategoryId { get; set; }

        public ProductCategory? ParentCategory { get; set; }

        public List<ProductCategory> SubCategories { get; set; } = new();

        public List<Product> Products { get; set; } = new();
    }
}

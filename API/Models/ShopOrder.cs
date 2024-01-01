using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class ShopOrder
    {
        public int Id { get; set; }

        [Required]
        public int? UserId { get; set; }

        [Required]
        [MaxLength(10)]
        public string Status { get; set; } = null!;

        public DateTime? OrderDate { get; set; }

        [Range(0, 99999999.99)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal? TotalPrice { get; set; } = 0M;

        public List<OrderLine> OrderLines { get; set; } = new();
    }
}

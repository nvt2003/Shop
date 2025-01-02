

using BusinessObjects.Models;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.DTOs
{
    public class ProductDTO
    {

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        [StringLength(1000)]
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public int InventoryId { get; set; }
        public int? TypeAttibuteId { get; set; }
        public int? SizeAttibuteId { get; set; }
        public int? ColorAttibuteId { get; set; }
        public int? DiscountId { get; set; }
        public DateTime CreatedAt { get; set; } =DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}

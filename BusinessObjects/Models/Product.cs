

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
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
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public virtual Category Category { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual ProductAttribute TypeAttribute {  get; set; }
        public virtual ProductAttribute ColorAttribute { get; set; }
        public virtual ProductAttribute SizeAttribute { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set;}
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}

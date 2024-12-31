
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [StringLength(1000)]
        public string? Avatar { get; set; }
        [StringLength(20)]
        public string? FirstName { get; set; }
        [StringLength(20)]
        public string? LastName { get; set; }
        [Required]
        [StringLength(255)]
        public string Username { get; set; }
        [EmailAddress]
        [StringLength(255)]
        public string? Email { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public int? RoleId { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? DeleteAt { get; set; }
        public virtual ICollection<WishList> WishLists { get; set;}
        public virtual ICollection<Cart> Carts { get; set;}
        public virtual ICollection<Order> Orders { get; set;}
    }
}

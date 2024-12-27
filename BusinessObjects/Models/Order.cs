

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PaymentId { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public virtual User User { get; set; }
        public virtual PaymentDetail PaymentDetail { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}

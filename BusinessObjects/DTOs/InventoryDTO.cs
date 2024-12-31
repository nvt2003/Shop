
namespace BusinessObjects.DTOs
{
    public class InventoryDTO
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
    }
}

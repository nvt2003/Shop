

using BusinessObjects.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.DTOs
{
    public class InventoryViewModel
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ProductBasicViewModel ProductView { get; set; }
    }
}

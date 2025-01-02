
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.DTOs
{
    public class ProductAttributeDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(50,ErrorMessage ="Max length is 50 characters")]
        public string Type { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [StringLength(50, ErrorMessage = "Max length is 50 characters")]
        public string Value { get; set; }
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        public DateTime? DeletedAt { get; set; }
    }
}

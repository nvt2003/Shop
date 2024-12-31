

using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Max length is 50 characters")]
        [StringLength(50, ErrorMessage = "Max length is 50 characters")]
        public string Name { get; set; }
        [StringLength(255, ErrorMessage = "Max length is 255 characters")]
        public string? Description { get; set; }
        public DateTime CreateAt { get; set; }= DateTime.Now;
        public DateTime? DeleteAt { get; set; }
    }
}

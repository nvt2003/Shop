
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.DTOs
{
    public class RegisterRequest
    {
        [Required]
        [StringLength(20, ErrorMessage = "Max length is 20 characters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Max length is 20 characters")]
        public string LastName { get; set; }
        [Required]
        [StringLength(255)]
        public string Username { get; set; }
        [EmailAddress]
        [StringLength(255)]
        public string? Email { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime CreateAt { get; set; }
    }
}

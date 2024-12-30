

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [StringLength(1000,ErrorMessage ="Max length is 1000 characters")]
        public string? Avatar { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(20, ErrorMessage = "Max length is 20 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(20, ErrorMessage = "Max length is 20 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, ErrorMessage = "Max length is 255 characters")]
        public string Username { get; set; }
        [EmailAddress(ErrorMessage ="Please input email! Example: example@gmail.com!")]
        [StringLength(255, ErrorMessage = "Max length is 255 characters")]
        public string? Email { get; set; }
        [Required(ErrorMessage ="This field is required")]
        [StringLength(255, ErrorMessage = "Max length is 255 characters")]
        public string Password { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public DateOnly DateOfBirth { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string PhoneNumber { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}

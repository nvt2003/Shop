

using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.DTOs
{
    public class UpdateProfileModel
    {
        public int Id { get; set; }
        [StringLength(1000, ErrorMessage = "Max length is 1000 characters")]
        public string? Avatar { get; set; }
        [StringLength(20, ErrorMessage = "Max length is 20 characters")]
        public string? FirstName { get; set; }
        [StringLength(20, ErrorMessage = "Max length is 20 characters")]
        public string? LastName { get; set; }
        [StringLength(255, ErrorMessage = "Max length is 255 characters")]
        public string? Username { get; set; }
        [EmailAddress(ErrorMessage = "Please input email! Example: example@gmail.com!")]
        [StringLength(255, ErrorMessage = "Max length is 255 characters")]
        public string? Email { get; set; }
        [StringLength(255, ErrorMessage = "Max length is 255 characters")]
        public string? Password { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
    }
}

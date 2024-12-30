
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.DTOs
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(255, ErrorMessage = "Username must be less than 255 characters.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(255, ErrorMessage = "Password must be less than 255 characters.")]
        public string Password { get; set; }
    }
}

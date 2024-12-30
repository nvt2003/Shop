﻿
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects.DTOs
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string? Avatar { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Username { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime CreateAt { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Disaster.API.DTOs
{
    // Can use DTOs to make data transfer easier as the api can infer the variables from the sent data
    // Can use to validate data
    public class UserForRegisterDto
    {
        [Required]

        public string Username { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "You must specify a password between 6 and 20 characters")]
        public string Password { get; set; }
        // [Required]
        // [EmailAddress]
        public string Email { get; set; }
    }
}
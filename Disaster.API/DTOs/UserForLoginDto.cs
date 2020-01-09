using System.ComponentModel.DataAnnotations;

namespace Disaster.API.DTOs
{
    public class UserForLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
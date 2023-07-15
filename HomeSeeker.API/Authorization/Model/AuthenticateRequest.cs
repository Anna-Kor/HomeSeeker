using System.ComponentModel.DataAnnotations;

namespace HomeSeeker.API.Authorization.Model
{
    public class AuthenticateRequest
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}

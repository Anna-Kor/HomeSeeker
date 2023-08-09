using MediatR;

using System.ComponentModel.DataAnnotations;

namespace HomeSeeker.API.Commands.UserCommands
{
    public class RegisterUserCommand : IRequest
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}

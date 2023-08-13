using HomeSeeker.API.Models.CustomResults;
using MediatR;

using System.ComponentModel.DataAnnotations;

namespace HomeSeeker.API.Commands.UserCommands
{
    public class RegisterUserCommand : IRequest<OperationResult>
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}

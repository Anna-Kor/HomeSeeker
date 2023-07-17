using MediatR;

using System.ComponentModel.DataAnnotations;

namespace HomeSeeker.API.Commands.UserCommands
{
    public class RegisterUser : IRequest
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }

        public RegisterUser(string? firstName, string? lastName, string? username, string? password)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
        }
    }
}

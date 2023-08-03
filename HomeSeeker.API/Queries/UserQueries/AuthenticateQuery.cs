using HomeSeeker.API.Models;

using MediatR;

using System.ComponentModel.DataAnnotations;

namespace HomeSeeker.API.Queries.UserQueries
{
    public class AuthenticateQuery : IRequest<AuthenticateResponse>
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public AuthenticateQuery(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}

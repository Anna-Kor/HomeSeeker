using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HomeSeeker.API.Commands.HomeCommands.DeleteHome
{
    public class DeleteHomeCommand : IRequest
    {
        [Required]
        public int Id { get; set; }
    }
}

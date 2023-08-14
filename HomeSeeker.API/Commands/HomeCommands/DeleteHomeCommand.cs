using MediatR;

namespace HomeSeeker.API.Commands.HomeCommands
{
    public class DeleteHomeCommand : IRequest
    {
        public int Id { get; set; }
    }
}

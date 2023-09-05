using MediatR;

namespace HomeSeeker.API.Commands.HomeCommands.DeleteHome
{
    public class DeleteHomeCommand : IRequest
    {
        public int Id { get; set; }
    }
}

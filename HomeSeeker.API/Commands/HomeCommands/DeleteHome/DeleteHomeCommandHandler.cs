using System.Threading.Tasks;
using System.Threading;

using Data.Models;

using HomeSeeker.API.Repositories;

using MediatR;

namespace HomeSeeker.API.Commands.HomeCommands.DeleteHome
{
    public class DeleteHomeCommandHandler : IRequestHandler<DeleteHomeCommand>
    {
        private readonly IEntityOperationsRepositoryBase<Home> _homeOperationsRepository;

        public DeleteHomeCommandHandler(IEntityOperationsRepositoryBase<Home> homeOperationsRepository)
        {
            _homeOperationsRepository = homeOperationsRepository;
        }

        public async Task Handle(DeleteHomeCommand request, CancellationToken cancellationToken)
        {
            await _homeOperationsRepository.Delete(request.Id);
        }
    }
}

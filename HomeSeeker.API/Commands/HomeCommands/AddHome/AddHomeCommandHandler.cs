using Data.Enums;
using Data.Models;

using HomeSeeker.API.Repositories;

using MediatR;

using System.Threading.Tasks;
using System.Threading;

namespace HomeSeeker.API.Commands.HomeCommands.AddHome
{
    public class AddHomeCommandHandler : IRequestHandler<AddHomeCommand>
    {
        private readonly IEntityOperationsRepositoryBase<Home> _homeOperationsRepository;

        public AddHomeCommandHandler(IEntityOperationsRepositoryBase<Home> homeOperationsRepository)
        {
            _homeOperationsRepository = homeOperationsRepository;
        }

        public async Task Handle(AddHomeCommand request, CancellationToken cancellationToken)
        {
            var home = new Home
            {
                Name = request.Name,
                Price = request.Price,
                Rent = request.Rent,
                City = request.City,
                LivingArea = request.LivingArea,
                LotArea = request.LotArea,
                Category = request.Category,
                Type = request.Type,
                Floor = request.Floor,
                FloorsQuantity = request.FloorsQuantity,
                HasFurniture = request.HasFurniture,
                RoomsQuantity = request.RoomsQuantity,
                BathroomsQuantity = request.BathroomsQuantity,
                Status = HomeStatus.Available,
                Description = request.Description,
                CreatedUserId = request.CreatedUserId
            };
            await _homeOperationsRepository.Add(home);
        }
    }
}

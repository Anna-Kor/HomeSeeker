using Data.Models;

using HomeSeeker.API.Repositories;

using MediatR;

using System.Threading.Tasks;
using System.Threading;

namespace HomeSeeker.API.Commands.HomeCommands.UpdateHome
{
    public class UpdateHomeCommandHandler : IRequestHandler<UpdateHomeCommand>
    {
        private readonly IEntityOperationsRepositoryBase<Home> _homeOperationsRepository;

        public UpdateHomeCommandHandler(IEntityOperationsRepositoryBase<Home> homeOperationsRepository)
        {
            _homeOperationsRepository = homeOperationsRepository;
        }

        public async Task Handle(UpdateHomeCommand request, CancellationToken cancellationToken)
        {
            var home = new Home
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price,
                Rent = request.Rent,
                Lon = request.Lon,
                Lat = request.Lat,
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
                Status = request.Status,
                Description = request.Description
            };

            await _homeOperationsRepository.Update(home);
        }
    }
}

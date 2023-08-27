using Data.Enums;
using Data.Models;

using HomeSeeker.API.Commands.HomeCommands;
using HomeSeeker.API.Repositories.HomeRepositories;

using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HomeSeeker.API.Commands
{
    public class HomesCommandHandler : 
        IRequestHandler<AddHomeCommand>,
        IRequestHandler<DeleteHomeCommand>,
        IRequestHandler<UpdateHomeCommand>
    {
        private readonly IHomeRepository _homeRepository;

        public HomesCommandHandler(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public async Task Handle(AddHomeCommand request, CancellationToken cancellationToken)
        {
            var home = new Home {
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
                Status = HomeStatus.Available,
                Description = request.Description,
                CreatedUserId = request.CreatedUserId
            };
            await _homeRepository.Add(home);
        }

        public async Task Handle(DeleteHomeCommand request, CancellationToken cancellationToken)
        {
            await _homeRepository.Delete(request.Id);
        }

        public async Task Handle(UpdateHomeCommand request, CancellationToken cancellationToken)
        {
            var home = new Home {
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

            await _homeRepository.Update(home);
        }
    }
}

using HomeSeeker.API.Models;
using HomeSeeker.API.Repositories.HomeRepositories;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

using MediatR;

namespace HomeSeeker.API.Queries.HomeQueries.GetAllHomes
{
    public class GetAllHomesQueryHandler : IRequestHandler<GetAllHomesQuery, List<HomeModel>>
    {
        private readonly IGetHomeRepository _homeRepository;

        public GetAllHomesQueryHandler(IGetHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }
        public async Task<List<HomeModel>> Handle(GetAllHomesQuery request, CancellationToken cancellationToken)
        {
            var homes = await _homeRepository.GetAll(cancellationToken);
            return homes;
        }
    }
}

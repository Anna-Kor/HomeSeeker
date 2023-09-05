using HomeSeeker.API.Models;
using HomeSeeker.API.Repositories.HomeRepositories;

using MediatR;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace HomeSeeker.API.Queries.HomeQueries.GetActiveHomes
{
    public class GetActiveHomesQueryHandler : IRequestHandler<GetActiveHomesQuery, List<HomeModel>>
    {
        private readonly IGetHomeRepository _homeRepository;

        public GetActiveHomesQueryHandler(IGetHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public async Task<List<HomeModel>> Handle(GetActiveHomesQuery request, CancellationToken cancellationToken)
        {
            var homes = await _homeRepository.GetActive(request.FilterValues, cancellationToken);
            return homes;
        }
    }
}

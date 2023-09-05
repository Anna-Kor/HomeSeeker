using HomeSeeker.API.Models;
using HomeSeeker.API.Repositories.HomeRepositories;

using MediatR;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace HomeSeeker.API.Queries.HomeQueries.GetHomesByUserId
{
    public class GetHomesByUserIdQueryHandler : IRequestHandler<GetHomesByUserIdQuery, List<HomeModel>>
    {
        private readonly IGetHomeRepository _homeRepository;

        public GetHomesByUserIdQueryHandler(IGetHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public async Task<List<HomeModel>> Handle(GetHomesByUserIdQuery request, CancellationToken cancellationToken)
        {
            var homes = await _homeRepository.GetByUserId(request.UserId, cancellationToken);
            return homes;
        }
    }
}

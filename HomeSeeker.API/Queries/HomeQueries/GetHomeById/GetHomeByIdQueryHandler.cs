using HomeSeeker.API.Models;
using HomeSeeker.API.Repositories.HomeRepositories;

using MediatR;

using System.Threading.Tasks;
using System.Threading;

namespace HomeSeeker.API.Queries.HomeQueries.GetHomeById
{
    public class GetHomeByIdQueryHandler : IRequestHandler<GetHomeByIdQuery, HomeModel>
    {
        private readonly IGetHomeRepository _homeRepository;

        public GetHomeByIdQueryHandler(IGetHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public async Task<HomeModel> Handle(GetHomeByIdQuery request, CancellationToken cancellationToken)
        {
            var homes = await _homeRepository.GetById(request.Id, cancellationToken);
            return homes;
        }
    }
}

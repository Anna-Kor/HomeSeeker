using HomeSeeker.API.Repositories.HomeRepositories;

using System.Threading.Tasks;
using System.Threading;

using MediatR;

namespace HomeSeeker.API.Queries.HomeQueries.GetMaxPrice
{
    public class GetMaxPriceQueryHandler : IRequestHandler<GetMaxPriceQuery, decimal>
    {
        private readonly IGetHomeRepository _homeRepository;

        public GetMaxPriceQueryHandler(IGetHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public async Task<decimal> Handle(GetMaxPriceQuery request, CancellationToken cancellationToken)
        {
            var maxPrice = await _homeRepository.GetMaxPrice(cancellationToken);
            return maxPrice;
        }
    }
}

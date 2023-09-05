using Data.Models;

using HomeSeeker.API.Models;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HomeSeeker.API.Repositories.HomeRepositories
{
    public interface IGetHomeRepository : IGetRepositoryBase<HomeModel>
    {
        Task<List<HomeModel>> GetActive(FilterValues filterValues, CancellationToken cancellationToken);
        Task<List<HomeModel>> GetByUserId(int userId, CancellationToken cancellationToken);
        Task<decimal> GetMaxPrice(CancellationToken cancellationToken);
    }
}
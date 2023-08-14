using Data.Models;

using HomeSeeker.API.Models;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HomeSeeker.API.Repositories.HomeRepositories
{
    public interface IHomeRepository
    {
        Task<List<HomeModel>> GetAll(CancellationToken cancellationToken);
        Task<List<HomeModel>> GetActive(CancellationToken cancellationToken);
        Task Add(Home home);
        Task Update(Home home);
        Task Delete(int Id);
    }
}
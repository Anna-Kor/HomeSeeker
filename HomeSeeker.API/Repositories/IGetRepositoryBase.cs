using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace HomeSeeker.API.Repositories
{
    public interface IGetRepositoryBase<T>
    {
        Task<List<T>> GetAll(CancellationToken cancellationToken);
        Task<T> GetById(int id, CancellationToken cancellationToken);
    }
}

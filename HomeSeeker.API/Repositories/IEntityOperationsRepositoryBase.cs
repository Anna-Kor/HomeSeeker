using Data.Models;
using System.Threading.Tasks;

namespace HomeSeeker.API.Repositories
{
    public interface IEntityOperationsRepositoryBase<T>
    {
        Task Add(T user);
        Task Update(T user);
        Task Delete(int Id);
    }
}

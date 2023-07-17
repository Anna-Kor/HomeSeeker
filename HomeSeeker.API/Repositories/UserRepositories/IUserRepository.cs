using Data.Models;

using HomeSeeker.API.Models;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HomeSeeker.API.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAll(CancellationToken cancellationToken);
        Task<UserModel> GetById(int id, CancellationToken cancellationToken);
        Task Add(User user);
        Task Update(User user);
        Task Delete(int Id);
    }
}

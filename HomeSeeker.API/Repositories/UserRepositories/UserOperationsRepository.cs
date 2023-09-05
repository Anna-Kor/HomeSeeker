using Data.Models;
using System.Threading.Tasks;
using System;
using Data;

namespace HomeSeeker.API.Repositories.UserRepositories
{
    public class UserOperationsRepository : IEntityOperationsRepositoryBase<User>
    {
        private readonly HomeSeekerDBContext _dbContext;

        public UserOperationsRepository(HomeSeekerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(User user)
        {
            User newUser = new User();

            newUser.FirstName = user.FirstName;
            newUser.LastName = user.LastName;
            newUser.Role = user.Role;
            newUser.Username = user.Username;
            newUser.Password = user.Password;
            newUser.Salt = user.Salt;

            try
            {
                _dbContext.Users.Add(newUser);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}

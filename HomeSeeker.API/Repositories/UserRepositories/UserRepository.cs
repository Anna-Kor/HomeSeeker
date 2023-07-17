using Data;
using Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using HomeSeeker.API.Models;

namespace HomeSeeker.API.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HomeSeekerDBContext _dbContext;

        public UserRepository(HomeSeekerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserModel>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                List<User> userEntities = await _dbContext.Users.ToListAsync(cancellationToken);
                List<UserModel> users = userEntities.Select(x => new UserModel
                {
                    Id = x.Id,
                    Username = x.Username,
                    Password = x.Password,
                    Salt = x.Salt
                }).ToList();
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserModel> GetById(int id, CancellationToken cancellationToken)
        {
            try
            {
                User userEntity = await _dbContext.Users.FindAsync(id, cancellationToken);
                UserModel user = new UserModel
                {
                    Id = userEntity.Id,
                    Username = userEntity.Username,
                    Password = userEntity.Password,
                    Salt = userEntity.Salt
                };
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Add(User user)
        {
            User newUser = new User();

            newUser.FirstName = user.FirstName;
            newUser.LastName = user.LastName;
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

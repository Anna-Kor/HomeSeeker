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
    public class GetUserRepository : IGetRepositoryBase<UserModel>
    {
        private readonly IDbContext _dbContext;

        public GetUserRepository(IDbContext dbContext)
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
                    Role = x.Role,
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
                    Role = userEntity.Role,
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
    }
}

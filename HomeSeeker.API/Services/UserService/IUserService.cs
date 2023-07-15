using Data.Models;

using HomeSeeker.API.Authorization.Model;

using System.Collections.Generic;

namespace HomeSeeker.API.Services.UserService
{
    public interface IUserService
    {
        AuthenticateResponse? Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User? GetById(int id);
    }
}

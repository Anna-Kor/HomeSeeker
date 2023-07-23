using Data.Enums;
using Data.Models;

using HomeSeeker.API.Authorization.Helpers;
using HomeSeeker.API.Commands.UserCommands;
using HomeSeeker.API.Repositories.UserRepositories;

using MediatR;

using System.Threading.Tasks;
using System.Threading;

namespace HomeSeeker.API.Commands
{
    public class UsersCommandHandler : IRequestHandler<RegisterUser>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHelper _passwordHelper;

        public UsersCommandHandler(IUserRepository userRepository, IPasswordHelper passwordHelper)
        {
            _userRepository = userRepository;
            _passwordHelper = passwordHelper;
        }

        public async Task Handle(RegisterUser request, CancellationToken cancellationToken)
        {
            var hashedPassword = _passwordHelper.HashPassword(request.Password, out var salt);
            var user = new User { FirstName = request.FirstName, LastName = request.LastName, Role = Role.User, Username = request.Username, Password = hashedPassword, Salt = salt };
            await _userRepository.Add(user);
        }
    }
}

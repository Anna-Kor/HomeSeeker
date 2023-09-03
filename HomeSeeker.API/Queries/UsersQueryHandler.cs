using HomeSeeker.API.Authorization.Helpers;
using HomeSeeker.API.Authorization.Utils;
using HomeSeeker.API.Models;
using HomeSeeker.API.Queries.UserQueries;
using HomeSeeker.API.Repositories;

using MediatR;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace HomeSeeker.API.Queries
{
    public class UsersQueryHandler :
        IRequestHandler<GetAllUsersQuery, List<UserModel>>,
        IRequestHandler<GetUserByIdQuery, UserModel>,
        IRequestHandler<AuthenticateQuery, AuthenticateResponse>
    {
        private readonly IGetRepositoryBase<UserModel> _getUserRepository;
        private readonly IJwtUtils _jwtUtils;
        private readonly IPasswordHelper _passwordHelper;

        public UsersQueryHandler(IGetRepositoryBase<UserModel> getUserRepository, IJwtUtils jwtUtils, IPasswordHelper passwordHelper)
        {
            _getUserRepository = getUserRepository;
            _jwtUtils = jwtUtils;
            _passwordHelper = passwordHelper;
        }

        public async Task<List<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _getUserRepository.GetAll(cancellationToken);
            return users;
        }

        public async Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _getUserRepository.GetById(request.Id, cancellationToken);
            return user;
        }

        public async Task<AuthenticateResponse> Handle(AuthenticateQuery request, CancellationToken cancellationToken)
        {
            var users = await _getUserRepository.GetAll(cancellationToken);

            if (users == null)
            {
                return null;
            }
            
            var user = users.SingleOrDefault(x => x.Username == request.Username && _passwordHelper.VerifyPassword(request.Password, x.Password, x.Salt));

            if (user == null)
            {
                return null;
            }

            var token = _jwtUtils.GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }
    }
}

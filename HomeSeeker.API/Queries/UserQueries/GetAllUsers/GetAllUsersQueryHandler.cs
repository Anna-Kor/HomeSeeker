using HomeSeeker.API.Models;
using HomeSeeker.API.Repositories;

using MediatR;

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace HomeSeeker.API.Queries.UserQueries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserModel>>
    {
        private readonly IGetRepositoryBase<UserModel> _getUserRepository;

        public GetAllUsersQueryHandler(IGetRepositoryBase<UserModel> getUserRepository)
        {
            _getUserRepository = getUserRepository;
        }

        public async Task<List<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _getUserRepository.GetAll(cancellationToken);
            return users;
        }
    }
}

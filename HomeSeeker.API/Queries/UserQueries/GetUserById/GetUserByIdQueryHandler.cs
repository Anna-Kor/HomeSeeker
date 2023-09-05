using HomeSeeker.API.Models;
using HomeSeeker.API.Repositories;

using System.Threading.Tasks;
using System.Threading;

using MediatR;

namespace HomeSeeker.API.Queries.UserQueries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserModel>
    {
        private readonly IGetRepositoryBase<UserModel> _getUserRepository;

        public GetUserByIdQueryHandler(IGetRepositoryBase<UserModel> getUserRepository)
        {
            _getUserRepository = getUserRepository;
        }

        public async Task<UserModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _getUserRepository.GetById(request.Id, cancellationToken);
            return user;
        }
    }
}

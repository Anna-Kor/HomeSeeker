using HomeSeeker.API.Models;

using MediatR;

using System.Collections.Generic;

namespace HomeSeeker.API.Queries.UserQueries
{
    public class GetAllUsersQuery : IRequest<List<UserModel>>
    {
    }
}

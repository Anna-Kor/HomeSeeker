using HomeSeeker.API.Models;

using MediatR;

using System.Collections.Generic;

namespace HomeSeeker.API.Queries.UserQueries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserModel>>
    {
    }
}

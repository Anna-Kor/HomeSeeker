using HomeSeeker.API.Models;

using MediatR;

using System.Collections.Generic;

namespace HomeSeeker.API.Queries.HomeQueries
{
    public class GetAllHomesQuery : IRequest<List<HomeModel>>
    {
    }
}

using HomeSeeker.API.Models;

using MediatR;

using System.Collections.Generic;

namespace HomeSeeker.API.Queries.HomeQueries
{
    public class GetHomesByUserIdQuery : IRequest<List<HomeModel>>
    {
        public GetHomesByUserIdQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}

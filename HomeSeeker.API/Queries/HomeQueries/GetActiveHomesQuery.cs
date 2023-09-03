using HomeSeeker.API.Models;
using MediatR;
using System.Collections.Generic;

namespace HomeSeeker.API.Queries.HomeQueries
{
    public class GetActiveHomesQuery : IRequest<List<HomeModel>>
    {
        public FilterValues FilterValues { get; set; }
    }
}

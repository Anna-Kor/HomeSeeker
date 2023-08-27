using HomeSeeker.API.Models;

using MediatR;

namespace HomeSeeker.API.Queries.HomeQueries
{
    public class GetHomeByIdQuery : IRequest<HomeModel>
    {
        public GetHomeByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

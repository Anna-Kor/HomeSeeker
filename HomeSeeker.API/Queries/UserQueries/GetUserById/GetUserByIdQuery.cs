﻿using HomeSeeker.API.Models;

using MediatR;

namespace HomeSeeker.API.Queries.UserQueries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserModel>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
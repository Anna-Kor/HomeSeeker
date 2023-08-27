﻿using HomeSeeker.API.Models;
using HomeSeeker.API.Queries.HomeQueries;
using HomeSeeker.API.Repositories.HomeRepositories;

using MediatR;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HomeSeeker.API.Queries
{
    public class HomesQueryHandler :
        IRequestHandler<GetAllHomesQuery, List<HomeModel>>,
        IRequestHandler<GetActiveHomesQuery, List<HomeModel>>,
        IRequestHandler<GetHomeByIdQuery, HomeModel>
    {
        private readonly IHomeRepository _homeRepository;

        public HomesQueryHandler(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public async Task<List<HomeModel>> Handle(GetAllHomesQuery request, CancellationToken cancellationToken)
        {
            var homes = await _homeRepository.GetAll(cancellationToken);
            return homes;
        }

        public async Task<List<HomeModel>> Handle(GetActiveHomesQuery request, CancellationToken cancellationToken)
        {
            var homes = await _homeRepository.GetActive(cancellationToken);
            return homes;
        }

        public async Task<HomeModel> Handle(GetHomeByIdQuery request, CancellationToken cancellationToken)
        {
            var homes = await _homeRepository.GetById(request.Id, cancellationToken);
            return homes;
        }
    }
}

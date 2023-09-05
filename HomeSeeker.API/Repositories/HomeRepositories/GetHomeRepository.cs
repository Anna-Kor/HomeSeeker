using Data;
using Data.Enums;
using Data.Models;

using HomeSeeker.API.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HomeSeeker.API.Repositories.HomeRepositories
{
    public class GetHomeRepository : IGetHomeRepository
    {
        private readonly IDbContext _dbContext;

        public GetHomeRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HomeModel>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                List<Home> homeEntities = await _dbContext.Homes.ToListAsync(cancellationToken);
                List<HomeModel> homes = homeEntities.Select(home => new HomeModel(home)).ToList();

                return homes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<HomeModel>> GetActive(FilterValues filterValues, CancellationToken cancellationToken)
        {
            try
            {
                IQueryable<Home> homeEntities = _dbContext.Homes.Where(x => x.Status != HomeStatus.Archived).AsQueryable();
                if (filterValues != null)
                {
                    homeEntities = this.FilterFields(filterValues, homeEntities);
                }
                List<HomeModel> homes = await homeEntities.Select(home => new HomeModel(home)).ToListAsync(cancellationToken);
                return homes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        public async Task<HomeModel> GetById(int id, CancellationToken cancellationToken)
        {
            try
            {
                Home homeEntity = await _dbContext.Homes.Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
                HomeModel home = new HomeModel(homeEntity);
                return home;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<HomeModel>> GetByUserId(int userId, CancellationToken cancellationToken)
        {
            try
            {
                List<Home> homeEntities = await _dbContext.Homes.Where(x => x.CreatedUserId == userId).ToListAsync(cancellationToken);
                List<HomeModel> homes = homeEntities.Select(home => new HomeModel(home)).ToList();
                return homes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<decimal> GetMaxPrice(CancellationToken cancellationToken)
        {
            try
            {
                decimal maxPrice = await _dbContext.Homes.MaxAsync(x => x.Price);
                return maxPrice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private IQueryable<Home> FilterFields(FilterValues filterValues, IQueryable<Home> homeEntities)
        {
            if (filterValues.Name != null)
            {
                homeEntities = homeEntities.Where(p => p.Name.Contains(filterValues.Name));
            }

            if (filterValues.PriceFrom != null)
            {
                homeEntities = homeEntities.Where(p => p.Price >= filterValues.PriceFrom);
            }

            if (filterValues.PriceTo != null)
            {
                homeEntities = homeEntities.Where(p => p.Price <= filterValues.PriceTo);
            }

            if (filterValues.City != null)
            {
                homeEntities = homeEntities.Where(p => p.City.Equals(filterValues.City));
            }

            return homeEntities;
        }
    }
}
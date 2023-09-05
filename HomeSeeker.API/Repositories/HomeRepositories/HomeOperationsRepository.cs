using Data;
using Data.Enums;
using Data.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSeeker.API.Repositories.HomeRepositories
{
    public class HomeOperationsRepository : IEntityOperationsRepositoryBase<Home>
    {
        private readonly HomeSeekerDBContext _dbContext;

        public HomeOperationsRepository(HomeSeekerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Home home)
        {
            try
            {
                _dbContext.Homes.Add(home);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(Home home)
        {
            try
            {
                var homeFromDb = _dbContext.Homes.FirstOrDefault(h => h.Id == home.Id);
                if (homeFromDb == null)
                {
                    throw new NullReferenceException();
                }

                homeFromDb.Name = home.Name;
                homeFromDb.Price = home.Price;
                homeFromDb.Rent = home.Rent;
                homeFromDb.Lon = home.Lon;
                homeFromDb.Lat = home.Lat;
                homeFromDb.City = home.City;
                homeFromDb.LivingArea = home.LivingArea;
                homeFromDb.LotArea = home.LotArea;
                homeFromDb.Category = home.Category;
                homeFromDb.Type = home.Type;
                homeFromDb.Floor = home.Floor;
                homeFromDb.FloorsQuantity = home.FloorsQuantity;
                homeFromDb.HasFurniture = home.HasFurniture;
                homeFromDb.RoomsQuantity = home.RoomsQuantity;
                homeFromDb.BathroomsQuantity = home.BathroomsQuantity;
                homeFromDb.Status = home.Status;
                homeFromDb.Description = home.Description;

                _dbContext.Entry(homeFromDb).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int Id)
        {
            try
            {
                var homeFromDb = _dbContext.Homes.FirstOrDefault(h => h.Id == Id);
                if (homeFromDb == null)
                {
                    throw new NullReferenceException();
                }

                homeFromDb.Status = HomeStatus.Archived;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

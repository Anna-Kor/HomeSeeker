using HomeSeeker_API.Data;
using HomeSeeker_API.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSeeker_API.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly HomeSeekerDBContext _dbContext;

        public HomeRepository(HomeSeekerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Home>> Get(string name, decimal minPrice, decimal? maxPrice, string city, int minLivingArea, int? maxLivingArea, int? categoryId, int? typeId, int? floorId, int? floorsNumberId, string furniture, int? roomsNumberId, int? bathroomsId, int? statusId)
        {
            try
            {
                List<Home> homes = await GetHomes(name, minPrice, maxPrice, city, minLivingArea, maxLivingArea, categoryId, typeId, floorId, floorsNumberId, furniture, roomsNumberId, bathroomsId, statusId);

                return homes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Home>> GetActive(string name, decimal minPrice, decimal? maxPrice, string city, int minLivingArea, int? maxLivingArea, int? categoryId, int? typeId, int? floorId, int? floorsNumberId, string furniture, int? roomsNumberId, int? bathroomsId, int? statusId)
        {
            try
            {
                List<Home> homes = new List<Home>();
                if (statusId != 3)
                {
                    homes = await GetHomes(name, minPrice, maxPrice, city, minLivingArea, maxLivingArea, categoryId, typeId, floorId, floorsNumberId, furniture, roomsNumberId, bathroomsId, statusId);
                }
                return homes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Add(Home home)
        {
            Home newHome = new Home();

            newHome.Name = home.Name;
            newHome.Price = home.Price;
            newHome.Rent = home.Rent;
            newHome.Lon = home.Lon;
            newHome.Lat = home.Lat;
            newHome.City = home.City;
            newHome.LivingArea = home.LivingArea;
            newHome.LotArea = home.LotArea;
            newHome.CategoryId = home.CategoryId;
            newHome.TypeId = home.TypeId;
            newHome.FloorId = home.FloorId;
            newHome.FloorsNumberId = home.FloorsNumberId;
            newHome.Furniture = home.Furniture;
            newHome.RoomsNumberId = home.RoomsNumberId;
            newHome.BathroomsId = home.BathroomsId;
            newHome.StatusId = home.StatusId;
            newHome.Description = home.Description;

            try
            {
                _dbContext.Homes.Add(newHome);
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
                var newHome = _dbContext.Homes.FirstOrDefault(h => h.Id == home.Id);
                if (newHome == null)
                {
                    throw new ObjectNotFoundException();
                }

                newHome.Name = home.Name;
                newHome.Price = home.Price;
                newHome.Rent = home.Rent;
                newHome.Lon = home.Lon;
                newHome.Lat = home.Lat;
                newHome.City = home.City;
                newHome.LivingArea = home.LivingArea;
                newHome.LotArea = home.LotArea;
                newHome.CategoryId = home.CategoryId;
                newHome.TypeId = home.TypeId;
                newHome.FloorId = home.FloorId;
                newHome.FloorsNumberId = home.FloorsNumberId;
                newHome.Furniture = home.Furniture;
                newHome.RoomsNumberId = home.RoomsNumberId;
                newHome.BathroomsId = home.BathroomsId;
                newHome.StatusId = home.StatusId;
                newHome.Description = home.Description;

                _dbContext.Entry(newHome).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int Id)
        {
            try
            {
                var newHome = _dbContext.Homes.FirstOrDefault(h => h.Id == Id);
                if (newHome == null)
                {
                    throw new ObjectNotFoundException();
                }

                _dbContext.Entry(newHome).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<List<Home>> GetHomes(string name, decimal minPrice, decimal? maxPrice, string city, int minLivingArea, int? maxLivingArea, int? categoryId, int? typeId, int? floorId, int? floorsNumberId, string furniture, int? roomsNumberId, int? bathroomsId, int? statusId)
        {
            try
            {
                List<Home> homes = await _dbContext.Homes.Where(h =>
                    (String.IsNullOrEmpty(name) || h.Name.ToUpper().Contains(name.ToUpper())) &&
                    h.Price + h.Rent >= minPrice && (maxPrice == null || h.Price + h.Rent <= maxPrice) &&
                    (String.IsNullOrEmpty(city) || h.City.ToUpper().Equals(city.ToUpper())) &&
                    (h.LivingArea >= minLivingArea &&
                    (maxLivingArea == null || h.LivingArea <= maxLivingArea)) &&
                    (categoryId == null || h.CategoryId == categoryId) &&
                    (typeId == null || h.TypeId == typeId) &&
                    (floorId == null || h.FloorId == floorId) &&
                    (floorsNumberId == null || h.FloorsNumberId == floorsNumberId) &&
                    (String.IsNullOrEmpty(furniture) || h.Furniture.ToUpper().Equals(furniture.ToUpper())) &&
                    (roomsNumberId == null || h.RoomsNumberId == roomsNumberId) &&
                    (bathroomsId == null || h.BathroomsId == bathroomsId) &&
                    (statusId == null || h.StatusId == statusId)
                ).ToListAsync();

                return homes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

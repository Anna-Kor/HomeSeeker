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
    public class HomeRepository : IHomeRepository
    {
        private readonly HomeSeekerDBContext _dbContext;

        public HomeRepository(HomeSeekerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HomeModel>> GetAll(CancellationToken cancellationToken)
        {
            try
            {
                List<Home> homeEntities = await _dbContext.Homes.ToListAsync(cancellationToken);
                List<HomeModel> homes = homeEntities.Select(home => new HomeModel
                {
                    Id = home.Id,
                    Name = home.Name,
                    Price = home.Price,
                    Rent = home.Rent,
                    Lon = home.Lon,
                    Lat = home.Lat,
                    City = home.City,
                    LivingArea = home.LivingArea,
                    LotArea = home.LotArea,
                    Category = home.Category,
                    Type = home.Type,
                    Floor = home.Floor,
                    FloorsQuantity = home.FloorsQuantity,
                    HasFurniture = home.HasFurniture,
                    RoomsQuantity = home.RoomsQuantity,
                    BathroomsQuantity = home.BathroomsQuantity,
                    Status = home.Status,
                    Description = home.Description
                }).ToList();

                return homes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<HomeModel>> GetActive(CancellationToken cancellationToken)
        {
            try
            {
                List<Home> homeEntities = await _dbContext.Homes.Where(x => x.Status != HomeStatus.Archived).ToListAsync(cancellationToken);
                List<HomeModel> homes = homeEntities.Select(home => new HomeModel
                {
                    Id = home.Id,
                    Name = home.Name,
                    Price = home.Price,
                    Rent = home.Rent,
                    Lon = home.Lon,
                    Lat = home.Lat,
                    City = home.City,
                    LivingArea = home.LivingArea,
                    LotArea = home.LotArea,
                    Category = home.Category,
                    Type = home.Type,
                    Floor = home.Floor,
                    FloorsQuantity = home.FloorsQuantity,
                    HasFurniture = home.HasFurniture,
                    RoomsQuantity = home.RoomsQuantity,
                    BathroomsQuantity = home.BathroomsQuantity,
                    Status = home.Status,
                    Description = home.Description
                }).ToList();
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
                HomeModel home = new HomeModel
                {
                    Id = homeEntity.Id,
                    Name = homeEntity.Name,
                    Price = homeEntity.Price,
                    Rent = homeEntity.Rent,
                    Lon = homeEntity.Lon,
                    Lat = homeEntity.Lat,
                    City = homeEntity.City,
                    LivingArea = homeEntity.LivingArea,
                    LotArea = homeEntity.LotArea,
                    Category = homeEntity.Category,
                    Type = homeEntity.Type,
                    Floor = homeEntity.Floor,
                    FloorsQuantity = homeEntity.FloorsQuantity,
                    HasFurniture = homeEntity.HasFurniture,
                    RoomsQuantity = homeEntity.RoomsQuantity,
                    BathroomsQuantity = homeEntity.BathroomsQuantity,
                    Status = homeEntity.Status,
                    Description = homeEntity.Description
                };
                return home;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
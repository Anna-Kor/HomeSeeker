using HomeSeeker_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSeeker_API.Repositories
{
    public interface IHomeRepository
    {
        Task<List<Home>> Get(string name, decimal minPrice, decimal? maxPrice, string city, int minLivingArea, int? maxLivingArea, int? categoryId, int? typeId, int? floorId, int? floorsNumberId, string furniture, int? roomsNumberId, int? bathroomsId, int? statusId);
        Task<List<Home>> GetActive(string name, decimal minPrice, decimal? maxPrice, string city, int minLivingArea, int? maxLivingArea, int? categoryId, int? typeId, int? floorId, int? floorsNumberId, string furniture, int? roomsNumberId, int? bathroomsId, int? statusId);
        Task Add(Home home);
        Task Update(Home home);
        Task Delete(int Id);
    }
}

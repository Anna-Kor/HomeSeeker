using HomeSeeker_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSeeker_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPanelController : ControllerBase
    {
        private readonly HomeSeekerDBContext _dbContext;
        private readonly IConfiguration _configuration;

        public AdminPanelController(HomeSeekerDBContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpGet("GetHomes")]
        public async Task<IActionResult> Get([FromQuery] string name, [FromQuery] decimal minPrice, [FromQuery] decimal? maxPrice, [FromQuery] string city, [FromQuery] int minLivingArea, [FromQuery] int? maxLivingArea, [FromQuery] int? categoryId, [FromQuery] int? typeId, [FromQuery] int? floorId, [FromQuery] int? floorsNumberId, [FromQuery] string furniture, [FromQuery] int? roomsNumberId, [FromQuery] int? bathroomsId, [FromQuery] int? statusId)
        {
            try
            {
                var homes = await _dbContext.Homes.Where(h =>
                    (String.IsNullOrEmpty(name) || h.Name.Contains(name, StringComparison.OrdinalIgnoreCase)) &&
                    h.Price + h.Rent >= minPrice && (maxPrice == null || h.Price + h.Rent <= maxPrice) &&
                    (String.IsNullOrEmpty(city) || h.City.Equals(city, StringComparison.OrdinalIgnoreCase)) &&
                    (h.LivingArea >= minLivingArea &&
                    (maxLivingArea == null || h.LivingArea <= maxLivingArea)) &&
                    (categoryId == null || h.CategoryId == categoryId) &&
                    (typeId == null || h.TypeId == typeId) &&
                    (floorId == null || h.FloorId == floorId) &&
                    (floorsNumberId == null || h.FloorsNumberId == floorsNumberId) &&
                    (String.IsNullOrEmpty(furniture) || h.Furniture.Equals(furniture, StringComparison.OrdinalIgnoreCase)) &&
                    (roomsNumberId == null || h.RoomsNumberId == roomsNumberId) &&
                    (bathroomsId == null || h.BathroomsId == bathroomsId) &&
                    (statusId == null || h.StatusId == statusId)
                ).ToListAsync();
                if (homes.Count == 0)
                {
                    return StatusCode(404, "No homes found");
                }
                return Ok(homes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }
        }
    }
}

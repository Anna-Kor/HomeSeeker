using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using HomeSeeker_API.Repositories;

namespace HomeSeeker_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHomeRepository _homeRepository;

        public MapController(IConfiguration configuration, IHomeRepository homeRepository)
        {
            _configuration = configuration;
            _homeRepository = homeRepository;
        }

        [HttpGet("GetActiveHomes")]
        public async Task<IActionResult> GetActive([FromQuery] string name, [FromQuery] decimal minPrice, [FromQuery] decimal? maxPrice, [FromQuery] string city, [FromQuery] int minLivingArea, [FromQuery] int? maxLivingArea, [FromQuery] int? categoryId, [FromQuery] int? typeId, [FromQuery] int? floorId, [FromQuery] int? floorsNumberId, [FromQuery] string furniture, [FromQuery] int? roomsNumberId, [FromQuery] int? bathroomsId, [FromQuery] int? statusId)
        {
            try
            {
                var homes = await _homeRepository.GetActive(name, minPrice, maxPrice, city, minLivingArea, maxLivingArea, categoryId, typeId, floorId, floorsNumberId, furniture, roomsNumberId, bathroomsId, statusId);
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

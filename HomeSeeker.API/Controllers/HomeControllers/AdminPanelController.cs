using Microsoft.AspNetCore.Mvc;

using HomeSeeker.API.Authorization.Attributes;
using HomeSeeker.API.Repositories.HomeRepositories;

using System;
using System.Threading.Tasks;

namespace HomeSeeker.API.Controllers.HomeControllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPanelController : ControllerBase
    {
        private readonly IHomeRepository _homeRepository;

        public AdminPanelController(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        [HttpGet("GetHomes")]
        public async Task<IActionResult> Get([FromQuery] string name, [FromQuery] decimal minPrice, [FromQuery] decimal? maxPrice, [FromQuery] string city, [FromQuery] int minLivingArea, [FromQuery] int? maxLivingArea, [FromQuery] int? categoryId, [FromQuery] int? typeId, [FromQuery] int? floorId, [FromQuery] int? floorsNumberId, [FromQuery] string furniture, [FromQuery] int? roomsNumberId, [FromQuery] int? bathroomsId, [FromQuery] int? statusId)
        {
            try
            {
                var homes = await _homeRepository.Get(name, minPrice, maxPrice, city, minLivingArea, maxLivingArea, categoryId, typeId, floorId, floorsNumberId, furniture, roomsNumberId, bathroomsId, statusId);
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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Data.Models;
using Data.Enums;

using HomeSeeker.API.Authorization.Attributes;
using HomeSeeker.API.Repositories.HomeRepositories;

using System;
using System.Threading.Tasks;

namespace HomeSeeker.API.Controllers.HomeControllers
{
    [Authorize(Role.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserPanelController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHomeRepository _homeRepository;

        public UserPanelController(IConfiguration configuration, IHomeRepository homeRepository)
        {
            _configuration = configuration;
            _homeRepository = homeRepository;
        }

        [HttpPost("AddHome")]
        public async Task<IActionResult> Add([FromBody] Home home)
        {
            try
            {
                await _homeRepository.Add(home);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            return StatusCode(200, "Home added successfully");
        }

        [HttpPut("UpdateHome")]
        public async Task<IActionResult> Update([FromBody] Home home)
        {
            try
            {
                await _homeRepository.Update(home);
            }
            catch (NullReferenceException ex)
            {
                return StatusCode(404, "Home not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            return StatusCode(200, "Home updated successfully");
        }

        [HttpDelete("DeleteHome/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            try
            {
                await _homeRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            return StatusCode(200, "Home deleted successfully"); ;
        }
    }
}
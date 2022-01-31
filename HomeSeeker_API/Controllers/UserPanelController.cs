using HomeSeeker_API.Data;
using HomeSeeker_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using HomeSeeker_API.Repositories;
using System.Data.Entity.Core;

namespace HomeSeeker_API.Controllers
{

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
            catch (ObjectNotFoundException ex)
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

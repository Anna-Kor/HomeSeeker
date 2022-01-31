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

namespace HomeSeeker_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserPanelController : ControllerBase
    {
        private readonly HomeSeekerDBContext _dbContext;
        private readonly IConfiguration _configuration;

        public UserPanelController(HomeSeekerDBContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpPost("AddHome")]
        public async Task<IActionResult> Add([FromBody] Home home)
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
                return StatusCode(500, "An error has occured");
            }

            return StatusCode(200, "Home added successfully");
        }

        [HttpPut("UpdateHome")]
        public async Task<IActionResult> Update([FromBody] Home home)
        {
            try
            {
                var newHome = _dbContext.Homes.FirstOrDefault(h => h.Id == home.Id);
                if (newHome == null)
                {
                    return StatusCode(404, "Home not found");
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
                return StatusCode(500, "An error has occured");
            }

            return StatusCode(200, "Home updated successfully");
        }

        [HttpDelete("DeleteHome/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            try
            {
                var newHome = _dbContext.Homes.FirstOrDefault(h => h.Id == Id);
                if (newHome == null)
                {
                    return StatusCode(404, "Home not found");
                }

                _dbContext.Entry(newHome).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            return StatusCode(200, "Home deleted successfully"); ;
        }
    }
}

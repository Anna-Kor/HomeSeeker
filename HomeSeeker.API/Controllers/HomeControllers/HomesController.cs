using Data.Enums;

using HomeSeeker.API.Authorization.Attributes;
using HomeSeeker.API.Commands.HomeCommands;
using HomeSeeker.API.Models;
using HomeSeeker.API.Queries.HomeQueries;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeSeeker.API.Controllers.HomeControllers
{
    [Authorize(Role.User, Role.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController : ControllerBase
    {
        private readonly ISender _mediator;

        public HomesController(ISender mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(List<HomeModel>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var homes = await _mediator.Send(new GetAllHomesQuery());
            return Ok(homes);
        }

        [AllowAnonymous]
        [ProducesResponseType(typeof(List<HomeModel>), StatusCodes.Status200OK)]
        [HttpGet("getActive")]
        public async Task<IActionResult> GetActive()
        {
            var homes = await _mediator.Send(new GetActiveHomesQuery());
            return Ok(homes);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("add")]
        public async Task<IActionResult> Add(AddHomeCommand model)
        {
            try
            {
                await _mediator.Send(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            return StatusCode(200, "Home added successfully");
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateHomeCommand model)
        {
            try
            {
                await _mediator.Send(model);
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteHomeCommand model)
        {
            try
            {
                await _mediator.Send(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error has occured");
            }

            return StatusCode(200, "Home deleted successfully"); ;
        }
    }
}

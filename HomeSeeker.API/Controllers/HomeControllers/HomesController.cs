using Data.Enums;

using HomeSeeker.API.Authorization.Attributes;
using HomeSeeker.API.Commands.HomeCommands.AddHome;
using HomeSeeker.API.Commands.HomeCommands.DeleteHome;
using HomeSeeker.API.Commands.HomeCommands.UpdateHome;
using HomeSeeker.API.Models;
using HomeSeeker.API.Models.CustomResults;
using HomeSeeker.API.Queries.HomeQueries.GetActiveHomes;
using HomeSeeker.API.Queries.HomeQueries.GetAllHomes;
using HomeSeeker.API.Queries.HomeQueries.GetHomeById;
using HomeSeeker.API.Queries.HomeQueries.GetHomesByUserId;
using HomeSeeker.API.Queries.HomeQueries.GetMaxPrice;

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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomesController(ISender mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        [ProducesResponseType(typeof(List<HomeModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var homes = await _mediator.Send(new GetAllHomesQuery());
                return Ok(homes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [ProducesResponseType(typeof(List<HomeModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status400BadRequest)]
        [HttpGet("getActive")]
        public async Task<IActionResult> GetActive([FromQuery] GetActiveHomesQuery query)
        {
            try
            {
                var homes = await _mediator.Send(query);
                return Ok(homes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(HomeModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status400BadRequest)]
        [HttpGet("getById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var home = await _mediator.Send(new GetHomeByIdQuery(id));
                return Ok(home);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(List<HomeModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status400BadRequest)]
        [HttpGet("getByUser")]
        public async Task<IActionResult> GetByUser()
        {
            try
            {
                var user = (UserModel)_httpContextAccessor.HttpContext.Items["User"];
                var home = await _mediator.Send(new GetHomesByUserIdQuery(user.Id));
                return Ok(home);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status400BadRequest)]
        [HttpGet("getMaxPrice")]
        public async Task<IActionResult> GetMaxPrice()
        {
            try
            {
                var maxPrice = await _mediator.Send(new GetMaxPriceQuery());
                return Ok(maxPrice);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(OperationResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status400BadRequest)]
        [HttpPost("add")]
        public async Task<IActionResult> Add(AddHomeCommand model)
        {
            try
            {
                await _mediator.Send(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Home added successfully");
        }


        [ProducesResponseType(typeof(OperationResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status404NotFound)]
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateHomeCommand model)
        {
            try
            {
                await _mediator.Send(model);
            }
            catch (NullReferenceException ex)
            {
                return NotFound("Home not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Home updated successfully");
        }

        [ProducesResponseType(typeof(OperationResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status400BadRequest)]
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteHomeCommand model)
        {
            try
            {
                await _mediator.Send(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Home deleted successfully"); ;
        }
    }
}

using HomeSeeker.API.Authorization.Attributes;
using HomeSeeker.API.Commands.UserCommands;
using HomeSeeker.API.Queries.UserQueries;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Data.Enums;

using System.Threading.Tasks;
using System;
using HomeSeeker.API.Models;
using HomeSeeker.API.Models.CustomResults;
using System.Collections.Generic;

namespace HomeSeeker.API.Controllers.UserControllers
{

    [Authorize(Role.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISender _mediator;

        public UsersController(ISender mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [ProducesResponseType(typeof(OperationResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status400BadRequest)]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand model)
        {
            try
            {
                var response = await _mediator.Send(model);
                if (!response.Success)
                {
                    return BadRequest(new { message = response.FailureMessage });
                }
                return Ok(response);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [AllowAnonymous]
        [ProducesResponseType(typeof(AuthenticateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status400BadRequest)]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateQuery model)
        {
            try
            {
                var response = await _mediator.Send(model);
                if (response == null)
                {
                    return BadRequest(new { message = "Username or password is incorrect" });
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(typeof(List<UserModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ObjectResult), StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _mediator.Send(new GetAllUsersQuery());
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

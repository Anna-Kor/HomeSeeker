using HomeSeeker.API.Authorization.Attributes;
using HomeSeeker.API.Commands.UserCommands;
using HomeSeeker.API.Models;
using HomeSeeker.API.Queries.UserQueries;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Data.Enums;

using System.Threading.Tasks;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserCommand model)
        {
            await _mediator.Send(model);
            return Ok();
        }

        [AllowAnonymous]
        [ProducesResponseType(typeof(AuthenticateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AuthenticateResponse), StatusCodes.Status400BadRequest)]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateQuery model)
        {
            var response = await _mediator.Send(model);
            if (response == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            return Ok(response);
        }

        [ProducesResponseType(typeof(List<UserModel>), StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return Ok(users);
        }
    }
}

using Microsoft.AspNetCore.Http;

using System.Linq;
using System.Threading.Tasks;

using HomeSeeker.API.Authorization.Utils;
using HomeSeeker.API.Queries.UserQueries.GetUserById;

using MediatR;

namespace HomeSeeker.API.Authorization 
{
    public class JwtMiddleware : IMiddleware
    {
        private readonly IJwtUtils _jwtUtils;
        private readonly IMediator _mediator;

        public JwtMiddleware(IJwtUtils jwtUtils, IMediator mediator)
        {
            _jwtUtils = jwtUtils;
            _mediator = mediator;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _jwtUtils.ValidateJwtToken(token);

            if (userId != null)
            {
                context.Items["User"] = await _mediator.Send(new GetUserByIdQuery(userId.Value));
            }

            await next(context);
        }
    }
}

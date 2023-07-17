using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Linq;
using System.Threading.Tasks;

using HomeSeeker.API.Authorization.Utils;
using HomeSeeker.API.Queries.UserQueries;

using MediatR;

namespace HomeSeeker.API.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        public JwtMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task Invoke(HttpContext context, IJwtUtils jwtUtils)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var userId = jwtUtils.ValidateJwtToken(token);

                if (userId != null)
                {
                    context.Items["User"] = await mediator.Send(new GetUserByIdQuery(userId.Value));
                }

                await _next(context);
            }
        }
    }
}

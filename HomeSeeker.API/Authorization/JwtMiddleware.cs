using Microsoft.AspNetCore.Http;

using System.Linq;
using System.Threading.Tasks;

using HomeSeeker.API.Authorization.Utils;

namespace HomeSeeker.API.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IJwtUtils jwtUtils)
        {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var userId = jwtUtils.ValidateJwtToken(token);

                if (userId != null)
                {
                    context.Items["UserId"] = userId;
                }

                await _next(context);
        }
    }
}

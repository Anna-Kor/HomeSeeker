using Data.Models;

namespace HomeSeeker.API.Authorization.Utils
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public int? ValidateJwtToken(string? token);
    }
}

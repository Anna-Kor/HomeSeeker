using HomeSeeker.API.Models;

namespace HomeSeeker.API.Authorization.Utils
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(UserModel user);
        public int? ValidateJwtToken(string? token);
    }
}

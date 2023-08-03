using Data.Enums;

namespace HomeSeeker.API.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(UserModel user, string token)
        {
            Id = user.Id;
            Role = user.Role;
            Username = user.Username;
            Token = token;
        }
    }
}

using Newtonsoft.Json;

namespace HomeSeeker.API.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        [JsonIgnore]
        public byte[] Salt { get; set; }
    }
}

namespace HomeSeeker.API.Authorization.Helpers
{
    public interface IPasswordHelper
    {
        string HashPassword(string password, out byte[] salt);

        bool VerifyPassword(string password, string hash, byte[] salt);
    }
}

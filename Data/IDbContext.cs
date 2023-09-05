using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public interface IDbContext : IDisposable
    {
        DbSet<Home> Homes { get; set; }
        DbSet<User> Users { get; set; }
    }
}

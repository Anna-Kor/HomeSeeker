using Data.Models;

using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class HomeSeekerDBContext : DbContext, IDbContext
    {
        public HomeSeekerDBContext(DbContextOptions<HomeSeekerDBContext> options):base(options)
        {
            
        }

        public DbSet<Home> Homes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

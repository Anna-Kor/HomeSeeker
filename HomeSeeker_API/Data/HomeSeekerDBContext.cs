using Microsoft.EntityFrameworkCore;

using HomeSeeker_API.Models;

namespace HomeSeeker_API.Data
{
    public class HomeSeekerDBContext : DbContext
    {
        public HomeSeekerDBContext(DbContextOptions<HomeSeekerDBContext> options):base(options)
        {
            
        }

        public DbSet<Home> Homes { get; set; }
    }
}

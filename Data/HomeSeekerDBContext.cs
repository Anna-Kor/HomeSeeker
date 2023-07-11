using Data.Models;

using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class HomeSeekerDBContext : DbContext
    {
        public HomeSeekerDBContext(DbContextOptions<HomeSeekerDBContext> options):base(options)
        {
            
        }

        public DbSet<Bathroom> Bathrooms { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<FloorsNumbers> FloorsNumbers { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Models.Type> Types { get; set; }
    }
}

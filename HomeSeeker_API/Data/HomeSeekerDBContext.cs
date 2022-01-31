using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeSeeker_API.Models;
using Microsoft.EntityFrameworkCore;

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

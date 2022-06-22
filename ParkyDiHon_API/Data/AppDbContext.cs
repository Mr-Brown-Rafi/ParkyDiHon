using Microsoft.EntityFrameworkCore;
using ParkyDiHon_API.Models;

namespace ParkyDiHon_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }
        public DbSet<NationalPark> nationalParks { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Vejrstation.Entities;

namespace Vejrstation.Data
{
    public class WeatherServerDbContext : DbContext
    {
        public WeatherServerDbContext(DbContextOptions<WeatherServerDbContext> options)
            : base(options)
        {

        }
        public DbSet<WeatherObservation> WeatherObservations { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
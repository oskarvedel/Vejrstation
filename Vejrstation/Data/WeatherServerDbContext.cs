using Microsoft.EntityFrameworkCore;
using Vejrstation.Entities;
using Vejrstation.EntityConfigurations;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new WeatherObservationConfigurations());
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Vejrstation.Entities;
using Vejrstation.EntityConfigurations;

namespace Vejrstation.Data
{
    public class WeatherServerDbContext : DbContext
    {
        public DbSet<WeatherObservation> WeatherObservations { get; set; }
        public DbSet<Account> Accounts { get; set; }
        
        public WeatherServerDbContext(DbContextOptions<WeatherServerDbContext> options)
            : base(options)
        {

        }
   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new WeatherObservationConfigurations());
            modelBuilder.ApplyConfiguration(new AccountConfigurations());
        }
    }
}
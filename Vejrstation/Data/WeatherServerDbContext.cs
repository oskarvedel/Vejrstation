using Microsoft.EntityFrameworkCore;

namespace Vejrstation.Data
{
    public class WeatherServerDbContext : DbContext
    {
        public WeatherServerDbContext(DbContextOptions<WeatherServerDbContext> options)
            : base(options) { }
        {
            
        }
    }
}
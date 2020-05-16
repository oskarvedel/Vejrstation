using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vejrstation.Data;
using Vejrstation.Entities;
using Vejrstation.Interfaces;

namespace Vejrstation.Repository
{
    public class WeatherObservationRepository : Repository<WeatherObservation>, IWeatherObservationRepository
    {
        public WeatherObservationRepository(WeatherServerDbContext context): base(context)
        {
        }

        public async Task<IEnumerable<WeatherObservation>> GetThreeLast()
        {
            return await context.WeatherObservations
                .OrderByDescending(x => x.Date)
                .Take(3)
                .ToListAsync();
        }

        public async Task<IEnumerable<WeatherObservation>> GetOnDate(DateTime date)
        {
            return await context.WeatherObservations
                .Where(x => x.Date == date)
                .ToListAsync();
        }

        public async Task<IEnumerable<WeatherObservation>> GetBetween(DateTime startDateTime, DateTime enDateTime)
        {
            return await context.WeatherObservations
                .Where(x => startDateTime <= x.Date && x.Date >= enDateTime)
                .ToListAsync();
        }
    }
}

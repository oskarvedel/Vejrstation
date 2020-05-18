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

        public async Task<IEnumerable<WeatherObservation>> GetLastThree()
        {
            return await context.WeatherObservations
                .OrderByDescending(x => x.Id)
                .Take(3)
                .ToListAsync();
        }

        public async Task<IEnumerable<WeatherObservation>> GetOnDate(DateTime date)
        {
            return await context.WeatherObservations
                .Where(x => x.Date.Year == date.Year && x.Date.Month == date.Month && x.Date.Date == date.Date )
                .ToListAsync();
        }

        public async Task<IEnumerable<WeatherObservation>> GetBetween(DateTime startDateTime, DateTime endDateTime)
        {
            return await context.WeatherObservations
                .Where(x => x.Date >= startDateTime && x.Date <= endDateTime)
                .ToListAsync();
        }
    }
}

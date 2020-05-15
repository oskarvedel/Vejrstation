using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IEnumerable<WeatherObservation> GetThreeLast()
        {
            return context.WeatherObservations
                .OrderByDescending(x => x.Date)
                .Take(3)
                .ToList();
        }

        public IEnumerable<WeatherObservation> GetOnDate(DateTime date)
        {
            return context.WeatherObservations
                .Where(x => x.Date == date)
                .ToList();
        }

        public IEnumerable<WeatherObservation> GetBetween(DateTime startDateTime, DateTime enDateTime)
        {
            return context.WeatherObservations
                .Where(x => startDateTime <= x.Date && x.Date >= enDateTime)
                .ToList();
        }
    }
}

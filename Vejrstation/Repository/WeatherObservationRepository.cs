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
        private WeatherServerDbContext db;

        public WeatherObservationRepository(WeatherServerDbContext db): base(db)
        {
            this.db = db;
        }

        public IEnumerable<WeatherObservation> GetThreeLast()
        {
            return Context.Set<WeatherObservation>()
                .OrderByDescending(x => x.Date)
                .Take(3)
                .ToList();
        }

        public IEnumerable<WeatherObservation> GetOnDate(DateTime date)
        {
            return Context.Set<WeatherObservation>()
                .Where(x => x.Date == date)
                .ToList();
        }

        public IEnumerable<WeatherObservation> GetBetween(DateTime startDateTime, DateTime enDateTime)
        {
            return Context.Set<WeatherObservation>()
                .Where(x => startDateTime <= x.Date && x.Date >= enDateTime)
                .ToList();
        }
    }
}

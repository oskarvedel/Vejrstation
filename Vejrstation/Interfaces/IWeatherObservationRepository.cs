using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vejrstation.Entities;

namespace Vejrstation.Interfaces
{
    public interface IWeatherObservationRepository: IRepository<WeatherObservation>
    {
        IEnumerable<WeatherObservation> GetThreeLast();

        IEnumerable<WeatherObservation> GetOnDate(DateTime date);
        IEnumerable<WeatherObservation> GetBetween(DateTime startDate, DateTime enDateTime);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vejrstation.Entities;

namespace Vejrstation.Interfaces
{
    public interface IWeatherObservationRepository: IRepository<WeatherObservation>
    {
        Task<IEnumerable<WeatherObservation>> GetLastThree();

        Task<IEnumerable<WeatherObservation>> GetOnDate(DateTime date);
        Task<IEnumerable<WeatherObservation>> GetBetween(DateTime startDate, DateTime enDateTime);
    }
}

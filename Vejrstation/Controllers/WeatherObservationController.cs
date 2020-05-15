using Vejrstation.Interfaces;

namespace Vejrstation.Controllers
{
    [ApiController]
    public class WeatherObservationController
    {
        private readonly IWeatherObservationRepository _repository;
        
        public WeatherObservationController(IWeatherObservationRepository repository)
        {
            this._repository = repository;
        }
        
    }
}
using Microsoft.AspNetCore.Mvc;
using Vejrstation.Interfaces;

namespace Vejrstation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherObservationController
    {
        private readonly IWeatherObservationRepository _repository;
        
        public WeatherObservationController(IWeatherObservationRepository repository)
        {
            this._repository = repository;
        }
        
    }
}
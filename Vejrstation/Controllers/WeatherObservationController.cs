using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vejrstation.Interfaces;
using System.Net.Http;
using Vejrstation.Entities;

namespace Vejrstation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherObservationController: ControllerBase
    {
        private readonly IWeatherObservationRepository _repository;
        
        public WeatherObservationController(IWeatherObservationRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public IActionResult GetThreeLast()
        {
            var toSend =  _repository.GetThreeLast();
            return Ok(toSend);
        }

        [HttpGet("{date}")]
        public IActionResult GetOnDate(DateTime date)
        {
            var toSend =  _repository.GetOnDate(date);
            return Ok(toSend);
        }

        [HttpGet("{startDateTime}/{endDateTime}")]
        public IActionResult GetBetween(DateTime startDateTime, DateTime endDateTime)
        {
            var toSend = _repository.GetBetween(startDateTime,endDateTime);
            return Ok(toSend);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntity([FromBody] WeatherObservation wo)
        {
            _repository.Create(wo);
            return Ok(wo);
        }
    }
}
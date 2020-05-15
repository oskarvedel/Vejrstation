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

        [HttpGet("GetLastfive")]
        public IActionResult GetLastfive()
        {
            var toSend =  _repository.GetFiveLast();
            return Ok(toSend);
        }

        [HttpGet("GetOnDate")]
        public IActionResult GetOnDate(DateTime date)
        {
            var toSend =  _repository.GetOnDate(date);
            return Ok(toSend);
        }

        [HttpGet("GetBetween")]
        public IActionResult GetBetweentwo(DateTime startDateTimeTime, DateTime endDateTime)
        {
            var toSend = _repository.GetBetween(startDateTimeTime,endDateTime);
            return Ok(toSend);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateEntity([FromBody] WeatherObservation wo)
        {
            _repository.Create(wo);
            return Ok(wo);
        }
    }
}
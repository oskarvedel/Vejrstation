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
        public async Task<IActionResult> GetThreeLast()
        {
            var toSend = await _repository.GetThreeLast();
            return Ok(toSend);
        }

        [HttpGet("{date}")]
        public async Task<IActionResult> GetOnDate(DateTime date)
        {
            var toSend =  await _repository.GetOnDate(date);
            return Ok(toSend);
        }

        [HttpGet("{startDateTime}/{endDateTime}")]
        public async Task<IActionResult> GetBetween(DateTime startDateTime, DateTime endDateTime)
        {
            var toSend = await _repository.GetBetween(startDateTime,endDateTime);
            return Ok(toSend);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntity([FromBody] WeatherObservation wo)
        {
            await _repository.Create(wo);
            return Ok(wo);
        }
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vejrstation.Interfaces;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Vejrstation.DTO;
using Vejrstation.Entities;

namespace Vejrstation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class WeatherObservationController: ControllerBase
    {
        private readonly IWeatherObservationRepository _repository;
        
        public WeatherObservationController(IWeatherObservationRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetLastThree()
        {
            var toSend = await _repository.GetLastThree();
            return Ok(toSend);
        }

        [HttpGet("{date}"), AllowAnonymous]
        public async Task<IActionResult> GetOnDate(DateTime date)
        {
            var toSend =  await _repository.GetOnDate(date);
            return Ok(toSend);
        }

        [HttpGet("{startDateTime}/{endDateTime}"), AllowAnonymous]
        public async Task<IActionResult> GetBetween(DateTime startDateTime, DateTime endDateTime)
        {
            var toSend = await _repository.GetBetween(startDateTime,endDateTime);
            return Ok(toSend);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntity([FromBody] WeatherObservationRequest request)
        {
            var observation = new WeatherObservation
            {
                Date = request.Date,
                Name = request.Name,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                TemperatureCelsius = request.TemperatureCelsius,
                Humidity_Percentage = request.Humidity_Percentage,
                Pressure_Millibar = request.Pressure_Millibar
            };
            var createdObservation = await _repository.Create(observation);
            return Created(createdObservation.Id.ToString(),createdObservation);
        }
    }
}
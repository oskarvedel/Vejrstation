using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vejrstation.Interfaces;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Vejrstation.DTO;
using Vejrstation.Entities;
using Vejrstation.Hubs;

namespace Vejrstation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class WeatherObservationController: ControllerBase
    {
        private IHubContext<LiveUpdateHub> _liveUpdateHub;
        private readonly IWeatherObservationRepository _repository;
        
        public WeatherObservationController(IWeatherObservationRepository repository, IHubContext<LiveUpdateHub> liveUpdateHub)
        {
            this._repository = repository;
            this._liveUpdateHub = liveUpdateHub;
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
        public async Task<ActionResult> CreateEntity([FromBody] WeatherObservationRequest request)
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

            await _liveUpdateHub.Clients.All.SendAsync("newObservation", createdObservation);
            
            return Created(createdObservation.Id.ToString(),createdObservation);
        }
    }
}
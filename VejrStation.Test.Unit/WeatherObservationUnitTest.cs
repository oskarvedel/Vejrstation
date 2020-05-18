using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NUnit.Framework;
using NSubstitute;
using Vejrstation.Controllers;
using Vejrstation.DTO;
using Vejrstation.Entities;
using Vejrstation.Hubs;
using Vejrstation.Interfaces;

namespace Vejrstation.Test.Unit
{
    [TestFixture]
    class WeatherObservationUnitTest
    {
        private IWeatherObservationRepository _weatherObservationRepository;
        private IHubContext<LiveUpdateHub> _hubContext;
        private WeatherObservationController _uut;
        [SetUp]
        public void Setup()
        {
            _weatherObservationRepository = Substitute.For<IWeatherObservationRepository>();
            _hubContext = Substitute.For<IHubContext<LiveUpdateHub>>();
            _uut= new WeatherObservationController(_weatherObservationRepository,_hubContext);
        }


        [Test]
        public async Task GetLastThreeWeatherObservations()
        {
            //Arrange

            //Act
            var result = (await _uut.GetLastThree()) as ObjectResult;   

            //Assert
            Assert.NotNull(result);
            await _weatherObservationRepository.Received().GetLastThree();
        }

        [Test]
        public async Task GetWeatherObservationByDate()
        {
            //Arrange
            WeatherObservation weatherObservations = new WeatherObservation()
            {

                Date = new DateTime(2020, 6, 20),
                    Name = "Vejle",
                    Latitude = 1013031,
                    Longitude = 2554322,
                    TemperatureCelsius = 11,
                    Humidity_Percentage = 14,
                    Pressure_Millibar = 5
            };
            //Act
            var result = (await _uut.GetOnDate(new DateTime(2020, 6, 20))) as ObjectResult;

            //Assert
            Assert.NotNull(result);
            await _weatherObservationRepository.Received().GetOnDate(new DateTime(2020,6,20));

        }

        [Test]
        public async Task GetWeatherObservationsBetweenDates()
        {
            //Arrange
            WeatherObservation weatherObservations = new WeatherObservation()
            {

                    Date = new DateTime(2020, 6, 20),
                    Name = "Vordingborg",
                    Latitude = 10130343,
                    Longitude = 255522,
                    TemperatureCelsius = 1,
                    Humidity_Percentage = 4,
                    Pressure_Millibar = 1
            };

            //Act
            var result = (await _uut.GetBetween(new DateTime(2020, 6, 28),new DateTime(2020,6,10))) as ObjectResult;

            //Assert
            Assert.NotNull(result);
            await _weatherObservationRepository.Received().GetBetween(new DateTime(2020, 6, 20), new DateTime(2020, 6, 10));
        }

        [Test]
        public async Task CreateWeatherObservation()
        {
            
            WeatherObservationRequest weatherObservations = new WeatherObservationRequest()
            {

                    Date = new DateTime(2020, 2, 8),
                    Name = "Ikast",
                    Latitude = 10120343,
                    Longitude = 2667522,
                    TemperatureCelsius = 40,
                    Humidity_Percentage = 700,
                    Pressure_Millibar = 0
            };

            WeatherObservation observation = new WeatherObservation
            {
                Date = weatherObservations.Date,
                Name = weatherObservations.Name,
                Latitude = weatherObservations.Latitude,
                Longitude = weatherObservations.Longitude,
                TemperatureCelsius = weatherObservations.TemperatureCelsius,
                Humidity_Percentage = weatherObservations.Humidity_Percentage,
                Pressure_Millibar = weatherObservations.Pressure_Millibar
            };

            var result = (await _uut.CreateEntity(weatherObservations)) as ObjectResult;
            
            Assert.NotNull(result);
            await _weatherObservationRepository.Received().Create(observation);

        }
    }
}

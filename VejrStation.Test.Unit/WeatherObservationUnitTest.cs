﻿using System;
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
using System.Text.Json;


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
        public void CreateWeatherObservation()
        {
            //Arrange
            WeatherObservationRequest weatherObservation = new WeatherObservationRequest()
            {

                    Date = new DateTime(2020, 2, 8),
                    Name = "Ikast",
                    Latitude = 10120343,
                    Longitude = 2667522,
                    TemperatureCelsius = 40,
                    Humidity_Percentage = 700,
                    Pressure_Millibar = 0
            };

            WeatherObservation observationCreated = new WeatherObservation
            {
                Date = weatherObservation.Date,
                Name = weatherObservation.Name,
                Latitude = weatherObservation.Latitude,
                Longitude = weatherObservation.Longitude,
                TemperatureCelsius = weatherObservation.TemperatureCelsius,
                Humidity_Percentage = weatherObservation.Humidity_Percentage,
                Pressure_Millibar = weatherObservation.Pressure_Millibar
            };
            
            WeatherObservation observationReturned = new WeatherObservation
            {
                Id = 3,
                Date = weatherObservation.Date,
                Name = weatherObservation.Name,
                Latitude = weatherObservation.Latitude,
                Longitude = weatherObservation.Longitude,
                TemperatureCelsius = weatherObservation.TemperatureCelsius,
                Humidity_Percentage = weatherObservation.Humidity_Percentage,
                Pressure_Millibar = weatherObservation.Pressure_Millibar
            };

            _weatherObservationRepository.Create(observationCreated).Returns(observationReturned);
                
            //Act
            var result =  _uut.CreateEntity(weatherObservation).Result as CreatedResult;
            var jsonActual = JsonSerializer.Serialize(result.Value);
            //Assert.NotNull(jsonActual);
            _weatherObservationRepository.Received(1).Create(observationCreated);
        }
    }
}

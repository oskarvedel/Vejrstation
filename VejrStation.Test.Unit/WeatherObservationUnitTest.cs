using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NUnit.Framework;
using NSubstitute;
using Vejrstation.Controllers;
using Vejrstation.DTO;
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
    }
}

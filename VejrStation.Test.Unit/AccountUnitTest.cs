using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using NSubstitute;
using NUnit.Framework;
using Vejrstation.Controllers;
using Vejrstation.DTO;
using Vejrstation.Entities;
using Vejrstation.Interfaces;
using System.Text.Json;
using static BCrypt.Net.BCrypt;


namespace Vejrstation.Test.Unit
{
    public class AccountUnitTest
    {
        private AccountController _uut;
        private IAccountRepository _repository;
        
        
        [SetUp]
        public void Setup()
        {
            _repository = Substitute.For<IAccountRepository>();
            _uut = new AccountController(_repository);
        }

        [Test]
        public void LoginFails_UserDoesNotExist()
        {
            //Arrange
            var request = new AccountRequest()
            {
                UserName = "Jens",
                Password = "1234jajaja"
            };
            
            _repository.GetByUserName("Jens").Returns((Account)null);
            
            //Act
            var result = _uut.Login(request).Result as ObjectResult;
            
            //Assert
            var expected = new {success = false, message = "Username doesn't exist. Please register an account."};
            var jsonActual = JsonSerializer.Serialize(result.Value);
            var jsonExpected = JsonSerializer.Serialize(expected);

            Assert.That(jsonActual, Is.EqualTo(jsonExpected));
        }
        
        [Test]
        public void LoginSuccess()
        {
            //Arrange
            var request = new AccountRequest()
            {
                UserName = "Jens",
                Password = "1234jajaja"
            };
            
            var account = new Account
            {
                Id = 3,
                UserName = "Jens",
                PasswordHash = HashPassword("1234jajaja", 10)
            };
            
            _repository.GetByUserName("Jens").Returns(account);
            
            //Act
            var result = _uut.Login(request).Result as ObjectResult;
            //Assert
            var jsonActual = JsonSerializer.Serialize(result.Value);

            Assert.That(jsonActual.Contains("jwt"));
        }
        
        
    }
}
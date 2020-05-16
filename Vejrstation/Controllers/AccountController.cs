using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vejrstation.Interfaces;
using System.Net.Http;
using Vejrstation.DTO;
using Vejrstation.Entities;
using static BCrypt.Net.BCrypt;



namespace Vejrstation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _repository;
        
        public AccountController(IAccountRepository repository)
        {
            this._repository = repository;
        }

        [HttpPost("/register")]
        public IActionResult Post([FromBody] AccountRequest request)
        {
            if (_repository.GetByUserName(request.UserName) != null)
            {
                return Ok(new {success = false, message="UserName already exists, try logging in."});
            }

            new Account()
            {
                UserName = request.UserName,
                PasswordHash = HashPassword(request.Password, Settings.BCryptWorkFactor)
            };
            

            return Ok();
        }
        
    }
}
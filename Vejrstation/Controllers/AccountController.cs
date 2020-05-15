using Microsoft.AspNetCore.Mvc;
using Vejrstation.Interfaces;

namespace Vejrstation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController
    {
        private readonly IAccountRepository _repository;
        
        public AccountController(IAccountRepository repository)
        {
            this._repository = repository;
        }
    }
}
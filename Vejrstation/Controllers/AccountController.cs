using Vejrstation.Interfaces;

namespace Vejrstation.Controllers
{
    public class AccountController
    {
        private readonly IAccountRepository _repository;
        
        public AccountController(IAccountRepository repository)
        {
            this._repository = repository;
        }
    }
}
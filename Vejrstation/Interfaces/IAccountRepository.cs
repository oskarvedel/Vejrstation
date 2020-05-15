using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vejrstation.Controllers;
using Vejrstation.Entities;

namespace Vejrstation.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
    }
}
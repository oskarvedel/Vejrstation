using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Vejrstation.Controllers;
using Vejrstation.Entities;

namespace Vejrstation.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        public Task<Account> GetByUserName(string userName);
    }
}
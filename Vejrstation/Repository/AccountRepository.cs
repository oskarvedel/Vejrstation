using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vejrstation.Data;
using Vejrstation.Entities;
using Vejrstation.Interfaces;

namespace Vejrstation.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(WeatherServerDbContext context) : base(context)
        {
            
        }

        public async Task<Account> GetByUserName(string userName)
        {
            var account = await context.Accounts.Where(a => a.UserName == userName).ToListAsync();
            return account.FirstOrDefault();
        }
    }
}
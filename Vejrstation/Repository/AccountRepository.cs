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
    }
}
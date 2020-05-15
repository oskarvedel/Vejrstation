using Microsoft.EntityFrameworkCore;
using Vejrstation.Entities;
using Vejrstation.Interfaces;

namespace Vejrstation.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(DbContext context) : base(context)
        {
        }
        
        
    }
}
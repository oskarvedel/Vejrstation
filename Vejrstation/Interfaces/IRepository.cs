using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vejrstation.Data;

namespace Vejrstation.Interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Read(int id);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(int id);
    }
}

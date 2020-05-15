using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vejrstation.Data;

namespace Vejrstation.Interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
        void Create(TEntity entity);
        TEntity Read(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vejrstation.Interfaces;

namespace Vejrstation.Repository
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity: class
    {
        public virtual TEntity Read(int id)
        {
            //return Context.Set<TEntity>().Find(id);
        }

        public virtual void Create(TEntity entity)
        {
            //Context.Set<TEntity>().Add(entity);
        }
    }
}

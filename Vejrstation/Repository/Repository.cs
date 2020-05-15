using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vejrstation.Data;
using Vejrstation.Interfaces;

namespace Vejrstation.Repository
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity: class
    {
        protected WeatherServerDbContext context;

        public Repository(WeatherServerDbContext context)
        {
            this.context = context;
        }
        public  TEntity Read(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public void Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }
    }
}

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
        public async Task<TEntity> Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        
        public async Task<TEntity> Read(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
        
        public async Task<TEntity> Delete(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();

            return entity;
        }
        
    }
}

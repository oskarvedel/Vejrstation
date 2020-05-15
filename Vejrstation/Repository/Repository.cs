﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vejrstation.Interfaces;

namespace Vejrstation.Repository
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity: class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }
        public virtual TEntity Read(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual void Create(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }
    }
}
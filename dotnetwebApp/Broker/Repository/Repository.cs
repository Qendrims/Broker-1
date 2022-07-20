﻿
using Broker.ApplicationDB;
using Broker.Services.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Broker.Services.Repository
{


    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _Dbcontext;
        internal DbSet<T> dbSet;
        private readonly ILogger _logger;

        public Repository(ApplicationDbContext Dbcontext, ILogger logger)
        {
            this._Dbcontext = Dbcontext; 
            this.dbSet = _Dbcontext.Set<T>();
            this._logger = logger;
        }
        
        
        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public List<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList(); 
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

    }
}

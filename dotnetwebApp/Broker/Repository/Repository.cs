
using Broker.ApplicationDB;
using Broker.Services.Repository.IRepository;
using Broker.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Broker.Services.Repository
{


    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _Dbcontext;
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

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            var entry = _Dbcontext.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Include(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

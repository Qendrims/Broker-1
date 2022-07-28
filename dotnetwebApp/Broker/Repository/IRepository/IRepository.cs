using Broker.ApplicationDB;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Broker.Services.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T- Post
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);

        List<T> GetAll();

        void Add(T entity);

        void Remove(T entity);




    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KendoTuto.Infrastructure
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null);
        IQueryable<T> GetAll();
        T Find(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}

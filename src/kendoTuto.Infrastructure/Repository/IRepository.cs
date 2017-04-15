using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KendoTuto.Infrastructure.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null);
        IEnumerable<T> GetAll();
        T Find(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}

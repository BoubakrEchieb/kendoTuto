using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Paie01.Infrastructure.Service
{
    public interface IService<T>  where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
    }
}

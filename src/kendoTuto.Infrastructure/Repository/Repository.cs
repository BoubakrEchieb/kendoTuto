using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KendoTuto.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }

        // Implementing IRepository
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        public T Find(Expression<Func<T, bool>> filter)
        {
            if(filter != null)
            {
                return _context.Set<T>().Where(filter).FirstOrDefault();
            }
            return null;
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return _context.Set<T>().Where(filter).ToList();
            }
            return _context.Set<T>().ToList();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        // Implementing IDispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
        }
       
    }
}

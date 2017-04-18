using kendoTuto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KendoTuto.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }

        // Implementing IRepository
        public virtual T Add(T entity)
        {
            var result = _context.Set<T>().Add(entity).Entity;
            return result;
        }
        public virtual T Find(Expression<Func<T, bool>> filter)
        {
            if(filter != null)
            {
                return _context.Set<T>().Where(filter).FirstOrDefault();
            }
            return null;
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return _context.Set<T>().Where(filter);
            }
            return _context.Set<T>();
        }

        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual IQueryable<T> GetAll()
        {
            var qf = _context.Set<T>();
            var result = _context.Set<T>();
            return result;
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

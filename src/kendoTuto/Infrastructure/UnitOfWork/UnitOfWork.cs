using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KendoTuto.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        protected DbContext _context;
        protected bool disposed;
        public UnitOfWork(DbContext context)
        {
            _context = context;
            disposed = false;
        }
        public virtual void Commit()
        {
            _context.SaveChanges();
        }
        public virtual IRepository<T> Repository<T>() where T : class
        {
            return new Repository<T>(_context);
        }
        // Implementing IDispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
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

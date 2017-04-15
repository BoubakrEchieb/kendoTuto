using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KendoTuto.Infrastructure.Repository;

namespace KendoTuto.Infrastructure.UnitOfW
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        private bool disposed;
        public UnitOfWork(DbContext context)
        {
            _context = context;
            disposed = false;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
        public IRepository<T> Repository<T>() where T : class
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

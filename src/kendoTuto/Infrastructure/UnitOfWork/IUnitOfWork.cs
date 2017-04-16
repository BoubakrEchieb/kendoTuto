using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KendoTuto.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;
        void Commit();
    }
}

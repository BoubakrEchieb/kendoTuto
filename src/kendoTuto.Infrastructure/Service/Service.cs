using KendoTuto.Infrastructure.UnitOfW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KendoTuto.Infrastructure.Service
{
    public class Service<T> : IService<T> where T : class
    {
        private UnitOfWork _unitOfWork;
        public Service(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            _unitOfWork.Repository<T>().Add(entity);
            _unitOfWork.Commit();
        }

        public void Delete(T entity)
        {
            _unitOfWork.Repository<T>().Remove(entity);
            _unitOfWork.Commit();
        }
        
        public T Get(Expression<Func<T, bool>> filter)
        {
            return _unitOfWork.Repository<T>().Find(filter);
        }

        public IEnumerable<T> GetAll()
        {
            return _unitOfWork.Repository<T>().Get();
        }

        public void Update(T entity)
        {
             _unitOfWork.Repository<T>().Update(entity);
        }
    }
}

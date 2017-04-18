using KendoTuto.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KendoTuto.Infrastructure
{
    public class Service<T> : IService<T> where T : class
    {
        protected UnitOfWork _unitOfWork { get; set; }
        public Service(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public virtual T Add(T entity)
        {
            var result = _unitOfWork.Repository<T>().Add(entity);
            _unitOfWork.Commit();
            return result;
        }

        public virtual void Delete(T entity)
        {
            _unitOfWork.Repository<T>().Remove(entity);
            _unitOfWork.Commit();
        }
        
        public virtual T Get(Expression<Func<T, bool>> filter)
        {
            return _unitOfWork.Repository<T>().Find(filter);
        }

        public virtual IQueryable<T> GetAll()
        {
            var result = _unitOfWork.Repository<T>().GetAll();
            return result;
        }

        public virtual void Update(T entity)
        {
             _unitOfWork.Repository<T>().Update(entity);
            _unitOfWork.Commit();
        }
    }
}

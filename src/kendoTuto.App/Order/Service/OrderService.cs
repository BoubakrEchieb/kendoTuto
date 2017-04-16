using kendoTuto.App.UOfW;
using kendoTuto.Domain.Entities;
using KendoTuto.Infrastructure.Service;
using KendoTuto.Infrastructure.UnitOfW;
using System.Linq;

namespace kendoTuto.App.Service
{
    public class OrderService : Service<Order>
    {
        public OrderService(UnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
        public IQueryable<Order> GetAllOrders()
        {
            return (_unitOfWork as AppUnitOfWork)._orderRepository.GetAll();
        }
    }
}

using kendoTuto.App.UOfW;
using kendoTuto.Domain.Entities;
using KendoTuto.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace kendoTuto.App.Service
{
    public class OrderService : Service<Order>
    {
        public OrderService(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

        public IQueryable<Order> GetAllOrders(int EmployeeId)
        {
            return (_unitOfWork as AppUnitOfWork)._orderRepository.Get(o=>o.Employee.EmployeeId==EmployeeId);
        }
    }
}

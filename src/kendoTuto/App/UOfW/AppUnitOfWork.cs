using KendoTuto.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using kendoTuto.App.Repository;

namespace kendoTuto.App.UOfW
{
    public class AppUnitOfWork : UnitOfWork
    {
        public OrderRepository _orderRepository { get; set; }
        public AppUnitOfWork(DbContext context) : base(context)
        {
            _orderRepository = new OrderRepository(context);
        }
    }
}

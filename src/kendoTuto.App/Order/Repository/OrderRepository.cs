using KendoTuto.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using kendoTuto.Domain.Entities;

namespace kendoTuto.App.Repository
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(DbContext context) : base(context)
        {

        }
        public override IQueryable<Order> GetAll()
        {
            var allOrders = _context.Set<Order>().Include(o => o.Employee);
            return allOrders;
        }
    }
}

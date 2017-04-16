using KendoTuto.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using kendoTuto.Domain.Entities;
using System.Linq.Expressions;

namespace kendoTuto.App.Repository
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(DbContext context) : base(context)
        {

        }
        public override IQueryable<Order> Get(Expression<Func<Order, bool>> filter = null)
        {
            var allOrders = _context.Set<Order>().Include(o => o.Employee).Where(filter);
            return allOrders;
        }
    }
}

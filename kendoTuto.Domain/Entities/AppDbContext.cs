using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using kendoTuto.Domain.Entities;

namespace kendoTuto.Domain.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}

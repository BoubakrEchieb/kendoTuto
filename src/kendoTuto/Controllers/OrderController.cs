using kendoTuto.App.Service;
using kendoTuto.App.UOfW;
using kendoTuto.App.ViewModels;
using kendoTuto.Domain.Entities;
using KendoTuto.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kendoTuto.Controllers
{
    [Route("api/Order")]
    public class OrderController: Controller
    {
        private AppDbContext _dbContext;
        //private Service<Employee> _employeeService;
        private OrderService _orderService;
        private AppUnitOfWork _unitOfWork;
        public OrderController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _unitOfWork = new AppUnitOfWork(_dbContext);
            _orderService = new OrderService(_unitOfWork);

            //_employeeService = new Service<Employee>(_unitOfWork);
            //var emp = _employeeService.Get(e => e.EmployeeId == 3);
            //_dbContext.Orders.Add(new Order() { ShipName = "jlk", ShipAdresse = "JJJD", ShipCountry = "HHklD", Employee = emp });
            //var er = _employeeService.Get(e => e.EmployeeId == 3);
            //_dbContext.Orders.Add(new Order() { ShipName = "mmmm", ShipAdresse = "yyy", ShipCountry = "yyyttt", Employee = er });
            //_dbContext.SaveChanges();
        }
        [HttpGet("GetAll/{EmployeeId}")]
        public IEnumerable<Order> GetAll(int EmployeeId)
        {
            var result = _orderService.GetAllOrders(EmployeeId);
            return result;
        }
    }
}

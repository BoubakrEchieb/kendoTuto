using kendoTuto.Domain.Entities;
using KendoTuto.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kendoTuto.Controllers
{
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        private AppDbContext _dbContext;
        private Service<Employee> _employeeService;
        private UnitOfWork _unitOfWork;
        public EmployeeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _unitOfWork = new UnitOfWork(_dbContext);
            _employeeService = new Service<Employee>(_unitOfWork);
            _employeeService = _employeeService;

            //Employee em = new Employee();
            //em.FirstName = "Ammar";
            //em.LastName = "Ali";
            //em.City = "LLD";
            //em.Country = "JFk";
            //_dbContext.Employees.Add(em);
            //_dbContext.SaveChanges();
        }
        [HttpGet("GetAll")]
        public IQueryable<Employee> GetAll()
        {
            var result = _employeeService.GetAll();
            return result;
        }

    }
}

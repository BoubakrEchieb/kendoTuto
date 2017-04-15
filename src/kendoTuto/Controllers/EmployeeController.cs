using kendoTuto.App.Service;
using kendoTuto.Domain.Entities;
using KendoTuto.Infrastructure.UnitOfW;
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
        private EmployeeService _employeeService;
        private UnitOfWork _unitOfWork;
        public EmployeeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _unitOfWork = new UnitOfWork(_dbContext);
            _employeeService = new EmployeeService(_unitOfWork);
            _employeeService.Add(new Employee() {FirstName="Ammar",LastName="Ali",City="LLD",Country="JFk" });
        }
        [HttpGet("GetAll")]
        public IEnumerable<Employee> GetAll()
        {
            var result = _employeeService.GetAll();
            return result;
        }
           
    }
}

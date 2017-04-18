using kendoTuto.Domain.Entities;
using kendoTuto.ViewModels;
using KendoTuto.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpPost("Create")]
        public IActionResult Create([FromBody]Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false });
            }
            var result = _employeeService.Add(employee);
            return new JsonResult(new { success = true, employee = result });
        }
        [HttpDelete("Remove/{id}")]
        public IActionResult Remove(int Id)
        {
            Employee empoyeeToDelete = _employeeService.Get(em => em.EmployeeId == Id);
            if(empoyeeToDelete == null)
            {
                return new JsonResult(new { success = false });
            }
            _employeeService.Delete(empoyeeToDelete);
            return new JsonResult(new { success = true });
        }
        [HttpPut("Update")]
        public IActionResult Update([FromBody] Employee employee)
        {
            _employeeService.Update(employee);
            return new JsonResult(new { success = true });
        }
    }
}

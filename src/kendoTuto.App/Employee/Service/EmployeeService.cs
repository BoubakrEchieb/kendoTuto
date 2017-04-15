using kendoTuto.Domain.Entities;
using KendoTuto.Infrastructure.Service;
using KendoTuto.Infrastructure.UnitOfW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kendoTuto.App.Service
{
    public class EmployeeService : Service<Employee>
    {
        public EmployeeService(UnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}

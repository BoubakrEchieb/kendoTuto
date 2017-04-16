using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kendoTuto.App.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string ShipCountry { get; set; }
        public string ShipAdresse { get; set; }
        public string ShipName { get; set; }
        public int EmployeeId { get; set; }
    }
}

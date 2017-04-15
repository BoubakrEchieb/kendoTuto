using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kendoTuto.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string ShipCountry { get; set; }
        public string ShipAdresse { get; set; }
        public string ShipName { get; set; }
        public Employee Employee { get; set; }
    }
}

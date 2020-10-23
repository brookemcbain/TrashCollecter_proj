using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollecter.Models
{
    public class EmployeeIndexViewModel
    {
        public List<Customer> Customers { get; set; }
        public string RequestedFilterDay { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersentationLayer.Models
{
    public class Employee
    {
            public int EmployeeNo { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public string Address { get; set; }
            public string MobileNo { get; set; }
            public string PostelCode { get; set; }
            public string EmailId { get; set; }
        }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Employee
    {
        public Guid? EmployeeId { get; set; }
        public Guid RoleId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Password { get; set; }
    }
}

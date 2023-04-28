using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class EmployeeModel
    {
        public int id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeEmail { get; set; }
        public string password { get; set; }
        public string EmployeeRole { get; set; }
        public int DepartmentId { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Employee : BaseEntity
    {
        public string EmployeeName { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeEmail { get; set; }
        public string Password { get; set; }
        public string EmployeeRole { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<EmployeeEvaluationAnswer> EmployeeEvaluationAnswers { get; set; }
    }
}

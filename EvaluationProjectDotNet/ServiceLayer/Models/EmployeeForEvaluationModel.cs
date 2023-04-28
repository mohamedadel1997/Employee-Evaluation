using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class EmployeeForEvaluationModel
    {
        public int id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeRole { get; set; }
        public int DepartmentId { get; set; }
    }
}

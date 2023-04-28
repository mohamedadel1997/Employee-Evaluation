using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Department : BaseEntity
    {
        public string DepartmentName { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Evaluation> Evaluations{ get; set; }

    }
}

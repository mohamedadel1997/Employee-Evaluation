using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class EmployeeEvaluation : BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int EvaluationId { get; set; }
        public Evaluation Evaluation { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class EmployeeEvaluationAnswer : BaseEntity
    {
        public double EmployeeAnswer { get; set; }
        public double ManagerAnswer { get; set; }
        public double FinalAnswer { get; set; }
        public string Comment { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int QuestionsEvaluationId { get; set; }
        public QuestionsEvaluation QuestionsEvaluation { get; set; }
    }
}

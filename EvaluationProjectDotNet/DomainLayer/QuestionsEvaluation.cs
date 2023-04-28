using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class QuestionsEvaluation : BaseEntity
    {
        public int EvaluationId { get; set; }
        public Evaluation Evaluation { get; set; }

        public int QuestionId { get; set; }
        public Questions Questions { get; set; }
        public ICollection<EmployeeEvaluationAnswer> EmployeeEvaluationAnswers { get; set; }
    }
}

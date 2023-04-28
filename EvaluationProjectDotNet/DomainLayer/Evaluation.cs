using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Evaluation : BaseEntity
    {
        public string EvaluationName { get; set; }
        public DateTime EvaluationStartDate { get; set; }
        public DateTime EvaluationEndTime{ get; set; }
        public DateTime EvaluationCreationTime { get; set; }
        public string EvaluationStatus { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<QuestionsEvaluation> QuestionsEvaluations { get; set; }

        //{
        //    Created,
        //    Employee_Submited,
        //    Manger_Submited,
        //    Finshed
        //}        
    }


}

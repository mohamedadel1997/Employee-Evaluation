using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class QuestionsForEvaluationModel
    {
        public int Id { get; set; }
        public int EvaluationId { get; set; }
        public int QuestionId { get; set; }
        public string Question { get; set; }
    }
}

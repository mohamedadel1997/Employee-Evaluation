using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Questions : BaseEntity
    {
        public string Question { get; set; }
        public ICollection<QuestionsEvaluation> QuestionsEvaluations { get; set; }
    }
}

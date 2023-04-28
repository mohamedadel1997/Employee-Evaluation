using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class AllEmployeeForOneEvaluationModel
    {
        public EvaluationModel EvaluationEntityModel { get; set; }
        public List<EmployeeForEvaluationModel> EmployeeForEvaluationModel { get; set; }
    }
}

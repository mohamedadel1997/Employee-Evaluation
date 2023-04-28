using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class AllEvaluationForOneEmployeeModel
    {


        public int employeeId { get; set; }
        public string employeeName { get; set; }
        public string employeeEmail { get; set; }
        public string employeeRole { get; set; }
        public List<EvaluationModel> evaluationModels { get; set; }
    }
}

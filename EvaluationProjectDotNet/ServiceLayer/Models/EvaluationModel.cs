using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class EvaluationModel
    {
        public int Id { get; set; }
        public string EvaluationName { get; set; }
        public DateTime EvaluationStartDate { get; set; }
        public DateTime EvaluationEndTime { get; set; }
        public DateTime EvaluationCreationTime { get; set; }
        public int DepartmentId { get; set; }
        public string EvaluationStatus { get; set; }

        public enum EvaluationStatusEnum
        {
            Created,
            Opened,
            EmployeeSubmitted,
            MangerSubmitted,
            Closed

        }
    }
}

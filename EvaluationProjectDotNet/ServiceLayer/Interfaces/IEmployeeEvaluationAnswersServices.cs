using DomainLayer;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IEmployeeEvaluationAnswersServices
    {
        List<EmployeeEvaluationAnswer> GetAllEmployeeEvaluationAnswers(int employeeId);
        void InsertEmployeeEvaluationAnswer(EmployeeAnswerModel employeeAnswerModel);
        void UpdateEmployeeEvaluationAnswer(EmployeeEvaluationAnswer employeeEvaluationAnswer);
    }
}

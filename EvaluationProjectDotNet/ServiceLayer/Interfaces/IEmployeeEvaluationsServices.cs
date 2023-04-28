using DomainLayer;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IEmployeeEvaluationsServices
    {
        List<EmployeeEvaluation> GetAllEmployeeEvaluationList();
        AllEmployeeForOneEvaluationModel GetAllEmployeeForOneEvaluation(int evaluationId);
        AllEvaluationForOneEmployeeModel GetAllEvaluationForOneEmployee(int employeeId);
        void InsertEvaluationForEmployee(EmployeeEvaluationsModel employeeEvaluation);
        void UpdateEvaluationForEmployee(EmployeeEvaluationsModel employeeEvaluation);
    }
}

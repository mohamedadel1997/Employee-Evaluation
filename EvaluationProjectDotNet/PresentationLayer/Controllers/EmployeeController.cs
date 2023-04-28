using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeEvaluationsServices _employeeEvaluationsServices;
        private readonly IEmployeeEvaluationAnswersServices _employeeEvaluationAnswersServices;

        public EmployeeController(IEmployeeEvaluationsServices employeeEvaluationsServices, IEmployeeEvaluationAnswersServices employeeEvaluationAnswersServices)
        {
            this._employeeEvaluationsServices = employeeEvaluationsServices;
            this._employeeEvaluationAnswersServices = employeeEvaluationAnswersServices;
        }

        [HttpGet(nameof(GetAllEmployeeForOneEvaluation))]
        public IActionResult GetAllEmployeeForOneEvaluation(int id)
        {
            var modelList = _employeeEvaluationsServices.GetAllEmployeeForOneEvaluation(id);
            if (modelList != null)
                return Ok(modelList);
            else
                return BadRequest("No employee For this Evaluation");
        }

        [HttpGet(nameof(GetAllEvaluationForEmployee))]
        public IActionResult GetAllEvaluationForEmployee(int id)
        {
            var modelList = _employeeEvaluationsServices.GetAllEvaluationForOneEmployee(id);
            if (modelList != null)
                return Ok(modelList);
            else
                return BadRequest("No Evaluation For this employee");
        }
      
        [HttpPost(nameof(AddEmployeeAnswer))]
        public IActionResult AddEmployeeAnswer(EmployeeAnswerModel employeeAnswerModel)
        {
            _employeeEvaluationAnswersServices.InsertEmployeeEvaluationAnswer(employeeAnswerModel);
            return Ok();
        }
    }
}

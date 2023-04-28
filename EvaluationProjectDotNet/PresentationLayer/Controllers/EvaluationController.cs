using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
        private readonly IEvaluationServices _evaluationServices;
        private readonly IQuestionsEvaluationServices _questionsEvaluationServices;

        public EvaluationController(IEvaluationServices evaluationServices,
            IQuestionsEvaluationServices questionsEvaluationServices)
        {
            this._evaluationServices = evaluationServices;
            this._questionsEvaluationServices = questionsEvaluationServices;
        }

        [HttpGet(nameof(GetAllEvaluation))]
        public IActionResult GetAllEvaluation()
        {
            return Ok(_evaluationServices.GetAllEvaluations());
        }

        [HttpPost(nameof(CreateEvaluation))]
        public IActionResult CreateEvaluation(EvaluationModel evaluationModel)
        {
            var data = _evaluationServices.CreateEvaluation(evaluationModel);
            return Ok(data);
        }

        [HttpPut(nameof(UpdateEvaluation))]
        public IActionResult UpdateEvaluation(EvaluationModel evaluationModel)
        {
            var updatedData = _evaluationServices.UpdateEvaluation(evaluationModel);
            return Ok(updatedData);
        }

        [HttpPost(nameof(AddQuestionToEvaluation))]
        public IActionResult AddQuestionToEvaluation(QuestionEvaluationModel questionEvaluationModel)
        {
            _questionsEvaluationServices.InsertQuestionForEvaluation(questionEvaluationModel);
            return Ok("Question added to evaluation Successfully");
        }

        [HttpGet(nameof(GetAllQuestionForEvaluation))]
        public IActionResult GetAllQuestionForEvaluation(int id)
        {
            return Ok(_questionsEvaluationServices.GetAllQuestionsForEvaluation(id));
        }

        [HttpDelete(nameof(DeleteQuestionFormEvaluation))]
        public IActionResult DeleteQuestionFormEvaluation(int id)
        {
            _questionsEvaluationServices.RemoveQuestionFromEvaluation(id);
            return Ok("Question deleted Successfully");
        }
    }
}

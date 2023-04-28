using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsServices _questionsServices;

        public QuestionsController(IQuestionsServices questionsServices)
        {
            this._questionsServices = questionsServices;
        }

        [HttpPost(nameof(CreateQuestion))]
        public IActionResult CreateQuestion(string question)
        {
            var insertedQuestion = _questionsServices.CreateQuestion(question);
            return Ok(insertedQuestion);
        }

        [HttpGet(nameof(GetAllQuestion))]
        public IActionResult GetAllQuestion()
        {
            var questions = _questionsServices.GetAllQuestions();
            return Ok(questions);
        }
        [HttpPut (nameof(UpdateQuestion))]
        public IActionResult UpdateQuestion(QuestionModel question)
        {
            _questionsServices.UpdateQuestion(question);
            return Ok("Question updated Successfully");
        }
    }
}

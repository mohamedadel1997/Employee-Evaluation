using DomainLayer;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IQuestionsServices
    {
        List<QuestionModel> GetAllQuestions();
        QuestionModel CreateQuestion(string question);
        Questions FindQuestion(Questions question);
        void UpdateQuestion(QuestionModel question);
    }
}

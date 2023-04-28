using DomainLayer;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IQuestionsEvaluationServices
    {
        List<QuestionsForEvaluationModel> GetAllQuestionsForEvaluation(int evaluationId);
        void InsertQuestionForEvaluation(QuestionEvaluationModel questionEvaluation);        
        void RemoveQuestionFromEvaluation(int id);
    }
}

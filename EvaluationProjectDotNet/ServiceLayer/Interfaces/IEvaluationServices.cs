using DomainLayer;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IEvaluationServices
    {
        List<EvaluationModel> GetAllEvaluations();
        List<EvaluationModel> GetAllEvaluationsForEmployee(Evaluation evaluation);
        EvaluationModel CreateEvaluation(EvaluationModel evaluation);
        Evaluation FindEvaluation(Evaluation evaluation);
        EvaluationModel UpdateEvaluation(EvaluationModel evaluation);

    }
}

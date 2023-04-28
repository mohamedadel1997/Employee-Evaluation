using AutoMapper;
using DomainLayer;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeModel>()
                .ReverseMap();

            CreateMap<Questions, QuestionModel>()
                .ReverseMap();

            CreateMap<Evaluation, EvaluationModel>()
                .ReverseMap();

            CreateMap<QuestionsEvaluation, QuestionEvaluationModel>()
                .ReverseMap();

            CreateMap<EmployeeEvaluation, EmployeeEvaluationsModel>()
                .ReverseMap();

            CreateMap<EmployeeEvaluationAnswer, EmployeeAnswerModel>()
                .ReverseMap();
            
        }
    }
}

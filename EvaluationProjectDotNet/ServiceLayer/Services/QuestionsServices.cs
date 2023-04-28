using AutoMapper;
using DomainLayer;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class QuestionsServices : IQuestionsServices
    {
        private readonly IRepository<Questions> _questionsRepository;
        private readonly IMapper _mapper;

        public QuestionsServices(IRepository<Questions> questionsRepository,IMapper mapper)
        {
            this._questionsRepository = questionsRepository;
            this._mapper = mapper;
        }
        public QuestionModel CreateQuestion(string question)
        {
            try
            {
                var ques = new QuestionModel() { Question = question };
                var model = _mapper.Map<QuestionModel,Questions>(ques);
                var insertedData = _questionsRepository.Insert(model);
                 return _mapper.Map<Questions, QuestionModel>(insertedData);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Questions FindQuestion(Questions question)
        {
            try
            {
                return _questionsRepository.Get(question.Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<QuestionModel> GetAllQuestions()
        {
            try
            {
                var questionList =  _questionsRepository.GetAll().ToList();
                return _mapper.Map<List<Questions>, List<QuestionModel>>(questionList);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateQuestion(QuestionModel question)
        {
            try
            {
                var model = _mapper.Map<QuestionModel,Questions>(question);
                _questionsRepository.Update(model);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

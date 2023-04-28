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
    public class EvaluationServices : IEvaluationServices
    {
        private readonly IRepository<Evaluation> _evaluationRepository;
        private readonly IMapper _mapper;
        private readonly IEmployeeEvaluationsServices _employeeEvaluationsServices;
        private readonly IEmployeeServices _employeeServices;

        public EvaluationServices(IRepository<Evaluation> evaluationRepository, IMapper mapper,
            IEmployeeEvaluationsServices employeeEvaluationsServices,IEmployeeServices employeeServices)
        {
            this._evaluationRepository = evaluationRepository;
            this._mapper = mapper;
            this._employeeEvaluationsServices = employeeEvaluationsServices;
            this._employeeServices = employeeServices;
        }
        private Evaluation InsertEvaluation(Evaluation evaluation)
        {
            try
            {
                if (evaluation != null)
                {                                       
                    return _evaluationRepository.Insert(evaluation);                    
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public EvaluationModel CreateEvaluation(EvaluationModel evaluation)
        {
            try
            {
                if (evaluation != null)
                {
                    evaluation.EvaluationStatus = EvaluationModel.EvaluationStatusEnum.Created.ToString();
                    Evaluation insertedEvaluation = _mapper.Map<EvaluationModel, Evaluation>(evaluation);
                    var insertedData = InsertEvaluation(insertedEvaluation);

                    assginEvaluationForEmployees(insertedData);
                    
                    return _mapper.Map<Evaluation, EvaluationModel>(insertedData);
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<EvaluationModel> GetAllEvaluationsForEmployee(Evaluation evaluation)
        {
            try
            {
                var model = _evaluationRepository.GetAll(e => e.Id == evaluation.Id, "EmployeeEvaluation").ToList();
                return _mapper.Map<List<Evaluation>, List<EvaluationModel>>(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Evaluation FindEvaluation(Evaluation evaluation)
        {
            try
            {
                if (evaluation != null)
                    return _evaluationRepository.Get(evaluation.Id, "Department");

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<EvaluationModel> GetAllEvaluations()
        {
            try
            {
                var model = _evaluationRepository.GetAll(null, "Department").ToList();
                return _mapper.Map<List<Evaluation>, List<EvaluationModel>>(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EvaluationModel UpdateEvaluation(EvaluationModel evaluation)
        {
            try
            {
                if (evaluation != null)
                {
                    var evaluationData = _mapper.Map<EvaluationModel, Evaluation>(evaluation);
                    var updatedData = _evaluationRepository.Update(evaluationData);
                    return _mapper.Map<Evaluation,EvaluationModel>(updatedData);
                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void assginEvaluationForEmployees(Evaluation evaluation)
        {
            var employeeList = _employeeServices.GetAllEmployeesForDepartment(evaluation.DepartmentId);
            foreach (var item in employeeList)
            {
                var employeeEvaluation = new EmployeeEvaluationsModel() 
                {
                    EmployeeId=item.Id,
                    EvaluationId=evaluation.Id
                };
                _employeeEvaluationsServices.InsertEvaluationForEmployee(employeeEvaluation);
            }
            
        }
        

    }
}

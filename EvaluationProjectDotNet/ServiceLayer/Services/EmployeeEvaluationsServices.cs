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
    public class EmployeeEvaluationsServices : IEmployeeEvaluationsServices
    {
        private readonly IRepository<EmployeeEvaluation> _employeeEvaluationRepository;
        private readonly IMapper _mapper;

        public EmployeeEvaluationsServices(IRepository<EmployeeEvaluation> employeeEvaluationRepository, IMapper mapper)
        {
            this._employeeEvaluationRepository = employeeEvaluationRepository;
            this._mapper = mapper;
        }

        public List<EmployeeEvaluation> GetAllEmployeeEvaluationList()
        {
            try
            {
                return (_employeeEvaluationRepository.GetAll(null, "Evaluation,Employee.Department").ToList());

            }
            catch (Exception)
            {

                throw;
            }
        }

        public AllEmployeeForOneEvaluationModel GetAllEmployeeForOneEvaluation(int evaluationId)
        {
            try
            {
                if (evaluationId != null)
                {
                    var AllEmployeeForOneEvaluationList = _employeeEvaluationRepository
                       .GetAll(e => e.EvaluationId == evaluationId, "Evaluation,Employee").ToList();
                    if (AllEmployeeForOneEvaluationList.Count() > 0)
                    {

                        var EmployeeForEvaluationList = new List<EmployeeForEvaluationModel>();

                        foreach (var item in AllEmployeeForOneEvaluationList)
                        {
                            EmployeeForEvaluationModel employee = new EmployeeForEvaluationModel()
                            {
                                id = item.EmployeeId,
                                EmployeeName = item.Employee.EmployeeName,
                                EmployeeEmail = item.Employee.EmployeeEmail,
                                EmployeePhone = item.Employee.EmployeePhone,
                                EmployeeRole = item.Employee.EmployeeRole,
                                DepartmentId = item.Employee.DepartmentId,
                            };
                            EmployeeForEvaluationList.Add(employee);
                        }
                        var tmpevaluation = new EvaluationModel()
                        {
                            Id = AllEmployeeForOneEvaluationList[0].EvaluationId,
                            EvaluationName = AllEmployeeForOneEvaluationList[0].Evaluation.EvaluationName,
                            EvaluationStartDate = AllEmployeeForOneEvaluationList[0].Evaluation.EvaluationStartDate,
                            EvaluationCreationTime = AllEmployeeForOneEvaluationList[0].Evaluation.EvaluationCreationTime,
                            EvaluationEndTime = AllEmployeeForOneEvaluationList[0].Evaluation.EvaluationEndTime,
                            EvaluationStatus = AllEmployeeForOneEvaluationList[0].Evaluation.EvaluationStatus
                        };

                        var ResultList = new AllEmployeeForOneEvaluationModel()
                        {
                            EmployeeForEvaluationModel = EmployeeForEvaluationList,
                            EvaluationEntityModel = tmpevaluation
                        };
                        return ResultList;
                    }
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public AllEvaluationForOneEmployeeModel GetAllEvaluationForOneEmployee(int employeeId)
        {
            try
            {
                if (employeeId != 0)
                {
                    var AllEvaluationForOneEmployeeList = _employeeEvaluationRepository
                        .GetAll(e => e.EmployeeId == employeeId, "Evaluation,Employee").ToList();
                    if (AllEvaluationForOneEmployeeList.Count > 0)
                    {
                        var evaluationListModel = new List<EvaluationModel>();
                        foreach (var item in AllEvaluationForOneEmployeeList)
                        {
                            var evaluation = new EvaluationModel();

                            evaluation.Id = item.Evaluation.Id;
                            evaluation.EvaluationName = item.Evaluation.EvaluationName;
                            evaluation.EvaluationStartDate = item.Evaluation.EvaluationStartDate;
                            evaluation.EvaluationEndTime = item.Evaluation.EvaluationEndTime;
                            evaluation.EvaluationCreationTime = item.Evaluation.EvaluationCreationTime;
                            evaluation.EvaluationStatus = item.Evaluation.EvaluationStatus;
                            evaluation.DepartmentId = item.Evaluation.DepartmentId;
                            evaluationListModel.Add(evaluation);
                        }

                        var resultList = new AllEvaluationForOneEmployeeModel();
                        resultList.evaluationModels = evaluationListModel;
                        resultList.employeeId = AllEvaluationForOneEmployeeList[0].EmployeeId;
                        resultList.employeeName = AllEvaluationForOneEmployeeList[0].Employee.EmployeeName;
                        resultList.employeeEmail = AllEvaluationForOneEmployeeList[0].Employee.EmployeeEmail;
                        resultList.employeeRole = AllEvaluationForOneEmployeeList[0].Employee.EmployeeRole;

                        return resultList;
                    }
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void InsertEvaluationForEmployee(EmployeeEvaluationsModel employeeEvaluation)
        {
            try
            {
                if (employeeEvaluation != null)
                {

                    var mappedData = _mapper.Map<EmployeeEvaluationsModel, EmployeeEvaluation>(employeeEvaluation);
                    _employeeEvaluationRepository.Insert(mappedData);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateEvaluationForEmployee(EmployeeEvaluationsModel employeeEvaluation)
        {
            try
            {
                var updatedData = _mapper.Map<EmployeeEvaluationsModel, EmployeeEvaluation>(employeeEvaluation);
                _employeeEvaluationRepository.Update(updatedData);
            }
            catch (Exception)
            {

                throw;
            }
        }
       
    }
}

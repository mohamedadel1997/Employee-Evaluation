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
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeServices(IRepository<Employee> employeeRepository, IMapper mapper)
        {
            this._employeeRepository = employeeRepository;
            this._mapper = mapper;
        }
        public EmployeeModel FindEmployeeByEmail(string email, string password)
        {
            try
            {
                if (email != null && password != null)
                {
                    var returnedEmployee = _employeeRepository
                        .GetAll(e => e.EmployeeEmail == email && e.Password == password, "Department").ToList();
                    if (returnedEmployee.Count != 0)
                    {
                        var model = _mapper.Map<Employee, EmployeeModel>(returnedEmployee[0]);
                        return model;
                    }
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CreateEmployee(EmployeeModel employee)
        {
            try
            {
                if (employee != null)
                {
                    var returnedEmployee = _employeeRepository
                        .GetAll(e => e.EmployeeEmail == employee.EmployeeEmail, "Department").ToList();
                    if (returnedEmployee.Count == 0)
                    {
                        var model = _mapper.Map<EmployeeModel, Employee>(employee);
                        model.EmployeeRole = "user";
                        _employeeRepository.Insert(model);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                _employeeRepository.Update(employee);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll(null, "Department");
        }
        public List<Employee> GetAllEmployeesForDepartment(int id)
        {
            return _employeeRepository.GetAll(e => e.DepartmentId == id, "Department").ToList();
        }
    }
}

using DomainLayer;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IEmployeeServices
    {
        IQueryable<Employee> GetAllEmployees();
        List<Employee> GetAllEmployeesForDepartment(int id);
        void CreateEmployee(EmployeeModel employee);
        EmployeeModel FindEmployeeByEmail(string email,string password);
        void UpdateEmployee(Employee employee);
    }
}

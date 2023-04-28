using DomainLayer;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentServices(IRepository<Department> departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }
        public void CreateDepartment(Department department)
        {
            try
            {
            _departmentRepository.Insert(department);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Department FindDepartment(Department department)
        {
            try
            {
                return _departmentRepository.Get(department.Id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<Department> GetAllDepartments()
        {
            try
            {
                return _departmentRepository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateDepartment(Department department)
        {
            try
            {
                _departmentRepository.Update(department);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

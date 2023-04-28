using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IDepartmentServices
    {
        IQueryable<Department> GetAllDepartments();
        void CreateDepartment(Department department);
        Department FindDepartment(Department department);
        void UpdateDepartment(Department department);
    }
}

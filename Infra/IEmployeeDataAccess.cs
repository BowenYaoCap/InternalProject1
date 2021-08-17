using System.Collections.Generic;
using InternalProject1.Models;

namespace InternalProject1.Infra{
    public interface IEmployeeDataAccess{
        List<Employee> GetAllEmployees();
        void SaveEmployee(Employee emp);

        Employee GetEmployeeById(int id);

        void UpdateEmployee(Employee department);
        void DeleteEmployee(int id);
    }

}
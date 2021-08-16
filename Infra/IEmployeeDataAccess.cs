using System.Collections.Generic;
using InternalProject1.Models;

namespace InternalProject1.Infra{
    public interface IEmployeeDataAccess{
        List<Employee> GetAllEmployees();

    }
}
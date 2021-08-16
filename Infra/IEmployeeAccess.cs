using System.Collections.Generic;
using InternalProject1.Models;

namespace InternalProject1.Infra{
    public interface IEmployeeAccess{
        List<Employee> GetAllEmployees();
        void ExportFromExcel();
        Employee GetEmployeeByName();
    }
}
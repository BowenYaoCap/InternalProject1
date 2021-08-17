using System.Collections.Generic;
using System.Linq;
using InternalProject1.Models;
//Gets context from database to access data
namespace InternalProject1.Infra{
    public class EmployeeDataAccess: IEmployeeDataAccess{

        private readonly DataContext context;
        public EmployeeDataAccess(DataContext context){
            this.context = context;
        }
        public List<Employee> GetAllEmployees(){
            return context.Employees.ToList();
        }

        public void SaveEmployee(Employee emp){
            context.Employees.Add(emp);
            context.SaveChanges();
        }

    }
}
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
        public Employee GetEmployeeById(int id){
            return context.Employees.FirstOrDefault(emp => emp.Id == id);
        }
        public void SaveEmployee(Employee emp){
            context.Employees.Add(emp);
            context.SaveChanges();
        }

        public void UpdateEmployee(Employee department){
            var emp = context.Employees.Attach(department);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteEmployee(int id){
            var emp = context.Employees.FirstOrDefault(emp => emp.Id == id);
            if(emp != null){
                context.Employees.Remove(emp);
                context.SaveChanges();
            }
        }


    }
}
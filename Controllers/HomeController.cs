using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InternalProject1.Models;
using Microsoft.AspNetCore.Http;
using InternalProject1.Infra;
using System.IO;
using OfficeOpenXml;
using Ganss.Excel;

namespace InternalProject1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeDataAccess dataAccess;
        
        public HomeController(IEmployeeDataAccess da){
            dataAccess = da;
        }
        public async Task<IActionResult> Import(IFormFile file){
           if(file == null){
               return View();
           }
           try{
                var list = new List<Employee>(); 
                using (var stream = new MemoryStream()){
                    //Waits for a file to be sent to the stream. Or in other words uploaded to the webpage
                    await file.CopyToAsync(stream);
                    using(var package  = new ExcelPackage(stream)){
                        //package is now set to the ExcelPackage that was uploaded and we will start unpacking the first worksheet
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowcount = worksheet.Dimension.Rows;
                        //For loop iterates over the total number of rows within the file. Note: I believe it just iterates over used row but I am unsure.
                        //All the information is then added to an Employee list that was initilized above.
                        for(int row = 2; row <= rowcount; row++){
                            list.Add(new Employee{
                                Id = int.Parse(worksheet.Cells[row,1].Value.ToString().Trim()),
                                Name = worksheet.Cells[row,2].Value.ToString().Trim(),
                                Role = worksheet.Cells[row,3].Value.ToString().Trim(),
                                Email = worksheet.Cells[row,4].Value.ToString().Trim()
                            });
                        }
                    }
                }
                foreach(var stu in list){
                    Employee emp = new Employee{Name = stu.Name,Role = stu.Role,Email = stu.Email};
                    dataAccess.SaveEmployee(emp);
                    System.Console.WriteLine("Name:{0}\tRole:{1}\tEmail:{2}\tId:{3}",stu.Name,stu.Role,stu.Email,stu.Id);
                }
                //NOTE: This will be changed as it doesn't work. Will implement DB to fix later...
                return RedirectToAction("Index");
           }
           catch(Exception e){
               System.Console.WriteLine("ERROR: Exception {0} encountered. Make sure the file you posted exists.", e);
               return View();
           }
        }
        public IActionResult Export(){
            ExcelMapper map = new ExcelMapper();
            var Employees = new List<Employee>{
                new Employee{Name = "Me!", Role = "THIS GUY!", Email = "TEST@EMIAL>COM", Id = 1},
                new Employee{Name = "You", Role = "THAT GUY!", Email = "TEST@EMIAL>COM", Id = 2},
                new Employee{Name = "US", Role = "THESE GUYS!", Email = "TEST@EMIAL>COM", Id = 3}
            };
            var newFile = @"C:\Users\acater\Documents\EmployeeList.xlsx";
            map.Save(newFile,Employees,"Employee List",true);
            return RedirectToAction("Index");
        }
        public IActionResult Information(int Id){
            return View(dataAccess.GetEmployeeById(Id));
        }
        public IActionResult Index()
        {  
            return View(dataAccess.GetAllEmployees());
        }

        [HttpGet]
        public IActionResult GetAllEmployees(){
            var result = dataAccess.GetAllEmployees();
            return View(result);
        }

        public IActionResult GetEmployeeById(int id){
            var emp = dataAccess.GetEmployeeById(id);
            return View(emp);
        }

        //Need to have forms with "EmployeeName","EmployeeRole", and "EmployeeEmail" ID for update method
        [HttpPost]
        public IActionResult UpdateEmployee(IFormCollection form,int id){
            var empname = form["EmployeeName"].ToString();
            var emprole = form["EmployeeRole"].ToString();
            var empemail = form["EmployeeEmail"].ToString();
            var emp = dataAccess.GetEmployeeById(id);
            if(empname != null){
                emp.Name = empname;
            }
            if(emprole != null){
                emp.Role = emprole;
            }
            if(empemail != null){
                emp.Email = empemail;
            }
            dataAccess.UpdateEmployee(emp);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteEmployee(int id){
            dataAccess.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

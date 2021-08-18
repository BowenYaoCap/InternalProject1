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
using System.Net;

namespace InternalProject1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeDataAccess dataAccess;
        
        public HomeController(IEmployeeDataAccess da){
            dataAccess = da;
        }
        //This function requires a file to read uploaded from the view.
        //Theoretically this should work on an Azure env as well.
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
                                //Id = int.Parse(worksheet.Cells[row,1].Value.ToString().Trim()),
                                Name = worksheet.Cells[row,2].Value.ToString().Trim(),
                                Role = worksheet.Cells[row,3].Value.ToString().Trim(),
                                Email = worksheet.Cells[row,4].Value.ToString().Trim()
                            });
                        }
                    }
                }
                foreach(var stu in list){
                    //Adds each employee found from the excel file to dataAccess and saves it.
                    Employee emp = new Employee{Name = stu.Name,Role = stu.Role,Email = stu.Email};
                    dataAccess.SaveEmployee(emp);
                    //System.Console.WriteLine("Name:{0}\tRole:{1}\tEmail:{2}\tId:{3}",stu.Name,stu.Role,stu.Email,stu.Id);
                }
                return RedirectToAction("Index");
           }
           catch(Exception e){
               //Catch all for exceptions related to input and file extensions. Trying to make error popups but it works for now *shrug*
               System.Console.WriteLine("ERROR: Exception {0} encountered. Make sure the file you posted exists.", e);
               return View();
           }
        }
        public IActionResult Export(){
            try{
                //This section uses ExcelMapper to map a list of employees to an excel file and save it to the specified location
                ExcelMapper map = new ExcelMapper();
                var Employees = dataAccess.GetAllEmployees();
                //The line below saves EmployeeList.xlsx to the Internal Project folder in any given structure. This will work locally but not for Azure env
                var newFile = AppDomain.CurrentDomain.BaseDirectory+"..\\..\\..\\"+"EmployeeList.xlsx";
                System.Console.WriteLine(newFile);
                map.Save(newFile,Employees,"EmployeeList",true);

                //this section is commented out for now but may be useful when we push to an azure enviroment.
                // using(var client = new WebClient()){ 
                //     client.DownloadFile("http://localhost:5001/EmployeeList.xlsx",newFile);
                // } 
                return RedirectToAction("Index");
            }
            //Catches IO Errors that likely happen as a result of an impossible file path or the file being active.
            catch(IOException e){
                System.Console.WriteLine("Encountered IO Error {0}\nMake sure file is not being used when exporting!",e);
                return RedirectToAction("Index");
            }
            
        }
        public IActionResult Edit(int Id){
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

        //Need to have forms with "Name","Role", and "Email" ID for update method
        [HttpPost]
        public IActionResult UpdateEmployee(IFormCollection form,int id){
            var empname = form["Name"].ToString();
            var emprole = form["Role"].ToString();
            var empemail = form["Email"].ToString();
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
        public IActionResult Add(){
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(IFormCollection form){
            
            var empname = form["Name"].ToString();
            var emprole = form["Role"].ToString();
            var empemail = form["Email"].ToString();
        
            if(empname != null&&emprole != null&&empemail !=null){
                dataAccess.SaveEmployee(new Employee{Name = empname, Role = emprole, Email = empemail});
                return RedirectToAction("Index");
            }
            else{
                return View();
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

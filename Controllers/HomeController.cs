using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TESTFOLDER.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using OfficeOpenXml;

namespace TESTFOLDER.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Import(IFormFile file){
           //Checks to see if the file uploaded exists
           //TODO: Check if its an excel file
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
                                Name = worksheet.Cells[row,1].Value.ToString().Trim(),
                                Role = worksheet.Cells[row,2].Value.ToString().Trim(),
                                Email = worksheet.Cells[row,3].Value.ToString().Trim()
                            });
                        }
                    }
                }
                foreach(var stu in list){
                    //prints out all Employees in the list
                    System.Console.WriteLine("Name:{0}\tRole:{1}\tEmail:{2}",stu.Name,stu.Role,stu.Email);
                }
                //NOTE: This will be changed as it doesn't work. Will implement DB to fix later...
                return RedirectToAction("Index",list);
           }
           catch(Exception e){
               System.Console.WriteLine("ERROR: Exception {0} encountered. Make sure the file you posted exists.", e);
               return View();
           }
        }
        public IActionResult Index(List<Employee> list)
        {  
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using ExecuteAutoEmployee.Models;
using ExecuteAutoEmployee.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExecuteAutoEmployee.Controllers
{
    [Authorize(Roles = "Administrator,User")]
    public class EmployeeDetailsController : Controller
    {

        //Get the database
        EmployeeDb _employeeDb = new EmployeeDb();

        PFServiceClient.PFServiceClient pfCalc = new PFServiceClient.PFServiceClient();


        // GET: EmployeeDetails
        public ActionResult Index(string searchTerm = null)
        {
            var emp = _employeeDb.Employee.Where(x => searchTerm == null || x.Name.StartsWith(searchTerm));
            return View(emp);
        }

        public ActionResult EmployeePF(int id)
        {
            var employee = _employeeDb.Employee.Find(id);
            //Convert to Service Employee
            var emp = ConvertToServiceEmp(employee);

            var contrib = pfCalc.GetPfEmployeeContribSofar(emp);
            ViewBag.EmployeeContrib = contrib;

            return View(employee);
        }


        public ActionResult EmployeeBonus(int id)
        {
            var employee = _employeeDb.Employee.Where(x => x.Id == id).FirstOrDefault();

            //Convert to Service Employee
            var emp = ConvertToServiceEmp(employee);

            var contrib = pfCalc.GetPfEmployerContribSofar(emp);
            ViewBag.EmployerContrib = contrib;

            return View(employee);
        }

        public PFServiceClient.Employee ConvertToServiceEmp(Employee employee)
        {
            PFServiceClient.Employee emp = new PFServiceClient.Employee()
            {
                Name = employee.Name,
                Id = employee.Id,
                DurationWorked = employee.DurationWorked,
                Salary = employee.Salary
            };

            return emp;
        }


    }
}

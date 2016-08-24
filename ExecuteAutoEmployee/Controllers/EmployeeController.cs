using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExecuteAutoEmployee.Models;
using System.Data.Entity;

namespace ExecuteAutoEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        //Get the database
        EmployeeDb _employeeDb = new EmployeeDb();

        // GET: Employee
        public ActionResult Index(string searchTerm = null)
        {
            var emp = _employeeDb.Employee.Where(x => searchTerm == null || x.Name.StartsWith(searchTerm));
            return View(emp);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(Employee employee)
        {
                if(ModelState.IsValid)
                {
                    _employeeDb.Employee.Add(employee);
                    _employeeDb.SaveChanges();
                    return RedirectToAction("Index", new { id = employee.Id });
                }

            return View(employee);
        }

        // GET: Employee/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            var employee = _employeeDb.Employee.FirstOrDefault(x => x.Id == id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(Employee employee)
        {
            if (TryUpdateModel(employee))
            {
                _employeeDb.Entry(employee).State = EntityState.Modified;
                _employeeDb.SaveChanges();
                return RedirectToAction("Index", new { id = employee.Id });
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            var employee = _employeeDb.Employee.FirstOrDefault(x => x.Id == id);
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id, Employee employee)
        {
            if (TryUpdateModel(employee))
            {
                _employeeDb.Entry(employee).State = EntityState.Deleted;
                _employeeDb.SaveChanges();
                return RedirectToAction("Index", new { id = employee.Id });
            }
            return View(employee);
        }
    }
}

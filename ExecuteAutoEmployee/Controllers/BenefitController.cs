using ExecuteAutoEmployee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExecuteAutoEmployee.Controllers
{
    public class BenefitController : Controller
    {

        //Get the database
        EmployeeDb _employeeDb = new EmployeeDb();

        // GET: Benefit
        public ActionResult Index()
        {
            return View();
        }

        // GET: Benefit/Details/5
        public ActionResult Details(int id)
        {
            var emp = _employeeDb.Employee.Find(id);
            return View(emp);
        }

        // GET: Benefit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Benefit/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Benefit/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Benefit/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Benefit/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Benefit/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

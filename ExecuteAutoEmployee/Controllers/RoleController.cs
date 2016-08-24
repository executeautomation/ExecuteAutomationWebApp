using ExecuteAutoEmployee.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExecuteAutoEmployee.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class RoleController : Controller
    {

        //Get the database
        EmployeeDb _employeeDb = new EmployeeDb();

        // GET: Role
        public ActionResult Index()
        {
            //Do not display admin user inturn :)
            var Users = _employeeDb.Users.Where(x => x.UserName != "admin").ToList();

            //Get all the Roles
            var list = _employeeDb.Roles.OrderBy(role => role.Name).ToList().Select(role => new SelectListItem { Value = role.Name.ToString(), Text = role.Name }).ToList();
            ViewBag.Roles = list;

            return View(Users);
        }

        // GET: Role/Details/5
        public ActionResult AssignRole(string userName, string roleName)
        {
            ApplicationUser user = _employeeDb.Users.Where(usr => usr.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_employeeDb));


            if (user != null)
            {
                userManager.AddToRoleAsync(user.Id, roleName);

                ViewBag.ResultMessage = "Role created successfully !";
            }
            else
            {
                ViewBag.ErrorMessage = "Sorry user is not available";
            }


            return RedirectToAction("Index");
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
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

        // GET: Role/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Role/Edit/5
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

        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Role/Delete/5
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

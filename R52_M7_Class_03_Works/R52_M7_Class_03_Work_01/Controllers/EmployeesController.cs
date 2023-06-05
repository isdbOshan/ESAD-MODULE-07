using R52_M7_Class_03_Work_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace R52_M7_Class_03_Work_01.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        EmployeeDbContext db = new EmployeeDbContext();
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.Departments = db.Departments.ToList();
            return View();
        }
        [HttpPost]  
        public ActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);
        }
    }
}
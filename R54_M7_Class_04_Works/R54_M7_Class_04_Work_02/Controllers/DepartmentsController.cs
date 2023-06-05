using R54_M7_Class_04_Work_02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace R54_M7_Class_04_Work_02.Controllers
{
    public class DepartmentsController : Controller
    {
        EmployeeDbContext db = new EmployeeDbContext();
        public ActionResult Index()
        {
            return View(db.Departments.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department d)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(d);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(d);
        }
        public ActionResult Edit(int id)
        {
            var dept = db.Departments.FirstOrDefault(d => d.DepartmentId == id);
            return View(dept);
        }
        [HttpPost]
        public ActionResult Edit(Department d)
        {
            if (ModelState.IsValid)
            {
                db.Entry(d).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(d);
        }
    }
}
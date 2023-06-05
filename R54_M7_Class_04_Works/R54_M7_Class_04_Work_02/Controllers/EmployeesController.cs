using R54_M7_Class_04_Work_02.Models;
using R54_M7_Class_04_Work_02.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace R54_M7_Class_04_Work_02.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeeDbContext db = new EmployeeDbContext();
        // GET: Employees
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
        public ActionResult Create(EmployeeInputModel emp)
        {
            if(ModelState.IsValid)
            {
                Employee data = new Employee { EmployeeName = emp.EmployeeName, JoinDate = emp.JoinDate, DepartmentId = emp.DepartmentId };
                string ext = Path.GetExtension(emp.Picture.FileName);
                string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                string savePath = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                emp.Picture.SaveAs(savePath);
                data.Picture = fileName;
                db.Employees.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = db.Departments.ToList();
            return View(emp);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Departments = db.Departments.ToList();
            var emp = db.Employees.FirstOrDefault(x => x.EmployeeId == id);
            ViewBag.Picture = emp.Picture;
            return View(new EmployeeEditModel
            {
                EmployeeId= emp.EmployeeId,
                EmployeeName = emp.EmployeeName,
                JoinDate = emp.JoinDate,
                DepartmentId = emp.DepartmentId
               
            });
        }
        [HttpPost]
        public ActionResult Edit(EmployeeEditModel emp)
        {
            Employee data = db.Employees.First(x=> x.EmployeeId == emp.EmployeeId);
            if (ModelState.IsValid)
            {
                data.EmployeeName = emp.EmployeeName;
                data.JoinDate = emp.JoinDate;
                data.DepartmentId   = emp.DepartmentId;
                if(emp.Picture != null)
                {
                    string ext = Path.GetExtension(emp.Picture.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                    string savePath = Path.Combine(Server.MapPath("~/Uploads"), fileName);
                    emp.Picture.SaveAs(savePath);
                    data.Picture = fileName;
                   

                }

                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = db.Departments.ToList();
            ViewBag.Picture = data.Picture;
            return View(emp);
        }
    }
}
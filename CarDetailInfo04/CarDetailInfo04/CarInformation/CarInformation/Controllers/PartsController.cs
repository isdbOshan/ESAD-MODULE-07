using CarInformation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInformation.Controllers
{
    public class PartsController : Controller
    {
        DatabaseCarInfoContext db = new DatabaseCarInfoContext();
        public ActionResult Index()
        {
            return View(db.Car_Parts.Include(x => x.Car).ToList());
        }
        public ActionResult Create()
        {
            ViewBag.Candidates = db.Cars.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Car_Parts model)
        {
            if (ModelState.IsValid)
            {
                db.Car_Parts.Add(model);
                db.SaveChanges();
                return PartialView("_SuccessPartial");
            }
            return PartialView("_FailPartial");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Candidates = db.Cars.ToList();
            return View(db.Car_Parts.First(x => x.PartId == id));
        }
        [HttpPost]
        public ActionResult Edit(Car_Parts model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return PartialView("_SuccessPartial");
            }
            return PartialView("_FailPartial");
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var data = new Car_Parts { PartId = id };
            db.Entry(data).State = EntityState.Deleted;
            db.SaveChanges();
            return Json(new { id = id });
        }
    }
}
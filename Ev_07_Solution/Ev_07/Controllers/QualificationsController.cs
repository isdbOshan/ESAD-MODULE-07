using Ev_07.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace Ev_07.Controllers
{
    public class QualificationsController : Controller
    {
        EvDbContext db = new EvDbContext();
        // GET: Qualifications
        public ActionResult Index()
        {
            return View(db.Qualifications.Include(x=> x.Candidate).ToList());
        }
        public ActionResult Create() 
        {
            ViewBag.Candidates = db.Candidates.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Qualification model) 
        {
            if(ModelState.IsValid)
            {
                db.Qualifications.Add(model);
                db.SaveChanges();
                return PartialView("_SuccessPartial");
            }
            return PartialView("_FailPartial");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Candidates = db.Candidates.ToList();
            return View(db.Qualifications.First(x=> x.QualificationId == id));
        }
        [HttpPost]
        public ActionResult Edit(Qualification model)
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
            var data = new Qualification { QualificationId = id };
            db.Entry(data).State = EntityState.Deleted;
            db.SaveChanges();
            return Json(new { id=id});
        }
    }
}
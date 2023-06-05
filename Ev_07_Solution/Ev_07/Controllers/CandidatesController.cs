using Ev_07.Models;
using Ev_07.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Ev_07.Controllers
{
    public class CandidatesController : Controller
    {
        EvDbContext db = new EvDbContext();
        // GET: Candidates
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult CandidateList()
        {
            return PartialView("_CandidatePartial", db.Candidates.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public PartialViewResult Create(CandidateViewModel data)
        {
            if (ModelState.IsValid)
            {
                var c = new Candidate
                {
                    CandidateName = data.CandidateName,
                    BirthDate = data.BirthDate,
                    AppliedFor = data.AppliedFor,
                    ExpectedSalary = data.ExpectedSalary,
                    WorkFromHome = data.WorkFromHome
                };
                if (data.Picture.ContentLength > 0)
                {
                    string ext = Path.GetExtension(data.Picture.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                    string savePath = Path.Combine(Server.MapPath("~/Pictures"), fileName);
                    data.Picture.SaveAs(savePath);
                    c.Picture = fileName;
                }
                db.Candidates.Add(c);
                db.SaveChanges();
                return PartialView("_SuccessPartial");
            }
            return PartialView("_FailPartial");
        }
        public ActionResult Edit(int id)
        {
            var data = db.Candidates.FirstOrDefault(c=> c.CandidateId== id);
            if (data == null) return new HttpNotFoundResult();
            ViewBag.CurrentPicture = data.Picture;
            return View(new CandidateEditModel
            {
                CandidateId = id,
                CandidateName = data.CandidateName,
                BirthDate = data.BirthDate,
                AppliedFor = data.AppliedFor,
                ExpectedSalary = data.ExpectedSalary,
                WorkFromHome = data.WorkFromHome.HasValue ? data.WorkFromHome.Value :false
            });
        }
        [HttpPost]
        public PartialViewResult Edit(CandidateEditModel data)
        {
            var c = db.Candidates.FirstOrDefault(x => x.CandidateId == data.CandidateId);
            if (c == null)  return PartialView("_FailPartial");
            if (ModelState.IsValid)
            { c.CandidateName = data.CandidateName;
                c.BirthDate = data.BirthDate;
                c.AppliedFor = data.AppliedFor;
                c.ExpectedSalary= data.ExpectedSalary;
                c.WorkFromHome  =  data?.WorkFromHome;
                
                if (data.Picture!= null)
                {
                    string ext = Path.GetExtension(data.Picture.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                    string savePath = Path.Combine(Server.MapPath("~/Pictures"), fileName);
                    data.Picture.SaveAs(savePath);
                    c.Picture = fileName;
                }
               
                db.SaveChanges();
                return PartialView("_SuccessPartial");
            }
            return PartialView("_FailPartial");
        }
        [HttpPost]
        public JsonResult Delete (int id)
        {
            if(db.Qualifications.Any(x=> x.CandidateId == id))
            {
                return Json(new { success = false, id = 0 });
            }
            else
            {
                var c = new Candidate { CandidateId= id };
                db.Entry(c).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return Json(new { success = true, id = id });
            }
        }
        [Route("Custom/Master")]
        public ActionResult MasterDetailInsert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateMaster(CandidateViewModel data)
        {
            if (ModelState.IsValid)
            {
                Candidate c = new Candidate
                {
                    CandidateName = data.CandidateName,
                    WorkFromHome = data.WorkFromHome,
                    BirthDate = data.BirthDate,
                    ExpectedSalary = data.ExpectedSalary,
                    AppliedFor = data.AppliedFor
                };
                if (data.Picture.ContentLength > 0)
                {
                    string ext = Path.GetExtension(data.Picture.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                    string savePath = Path.Combine(Server.MapPath("~/Pictures"), fileName);
                    data.Picture.SaveAs(savePath);
                    c.Picture = fileName;
                }
                db.Candidates.Add(c);
                db.SaveChanges();
                return Json(c);
            }
            return Json(data);
        }
        [HttpPost]
        public ActionResult AddQualifications(int id, Qualification[] data)
        {
            var c = db.Candidates.FirstOrDefault(x => x.CandidateId == id);
            if (c == null) return new HttpNotFoundResult();
            foreach (var q in data)
            {
                c.Qualifications.Add(q);
            }
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
}
using R52_Ex_07_Mid.Models;
using R52_Ex_07_Mid.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace R52_Ex_07_Mid.Controllers
{
    public class CandidatesController : Controller
    {
        CandidateDbContext db = new CandidateDbContext();
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
            if(ModelState.IsValid)
            {
                var c = new Candidate
                {
                    CandidateName = data.CandidateName,
                    BirthDate = data.BirthDate,
                    AppliedFor = data.AppliedFor,
                    ExpectedSalary = data.ExpectedSalary,
                    WorkFromHome = data.WorkFromHome
                };
                if(data.Picture.ContentLength> 0)
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
    }
}
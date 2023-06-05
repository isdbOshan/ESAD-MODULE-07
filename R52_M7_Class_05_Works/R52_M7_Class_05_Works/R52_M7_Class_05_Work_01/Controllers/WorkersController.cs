using R52_M7_Class_05_Work_01.Models;
using R52_M7_Class_05_Work_01.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X.PagedList;

namespace R52_M7_Class_05_Work_01.Controllers
{
    public class WorkersController : Controller
    {
        WorkerDbContext db = new WorkerDbContext();
        // GET: Workers
        public ActionResult Index(int page=1)
        {
            int totalPages = (int)Math.Ceiling((double)db.Workers.Count() / 5);
            ViewBag.TotalPages = totalPages;
            ViewBag.Current = page;
            var data = db.Workers
                .Select(w => new WorkerViewModel
                {
                    Id = w.Id,
                    Name = w.Name,
                    PayRate = w.PayRate,
                    StartDate = w.StartDate,
                    EndDate = w.EndDate
                })
                .OrderBy(x => x.Id)
                .Skip((page - 1) * 5)
                .Take(5);
            return View(data);
        }
        public ActionResult IndexXPagedList(int page=1)
        {
            ViewBag.Page = page;
            var data = db.Workers
               .Select(w => new WorkerViewModel
               {
                   Id = w.Id,
                   Name = w.Name,
                   PayRate = w.PayRate,
                   StartDate = w.StartDate,
                   EndDate = w.EndDate
               })
               .OrderBy(x=> x.Id)
               .ToPagedList(page, 5);
            return View(data);
        }
    }
}
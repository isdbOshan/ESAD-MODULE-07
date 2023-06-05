using R52_M7_Class_06_Work_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace R52_M7_Class_06_Work_01.Controllers
{
    public class ArticlesController : Controller
    {
        ArticleDbContext db = new ArticleDbContext();
        // GET: Articles
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Articles(int page=1)
        {
            Thread.Sleep(3000);
            ViewBag.Current = page;
            ViewBag.PageCount = (int)Math.Ceiling((double)db.Articles.Count() / 5);
            return PartialView("_ArticlesPartial", db.Articles.OrderBy(x=> x.Id).Skip((page-1)*5).Take(5).ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public PartialViewResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return PartialView("_SuccessPartial");
            }
            return PartialView("_FailPartial");
        }
        public PartialViewResult CreateForm()
        {
            return PartialView("_CreatePartial");
        }
    }
}
using R52_M7_Class_07_Work_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace R52_M7_Class_07_Work_01.Controllers
{
    public class BooksController : Controller
    {
        BooksDbContext db = new BooksDbContext();
        // GET: Books
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create(Book b)
        {
            if(ModelState.IsValid)
            {
                db.Books.Add(b);
                db.SaveChanges();
                return Json(new { success = true, message = "Data saved successfully" });
            }
            return Json(new { success = false, message = "Failed to save data" });
        }
    }
}
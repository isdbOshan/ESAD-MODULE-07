using R52_M7_Class_02_Work_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace R52_M7_Class_02_Work_01.Controllers
{
    public class ProductsController : Controller
    {
        ProductDbContext db = new ProductDbContext();
        // GET: Products
        public ActionResult Index()
        {
            var data = db.Products.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if(ModelState.IsValid)
            {
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }
    }
}
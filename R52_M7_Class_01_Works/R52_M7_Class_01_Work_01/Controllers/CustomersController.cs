using R52_M7_Class_01_Work_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace R52_M7_Class_01_Work_01.Controllers
{
    public class CustomersController : Controller
    {
        NorthwindDbContext db = new NorthwindDbContext();
        // GET: Customers
        public ActionResult Index()
        {
            var data = db.Customers.OrderBy(x=> x.CompanyName).ToList();
            return View(data);
        }
    }
}
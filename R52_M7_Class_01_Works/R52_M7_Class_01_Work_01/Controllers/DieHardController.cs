using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace R52_M7_Class_01_Work_01.Controllers
{
    public class DieHardController : Controller
    {
        // GET: DieHard
        public ActionResult Index()
        {
            return View("DieIndex");
        }
    }
}
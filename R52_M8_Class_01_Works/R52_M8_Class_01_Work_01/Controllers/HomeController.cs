﻿using Microsoft.AspNetCore.Mvc;

namespace R52_M8_Class_01_Work_01.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

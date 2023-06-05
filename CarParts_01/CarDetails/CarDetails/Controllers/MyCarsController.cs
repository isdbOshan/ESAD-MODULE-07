using CarDetails.Models;
using CarDetails.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDetails.Controllers
{
    public class MyCarsController : Controller
    {
    DBCarPartsEntities db = new DBCarPartsEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult CarList()
        {
            return PartialView("_PartialMyCarModel", db.Cars.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        public PartialViewResult Create(CarViewModel data)
        {
            if (ModelState.IsValid)
            {
                var c = new Car()
                {
                    Model = data.Model,
                    Make = data.Make,
                    Color = data.Color,
                    Price = data.Price,
                    Availabel = data.Availabel
                };
                if (data.Picture.ContentLength > 0)
                {
                    string ext = Path.GetExtension(data.Picture.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                    string savePath = Path.Combine(Server.MapPath("~/Pictures"), fileName);
                    data.Picture.SaveAs(savePath);
                    c.Picture = fileName;
                }
                db.Cars.Add(c);
                db.SaveChanges();
                return PartialView();
            }
            return PartialView();
        }
    }
}
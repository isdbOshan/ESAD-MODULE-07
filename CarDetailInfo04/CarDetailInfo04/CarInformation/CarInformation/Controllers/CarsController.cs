using CarInformation.Models;
using CarInformation.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInformation.Controllers
{
    public class CarsController : Controller
    {
        DatabaseCarInfoContext db = new DatabaseCarInfoContext();
        // GET: Cars
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult CarList()
        {
            return PartialView("_CarPartialData", db.Cars.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public PartialViewResult Create(CarViewModel data)
        {
            if (ModelState.IsValid)
            {
                var c = new Car
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
                return PartialView("_SuccessPartial");
            }
            return PartialView("_FailPartial");
        }
        public ActionResult Edit(int id)
        {
            var data = db.Cars.FirstOrDefault(c => c.CarId == id);
            if (data == null) return new HttpNotFoundResult();
            ViewBag.CurrentPicture = data.Picture;
            return View(new CarEditModel
            {
                CarId = id,
                Model = data.Model,
                Make = data.Make,
                Color = data.Color,
                Price = data.Price,
                Availabel = data.Availabel.HasValue ? data.Availabel.Value : false
            });
        }
        [HttpPost]
        public PartialViewResult Edit(CarEditModel data)
        {
            var c = db.Cars.FirstOrDefault(x => x.CarId == data.CarId);
            if (c == null) return PartialView("_FailPartial");
            if (ModelState.IsValid)
            {
                c.Model = data.Model;
                c.Make = data.Make;
                c.Color = data.Color;
                c.Price = data.Price;
                c.Availabel = data?.Availabel;

                if (data.Picture != null)
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
        public ActionResult Delete(int id)
        {
            if (db.Car_Parts.Any(x => x.CarId == id))
            {
                return Json(new { success = false, id = 0 });
            }
            else
            {
                var c = new Car { CarId = id };
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
        public ActionResult CreateMaster(CarViewModel data)
        {
            if (ModelState.IsValid)
            {
                Car c = new Car
                {
                    Model = data.Model,
                    Availabel = data.Availabel,
                    Make = data.Make,
                    Price = data.Price,
                    Color = data.Color
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
                return Json(c);
            }
            return Json(data);
        }
        [HttpPost]
        public ActionResult AddQualifications(int id, Car_Parts[] data)
        {
            var c = db.Cars.FirstOrDefault(x => x.CarId == id);
            if (c == null) return new HttpNotFoundResult();
            foreach (var q in data)
            {
                c.Car_Parts.Add(q);
            }
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
}
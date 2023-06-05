using CarPartsInfoDetails0701.CarViewModel;
using CarPartsInfoDetails0701.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarPartsInfoDetails0701.Controllers
{
    public class CarDetailsController : Controller
    {
        SQLCarDetailsInfo_07_01Entities db = new SQLCarDetailsInfo_07_01Entities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult CarList()
        {
            return PartialView("_PartialCarDetailInfo", db.Cars.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public PartialViewResult Create(CarDetailViewModel data)
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
                    string savePath = Path.Combine(Server.MapPath("~/Updoads"), fileName);
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
            return View(new CarDetailEditModel
            {
                CarId = id,
                Model = data.Model,
                Make = data.Make,
                Color = data.Color,
                Price = data.Price,
                //Availabel = data.Availabel.HasValue ? data.Availabel.Value: false
                Availabel = data.Availabel
            });


        }
        [HttpPost]
        public PartialViewResult Edit(CarDetailEditModel data)
        {
            var c = db.Cars.FirstOrDefault(x => x.CarId == data.CarId);
            if (c == null) return PartialView();
            if (ModelState.IsValid)
            {
                c.Model = data.Model;
                c.Make = data.Make;
                c.Color = data.Color;
                c.Price = data.Price;
                c.Availabel = data.Availabel;
            }
            if (data.Picture != null)
            {
                string ext = Path.GetExtension(data.Picture);
                string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                string savePath = Path.Combine(Server.MapPath("~/Pictures"), fileName);
                data.Picture = savePath;
                c.Picture = fileName;
            }
            db.Cars.Add(c);
            db.SaveChanges();
            return PartialView();
        }

    }

}
    

    
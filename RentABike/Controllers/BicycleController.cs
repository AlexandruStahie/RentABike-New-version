using RentABike.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentABike.Controllers
{
    public class BicycleController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult AddBicycle()
        {
            Bicycle bicycle = new Bicycle();
            return View(bicycle);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult AddBicycle(Bicycle model, HttpPostedFileBase image1)
        {
            using(var context = new Entities())
            {
                if(image1 != null)
                {
                    model.BicycleImg = new byte[image1.ContentLength];
                    image1.InputStream.Read(model.BicycleImg, 0, image1.ContentLength);
                }
                context.Bicycle.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Bicycle");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult AdminShowBicycles()
        {
            List<Bicycle> bicycles = new List<Bicycle>();
            using(var context = new Entities())
            {
                bicycles = context.Bicycle.ToList();
            }

            return View(bicycles);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult UserShowBicycles()
        {
            
            List<Bicycle> bicycles = new List<Bicycle>();
            using(var context = new Entities())
            {
                bicycles = context.Bicycle.ToList();
            }
            if (bicycles != null)
            {
                return View(bicycles);
            }
            else
                return RedirectToAction("Index");
        }

        //[HttpPost]
        //public JsonResult AjaxImage(HttpPostedFileBase image1)
        //{
        //    Bicycle model = new Bicycle();

        //    model.BicycleImg = new byte[image1.ContentLength];
        //    image1.InputStream.Read(model.BicycleImg, 0, image1.ContentLength);
          
        //    return Json(model.BicycleImg);
        //}

        //[HttpGet]
        //public ActionResult Update(int id)
        //{
        //    Bicycle currentBicycle = new Bicycle();

        //    using(var context = new Entities())
        //    {
        //        currentBicycle = context.Bicycle.Find(id);
        //    }

        //     return View(currentBicycle);
        //    }

    }
}
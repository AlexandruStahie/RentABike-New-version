using RentABike.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentABike.Controllers
{
    [AllowAnonymous]
    public class HomeController : AppController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            Contact model = new Contact();           
            return View(model);
        }
        [HttpPost]
        public ActionResult Contact(Contact model)
        {
            using(var context = new Entities())
            {
                context.Contact.Add(model);
                context.SaveChanges();
            }      
            return RedirectToAction("Index");
        }

        public ActionResult AboutUs()
        {
            return RedirectToAction("Index");
        }

        public ActionResult GoogleMap()
        {
            return RedirectToAction("Index");
        }

    }
}
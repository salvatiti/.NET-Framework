
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroToHero.Data;

namespace ZeroToHero.Web.Controllers
{
    public class HomeController : Controller
    {
        IRestaurantData db;

        public HomeController()
        {
            db = new InMemoryRestaurantData(); //el constructor es para inicializar la interfaz IRestaurantData
        }

        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}
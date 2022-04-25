using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroToHero.Data.Models;

namespace ZeroToHero.Web.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;

        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }
        
        // GET: Restaurants
        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            //Si el id no existe, redireccionar a la view NotFound
            if (model == null)
            {
                return View("NotFound"); //Se crea una vista llamada NotFound para que cuando se busque un id que no existe te redirija a esa vista
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create() //Este Action da al usuario la forma de rellenar el formulario
        {
            return View();
        }

        [HttpPost] //Este Action se ejecuta cuando el usuario envía el formulario
        [ValidateAntiForgeryToken] //Para que no se pueda hacer una petición maliciosa
        public ActionResult Create(Restaurant restaurant) //Este Action es para recibir la información que el usuario ha introducido
        {
            if (ModelState.IsValid) //Si el modelo es válido
            {
                db.Add(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id }); //Redireccionar a la vista Details con el id del restaurante que se ha creado
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id) //Este Action da al usuario la forma de rellenar el formulario
        {
            var model = db.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant) //Este Action es para recibir la información que el usuario ha introducido
        {
            if (ModelState.IsValid) //Si el modelo es válido
            {
                db.Update(restaurant);
                TempData["Message"] = "You have saved the restaurant!"; // Se crea una variable de sesión para mostrar un mensaje de éxito que se puede usar en la app
                return RedirectToAction("Details", new { id = restaurant.Id }); //Redireccionar a la vista Details con el id del restaurante que se ha creado
            }
            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Delete(int id) //Este Action da al usuario la forma de rellenar el formulario
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form) //Se usa un parametro adicional para que no haya conflicto con el otro metodo
        {
            db.Delete(id);
            TempData["Message"] = "You have deleted the restaurant!";
            return RedirectToAction("Index");
        }
    }
}
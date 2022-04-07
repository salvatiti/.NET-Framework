using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using MVC.Models.TableViewModels;
using MVC.Models.ViewModels;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lista = null;
            using (MVCEntities db = new MVCEntities())
            {
                lista = (from d in db.user
                        where d.idState == 1
                        orderby d.email
                        select new UserTableViewModel
                        {
                            email = d.email,
                            id = d.id,
                            edad = d.edad
                        }).ToList();
            }

            return View(lista);
        }

        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {

            if (!ModelState.IsValid) //Devuelve si la validacion es true o false 
            {
                return View(model); //Si el modelo no es valido nos devuelve a la vista del formulario
            }

            using (var db= new MVCEntities()) 
            {
                user oUser = new user();
                oUser.idState = 1;
                oUser.email = model.email;
                oUser.password = model.password;
                oUser.edad = model.edad;

                db.user.Add(oUser);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var db = new MVCEntities())
            {
                var oUser = db.user.Find(id);
                model.edad = (int)oUser.edad; //se le pone el tipo porque cuando se creo se puso que podría ser Nullable
                model.email = oUser.email;
                model.id = oUser.id;

            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {

            if (!ModelState.IsValid) //Devuelve si la validacion es true o false 
            {
                return View(model); //Si el modelo no es valido nos devuelve a la vista del formulario
            }

            using (var db = new MVCEntities())
            {
                var oUser = db.user.Find(model.id);
                oUser.email = model.email;
                oUser.edad = model.edad;

                if (model.password!=null && model.password.Trim() != "")
                {
                    oUser.password = model.password;
                }

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Redirect(Url.Content("~/User/"));
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {

            using (var db = new MVCEntities())
            {
                var oUser = db.user.Find(id);
                oUser.idState = 3;

                db.Entry(oUser).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();

            }

            return Content("1");
        }


    }
}
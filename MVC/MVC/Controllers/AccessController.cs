using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (MVCEntities db = new MVCEntities())
                {
                    var list = db.user.Where(u => u.email == user && u.password == password && u.idState == 1);
                    /*from u in db.user
                    where u.email == user && u.password == password && u.idState ==1
                    select u;*/

                    if (list.Count() > 0)
                    {
                        //para obtener la sesion
                        Session["User"] = list.First(); //devuelve un user
                        return Content("1");

                    }
                    else
                    {
                        return Content("Usuario Invalido");
                    }
                }
            }
            catch (Exception e)
            {
                return Content("Hubo un error :( " + e.Message);
            }
        }

     
    }
}
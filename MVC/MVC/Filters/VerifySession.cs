using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Controllers;
using MVC.Models;

namespace MVC.Filters
{
    //Este filtro hay que darlo de alta en App_Start/FilterConfig
    public class VerifySession : ActionFilterAttribute //Hereda de esta clase para poder usar filtros
    {
        //sobrecargar este metodo de la clase ActionFilterAttribute
        //primero hace lo que yo le diga a la clase, y luego va a ejecutar el metodo OnActionExecuting
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //para obtener la sesion
            var oUser = (user)HttpContext.Current.Session["User"];

            //El usuario va a ser null al principio de ejecución, por lo que siempre nos va a redireccionar la primera vez a la pantalla de Log In
            if (oUser == null)
            {
                //Si la peticion no es AccessController(el controller principal), te lleva a Access/Index
                if(filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }
            }
            else
            {
                if (filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }
            //Cuando ya hay un usuario 
            base.OnActionExecuting(filterContext); //ejecuta el metodo en si (OnActionExecuting)
        }
    }
}
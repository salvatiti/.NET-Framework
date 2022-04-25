using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ZeroToHero.Web
{
    //Autofact es un contenedor que gestiona las dependencias entre clases
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            //para poder usar la clase, cada vez que se recibe un nuevo request se va a crear una instancia de la clase
            /* builder.RegisterType<InMemoryRestaurantData>()
                 .As<IRestaurantData>()
                 .SingleInstance();*/
            builder.RegisterType<SqlRestaurantData>()  
                 .As<IRestaurantData>()
                 .InstancePerRequest();
            builder.RegisterType<ZeroToHeroDbContext>().InstancePerRequest();

            //Se construye un Autofact container, registrando los controles
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
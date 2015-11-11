using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Gwn.Library.Controller.Controllers;
using Microsoft.Practices.Unity;

namespace Gwn.Library.Controller.Base
{
    public class HttpApplicationBase : HttpApplication
    {
        protected void ControllerFactoryInitialize()
        {
            AreaRegistration.RegisterAllAreas();

            var container = new UnityContainer();
            var factory = new UnityControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(factory);
            
            RegisterTypes(container);
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public virtual void RegisterTypes(IUnityContainer container)
        {
        }

        public virtual void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", 
                      action = "Index", 
                      id = UrlParameter.Optional } // Parameter defaults
            );
        }
    }
}
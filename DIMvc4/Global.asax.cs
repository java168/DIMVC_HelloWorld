using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Gwn.Library.Controller.Base;
using Gwn.Library.Controller.Interfaces;
using Microsoft.Practices.Unity;
using Gwn.Library.Controller.Implementation;
using Gwn.Library.Controller.Mocks;

namespace DIMvc4
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplicationBase
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            ControllerFactoryInitialize();
        }

        public override void RegisterTypes(IUnityContainer container)
        {
            // Add AppSettings as singleton
            container
                .RegisterType<ILog, Log1>("Log1")
                .RegisterType<ILog, Log2>("Log2")
                .RegisterType<ILog, Log3>("Log3")
                .RegisterType<IAppSettings, AppSettings>( // Singleton
                    new ContainerControlledLifetimeManager());
        }
    }
}
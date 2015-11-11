using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using Gwn.Library.Controller.Interfaces;
using Microsoft.Practices.Unity;

namespace Gwn.Library.Controller.Controllers
{
    /// <summary> Revised version of Brad Wilson's Factory 
    /// http://bradwilson.typepad.com/blog/2010/07/service-location-pt2-controllers.html
    /// </summary>
    public class UnityControllerFactory : IControllerFactory
    {
        private readonly IUnityContainer _container;
        private readonly IControllerFactory _defaultControllerFactory;

        public UnityControllerFactory(IUnityContainer container)
            : this(container, new DefaultControllerFactory())
        {
            // We'll call the following constructor passing in a DefaultControllerFactory. 
        }

        protected UnityControllerFactory
            (IUnityContainer container, IControllerFactory defaultFactory)
        {
            _container = container;
            _defaultControllerFactory = defaultFactory;
        }

        public IController CreateController(
            RequestContext requestContext, string controllerName)
        {
            // Was the requested controller registered?  If so we'll return it
            if (_container.IsRegistered<IController>(controllerName.ToLowerInvariant()))
                return _container.Resolve<IController>(controllerName.ToLowerInvariant());

            // If not being handled by a registered controller then use default controller
            var controller = 
                _defaultControllerFactory.CreateController(requestContext, controllerName);

            // If controller implements IBuildUp then propagate dependency injection by
            // using the IBuildup interface to build up controller using Unity
            if (controller is IBuildUp)
            {
                // Provide opportunity to initialize/register types
                ((IBuildUp)controller).RegisterTypes(_container);

                // Buildup controller
                ((IBuildUp)controller).BuildUp(_container);

                // Hook for developer to use after all dependencies are resolved
                ((IBuildUp)controller).Initialize();
            }
            return controller;
        }

        public void ReleaseController(IController controller)
        {
            if (controller is IDisposable)
                ((IDisposable)controller).Dispose();

            _container.Teardown(controller);
        }

        public SessionStateBehavior GetControllerSessionBehavior(
            RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }
    }
}
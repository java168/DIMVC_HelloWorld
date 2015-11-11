using Gwn.Library.Controller.Interfaces;
using Microsoft.Practices.Unity;

namespace Gwn.Library.Controller.Controllers
{
    public class GwnControllerBase : System.Web.Mvc.Controller, IBuildUp
    {
        [Dependency]
        public IUnityContainer Container { get; set; }


        /// <summary>
        /// Build up this class
        /// </summary>
        /// <param name="container"></param>
        public void BuildUp(IUnityContainer container)
        {
            container.BuildUp(GetType(), this);
        }


        /// <summary>
        /// All dependencies will be resolved when the
        /// UnityControllerFactory executes this method
        /// </summary>
        public virtual void Initialize()
        {

        }

        /// <summary>
        /// Provides a hook so that types can be registered prior
        /// to the BuildUp is called by the UnityControllerFactory
        /// </summary>
        /// <param name="container"></param>
        public virtual void RegisterTypes(IUnityContainer container)
        {

        }
    }
}
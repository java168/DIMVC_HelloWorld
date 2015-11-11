using System.Web.Mvc;
using Gwn.Library.Controller.Controllers;
using Gwn.Library.Controller.Interfaces;
using Gwn.Library.Controller.Mocks;
using Microsoft.Practices.Unity;

namespace DIMvc4.Controllers
{
    public class HomeController : GwnControllerBase
    {
        // Avoid magic strings
        private const string DefaultLog = LogConstants.DefaultLog;

        [Dependency]
        public IAppSettings AppSettings { get; set; }

        [Dependency]
        public LogFactory Factory { get; set; }

        [HttpGet]
        public ActionResult Index( string id )
        {

           
            // Get setting from configuration file for display
            var defaultLog = AppSettings.GetSetting(DefaultLog);

            // Get the concrete class of IFoo to use from factory
            var concreteLog = Factory.GetDefaultLog();

            // Get the foo message from the concrete class
            var LogMessage = concreteLog.GetLogMessage();

            ViewBag.Message = string.Format( "Using key [{0}]=[{1}]",  defaultLog, LogMessage);

            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection id)
        {

            var defaultLog = AppSettings.GetSetting(DefaultLog);

            string message = id["Message"];

            var concreteLog = Factory.GetDefaultLog();

            var writeMessage = concreteLog.WriteLogMessage(message);
            ViewBag.Log = string.Format("Using [{0}]", defaultLog);

            ViewBag.Message = string.Format( "Using [{0}]", writeMessage);




            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

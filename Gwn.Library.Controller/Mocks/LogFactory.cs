using Gwn.Library.Controller.Interfaces;
using Microsoft.Practices.Unity;

namespace Gwn.Library.Controller.Mocks
{
    public class LogFactory
    {
        private readonly IUnityContainer _provider;
        private readonly IAppSettings _settings;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogFactory"/> class.
        /// Using construction injection to set the implementation for
        /// IUnityContainer and IAppSettings
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="settings">The settings.</param>
        public LogFactory(IUnityContainer provider, IAppSettings settings)
        {
            _provider = provider;
            _settings = settings;
        }

        /// <summary>
        /// Gets the default Log based on Web.Config setting.
        /// </summary>
        /// <returns>ILog.</returns>
        public ILog GetDefaultLog()
        {
            // Get the "defaultLog" setting from the Web.Config file
            var configKey = _settings.GetSetting("DefaultLog");

            // Use it to get a named value (where name is implementation name)
            var returnValue = _provider.Resolve<ILog>(configKey);
            return returnValue;
        }
    }
}

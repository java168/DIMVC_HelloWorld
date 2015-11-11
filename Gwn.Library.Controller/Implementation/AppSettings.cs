using System.Linq;
using System.Web.Configuration;
using Gwn.Library.Controller.Interfaces;
using System.Collections.Specialized;

namespace Gwn.Library.Controller.Implementation
{
    public class AppSettings : IAppSettings
    {
        private readonly NameValueCollection _appSettings;
        public AppSettings()
        {
            _appSettings = WebConfigurationManager.AppSettings;
        }

        public string GetSetting(string key)
        {
            return _appSettings.AllKeys.Any(k => k == key) 
                ? _appSettings[key] 
                : "";
        }

        public void SetSetting(string key, string value)
        {
            if (_appSettings.AllKeys.Any(k => k == key))
                _appSettings[key] = value;      // Update
            else
                _appSettings.Add(key, value);   // Add
        }
    }
}

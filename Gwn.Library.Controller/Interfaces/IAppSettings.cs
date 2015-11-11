using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gwn.Library.Controller.Interfaces
{
    public interface IAppSettings
    {
        string GetSetting(string key);

        void SetSetting(string key, string value);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gwn.Library.Controller.Mocks
{
    public interface ILog
    {
        string GetLogMessage();
        string WriteLogMessage(string str);
    }

}

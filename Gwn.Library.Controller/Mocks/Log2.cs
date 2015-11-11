using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


namespace Gwn.Library.Controller.Mocks
{
    public class Log2 : ILog
    {
        public string GetLogMessage()
        {
            DateTime localDate = DateTime.Now;
            EventLog ev = new EventLog();
            ev.Log = "Application";
            var entry = (from EventLogEntry e in ev.Entries
                         where  e.TimeGenerated >= localDate.AddSeconds(-100)
                         orderby e.TimeGenerated
                         select e).FirstOrDefault();


            return "get Hello World Two! " + entry.Message;
        }

        public string WriteLogMessage(string str)
        {
            string sSource;
            string sLog;
            string sEvent;

            sSource = "Hello World EventLog";
            sLog = "Application";
            sEvent = "Hello World: " + str;

            try
            {
                if (!EventLog.SourceExists(sSource))
                    EventLog.CreateEventSource(sSource, sLog);

                EventLog.WriteEntry(sSource, sEvent);
            }
            catch
            {
                return "Error in writing message to Event log!";
            }

            return "write Hello World! " + str;
        }
    }

}

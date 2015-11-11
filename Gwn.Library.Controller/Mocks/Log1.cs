using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Gwn.Library.Controller.Mocks
{
    public class Log1 : ILog
    {

        string filename = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\" +  "log.txt";

        public string GetLogMessage()
        {

            StreamReader readLog = new StreamReader(filename);
            string message = File.Exists(filename) ? readLog.ReadToEnd()  : "Hello World!";

            readLog.Close();

            return message ;
        }

        public string WriteLogMessage(string strLog)
        {


                using (StreamWriter writeLog = new StreamWriter(filename, false)) 
                {
                    writeLog.WriteLine(strLog);
                    writeLog.Close();

                }


                return "write Hello World!  " + strLog;
        }
    }

}

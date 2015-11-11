using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gwn.Library.Controller;


namespace Gwn.Library.Controller.Mocks
{
    public class Log3 : ILog
    {


        public string GetLogMessage()
        {
            string  entry;
            using (var ctx = new LogEntities())
            {


                entry = (from m in ctx.Logs
                         where m.Application == "DIMvc4"
                         orderby m.Id descending
                        select m.Message).FirstOrDefault();
            }


            return "Hello World! " + entry;
        }

        public string WriteLogMessage(string str)
        {

           var ctx = new LogEntities();
         

                Int32 id = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;


                var l = ctx.Set<Log>();

                l.Add( new Log {  Id = id, Application = "DIMvc4", Message = str });

              
                ctx.SaveChanges();



            return "write Hello World! " + str;
        }

    }
}
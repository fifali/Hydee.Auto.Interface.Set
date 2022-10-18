using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Hydee.Auto.Interface.Set.DAO
{
    public static class TraceHelper
    {
        static TraceHelper()
        {
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "log");
            string path = AppDomain.CurrentDomain.BaseDirectory + "log\\";
            path += DateTime.Now.ToString("yyyy-MM-dd") + ".log";

            Trace.Listeners.Add(new TextWriterTraceListener(path));
            Trace.AutoFlush = true;

        }

        public static void WriteLine(string strMessage)
        {
            Trace.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " : " + strMessage);
        }
    }
}

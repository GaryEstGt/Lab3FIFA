using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Lab3FIFA
{
    public class ArchivoLog
    {
        static string filename;
        public static void EmpezarLog()
        {
            filename = "Log.txt";
        }
        public static void EscribirLinea(string Log)
        {
            StreamWriter w = File.AppendText(HttpContext.Current.Server.MapPath(path: @"~\Log\" + filename));
            w.WriteLine(Log);
            w.Close();
        }
    }
}
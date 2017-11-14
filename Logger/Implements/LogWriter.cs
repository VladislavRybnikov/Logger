using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Abstractions;
using System.IO;

namespace Logger.Implements
{
    public class LogWriter : ILogWriter
    {
        private object _lockObj = new object();
        private static string _directoryName = "Log";
        public IExceptionLogger ExLogger { get; set; }
        public LogWriter(Exception exception)
        {
            ExLogger = new ExceptionLogger(exception);
        }

        public void Write()
        {
            try
            {
                string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _directoryName);
                if (!Directory.Exists(pathToLog))
                {
                    Directory.CreateDirectory(pathToLog);
                }
                string fileName = Path.Combine(pathToLog, string.Format("{0}_{1:dd.MM.yyy}.log",
                    AppDomain.CurrentDomain.FriendlyName, DateTime.Now));
                string text = ExLogger.Message();
                lock (_lockObj)
                {
                    File.AppendAllText(fileName, text, Encoding.GetEncoding("Windows-1251"));
                }
            }
            catch{ }
        }
    }
}

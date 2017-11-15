using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Abstractions;

namespace Logger.Implements
{
    internal class ExceptionLogger : IExceptionLogger
    {
        private Exception _exception;
        public ExceptionLogger(Exception exception)
        {
            _exception = exception;
        }
        public string Message()
        {
            string message = string.Format("[{0}] [{1}.{2}()] [{3}]\r\n",
                DateTime.Now, _exception.TargetSite.DeclaringType, _exception.TargetSite.Name, _exception.Message);
            return message;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger.Implements;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Exception a = new Exception("qweqwreqwef");

            ExceptionLogger excLog = new ExceptionLogger(a);
            LogWriter log;
            
            try
            {
                Console.WriteLine(excLog.Message());
            }
            catch (Exception ex)
            {
                ExceptionLogger excLog1 = new ExceptionLogger(ex);
                log = new LogWriter(excLog1);
                log.Write();
                Console.WriteLine(excLog1.Message());
            }
            Console.ReadKey();
        }
    }
}

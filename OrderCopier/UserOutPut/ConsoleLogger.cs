using OrderCopier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCopier.UserOutPut
{
    public class ConsoleLogger : ILogger
    {
        public void Debug(string msg)
        {
            Log(msg);
        }

        public void Error(string msg)
        {
            Log(msg);
        }

        public void Info(string msg)
        {
            Log(msg);
        }

        private void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}

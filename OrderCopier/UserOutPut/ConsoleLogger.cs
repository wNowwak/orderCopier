using Newtonsoft.Json.Linq;
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
        public void VerifyResponse(string msg)
        {
            JObject jObject = JObject.Parse(msg);
            bool result = jObject["status"].ToString().Equals("SUCCESS") ? true : false;
            if (result)
            {
                Info($"Pomyślnie utworzono kopię zamóweinia, nowy numer zamówienia to: {jObject["order_id"].ToString()}");
            }
            else
            {
                Error("Błąd podczas tworzenia kopi zamówienia");
            }
        }

        private void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}

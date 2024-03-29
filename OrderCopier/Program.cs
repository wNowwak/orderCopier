﻿using OrderCopier.Ecommerce.BaseLinker;
using OrderCopier.Ecommerce.BaseLinker.Orders;
using OrderCopier.Interfaces;
using OrderCopier.UserOutPut;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrderCopier
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            
            
            string config;

            using (StreamReader sr = new StreamReader("config.xml"))
            {
                config = sr.ReadToEnd();
            }
            XDocument document = XDocument.Parse(config);
            var data = document.Element("config").Elements().ToList();
            string fromBL = data.ElementAt(0).Value.ToString();
            string toBL = data.ElementAt(1).Value.ToString();
            string orderId = data.ElementAt(2).Value.ToString();
            string destinationStatus = data.ElementAt(3).Value.ToString();
            string dataType = data.ElementAt(4).Value.ToString();
            string specificDate = data.ElementAt(5).Value.ToString();
            StandardUserConfig standardUserConfig = new StandardUserConfig(fromBL, toBL, orderId, destinationStatus,dataType,specificDate);


            

            IEcommerceConnector ecommerceConnector = new BaseLinkerConnector(logger);
            IOrderProvider provider = new BaseLinkerOrdersProvider(logger, ecommerceConnector, standardUserConfig);
            IOrderAdder orderAdder = new BaseLinkerOrderAdder(ecommerceConnector, logger, standardUserConfig);
            orderAdder.AddOrder(provider.GetOrders().FirstOrDefault());
            
        }
    }
}

using OrderCopier.Ecommerce.BaseLinker;
using OrderCopier.Ecommerce.BaseLinker.Orders;
using OrderCopier.Interfaces;
using OrderCopier.UserOutPut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCopier
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            string status_id = "18111";
            var dateAdd = (int)Math.Floor(DateTime.Now.Subtract(new DateTime(1970,1,1)).TotalSeconds);

            IEcommerceConnector ecommerceConnector = new BaseLinkerConnector(logger);
            IOrderProvider provider = new BaseLinkerOrdersProvider(logger,ecommerceConnector);
            IOrderAdder orderAdder = new BaseLinkerOrderAdder(ecommerceConnector, logger);
            orderAdder.AddOrder(provider.GetOrders().FirstOrDefault(), status_id, dateAdd.ToString());

        }
    }
}

using OrderCopier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCopier.Ecommerce.BaseLinker.Orders
{
    public class BaseLinkerOrderAdder : IOrderAdder
    {
        IEcommerceConnector _connector;
        ILogger _logger;
        public BaseLinkerOrderAdder(IEcommerceConnector connector, ILogger logger)
        {
            _connector = connector;
            _logger = logger;
        }
        public void AddOrder(IOrder order, string status_id, string dateAdd)
        {
            string json = prepareJson(order);

           var res =  _connector.GetResponse("2000587-2002861-A6LLBOP61EN6T7XD7W852FAGZMNGUA862YIOZLSJA2ZNZ3TCNFNW3IT5JBOYNL4Q", "addOrder", json);
        }

        private string prepareJson(IOrder order)
        {
            string result = "{";
            
            foreach (var item in order.GetType().GetProperties())
            {
                if (item.GetValue(order)!= null)
                {
                    result += $"\"{item.Name}\":\"{item.GetValue(order)}\",";
                }
            }
            result = result.Remove(result.LastIndexOf(','));
            result += "}";
            result = result.Replace("False", "1");
            return result;
        }
    }
}

using Newtonsoft.Json.Linq;
using OrderCopier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCopier.Ecommerce.BaseLinker.Orders
{
    public class BaseLinkerOrdersProvider : IOrderProvider
    {
        private ILogger _logger;
        private IEcommerceConnector _connector;

        public BaseLinkerOrdersProvider( ILogger logger, IEcommerceConnector connector)
        {
            _logger = logger;
            _connector = connector;
        }
        public IEnumerable<IOrder> GetOrders()
        {
            IEnumerable<IOrder> orderList = new List<IOrder>();
            IOrder order = new BaseLinkerOrder();
            var response = (JObject)_connector.GetResponse("2000587-2002861-A6LLBOP61EN6T7XD7W852FAGZMNGUA862YIOZLSJA2ZNZ3TCNFNW3IT5JBOYNL4Q", "getOrders", "{\"order_id\":23280582}");
            orderList = order.setUpOrder(response);
            return orderList;
        }

        
    }
}

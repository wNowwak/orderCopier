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
        private StandardUserConfig _standardUserConfig;
        public BaseLinkerOrdersProvider( ILogger logger, IEcommerceConnector connector, StandardUserConfig standardUserConfig)
        {
            _logger = logger;
            _connector = connector;
            _standardUserConfig = standardUserConfig;
        }
        public IEnumerable<IOrder> GetOrders( )
        {
            IEnumerable<IOrder> orderList = new List<IOrder>();
            IOrder order = new BaseLinkerOrder();
            var data = new Dictionary<string, string>();
            data["token"] = _standardUserConfig.fromBL;
            data["method"] = "getOrders";
            data["parameters"] = "{\"order_id\":"+_standardUserConfig.orderId+"}";
            var response = (JObject)_connector.GetResponse(data);
            orderList = order.setUpOrder(response);
            return orderList;
        }

        
    }
}

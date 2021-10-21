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
        StandardUserConfig _standardUserConfig;
        public BaseLinkerOrderAdder(IEcommerceConnector connector, ILogger logger, StandardUserConfig standardUserConfig)
        {
            _connector = connector;
            _logger = logger;
            _standardUserConfig = standardUserConfig;
        }
        public string AddOrder(IOrder order)
        {
            string json = prepareJson(order, _standardUserConfig.destinationStatus, _standardUserConfig.dateAdd);
            var data = new Dictionary<string, string>();
            data["token"] = _standardUserConfig.toBL;
            data["method"] = "addOrder";
            data["parameters"] = json;
            var res =  _connector.GetResponse(data).ToString();
            _logger.VerifyResponse(res);

            return res;
        }

        private string prepareJson(IOrder order, string status_id, string dateAdd)
        {
            string result = "{";
            
            foreach (var item in order.GetType().GetProperties())
            {
                if (item.GetValue(order)!= null)
                {
                    switch (item.Name)
                    {
                        case "order_status_id":
                            result += $"\"{item.Name}\":\"{status_id}\",";
                            break;
                        case "date_add":
                            result += $"\"{item.Name}\":\"{dateAdd}\",";
                            break;
                        default:
                            result += $"\"{item.Name}\":\"{item.GetValue(order)}\",";
                            break;
                    }
                    
                }
            }
            result = result.Remove(result.LastIndexOf(','));
            result += "}";
            
            return result;
        }
    }
}

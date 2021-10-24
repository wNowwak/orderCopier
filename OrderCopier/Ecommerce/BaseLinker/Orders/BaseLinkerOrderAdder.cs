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
            string dataAdd = _standardUserConfig.processDate(order.date_add);
            string json = prepareJson(order, _standardUserConfig.destinationStatus, dataAdd);
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
                        case "products":
                            break;
                        default:
                            result += $"\"{item.Name}\":\"{item.GetValue(order)}\",";
                            break;
                    }
                    
                }
            }
            result = result.Remove(result.LastIndexOf(','));
            result += addProductsToOrder(order.products);
            result += "}";
            
            return result;
        }

        private string addProductsToOrder(IEnumerable<IProduct> products)
        {
            var result = ",\"products\":[";
            foreach (var product in products)
            {
                result += "{";
                foreach (var item in product.GetType().GetProperties())
                {
                    
                    switch (item.PropertyType.Name.ToString().ToLower())
                    {
                        case "string":
                            result += $"\"{item.Name}\":\"{item.GetValue(product)}\",";
                            break;
                        default:
                            var propertyValue = item.GetValue(product).ToString();
                            propertyValue = propertyValue.Contains(',') ? propertyValue.Replace(',', '.') : propertyValue;
                            result += $"\"{item.Name}\":{propertyValue},";
                            
                            break;
                    }
                }
                result = result.Remove(result.LastIndexOf(','));
                result += "},";
            }
            result = result.Remove(result.LastIndexOf(','));
            result += "]";
            return result;
        }
    }
}


/*
 var property = orderProduct.GetType().GetProperties().Where(x => x.Name.Equals(item.Name)).FirstOrDefault();
                        if (property != null)
                        {
                            object propertyValue;
                            string orderFieldValue = item.Value.ToString();
                            switch (property.PropertyType.Name.ToLower())
                            {
                                case "string":
                                    propertyValue = orderFieldValue;
                                    break;
                                case "int32":
                                    if (int.TryParse(orderFieldValue, out int tempPropertyValueInt))
                                        propertyValue = tempPropertyValueInt;
                                    else
                                        continue;
                                    break;
                                case "decimal":
                                    if (Decimal.TryParse(orderFieldValue, out decimal tempPropertyValueDec))
                                        propertyValue = tempPropertyValueDec;
                                    else
                                        continue;
                                    break;
                                case "boolean":
                                    propertyValue = orderFieldValue.Equals("1") ? true : false;
                                    break;
                                default:
                                    Console.WriteLine("I don't know such type");
                                    propertyValue = null;
                                    break;
                            }
                            property.SetValue(orderProduct, propertyValue);
                        }
 
 
 */
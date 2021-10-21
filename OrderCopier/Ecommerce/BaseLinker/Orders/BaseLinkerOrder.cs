using Newtonsoft.Json.Linq;
using OrderCopier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCopier.Ecommerce.BaseLinker.Orders
{
    public class BaseLinkerOrder : IOrder
    {
        public string order_status_id { get ; set ; }
        public string date_add { get ; set ; }
        public string currency { get ; set ; }
        public string payment_method { get ; set ; }
        public string payment_method_cod { get ; set ; }
        public string paid { get ; set ; }
        public string user_comments { get ; set ; }
        public string admin_comments { get ; set ; }
        public string email { get ; set ; }
        public string phone { get ; set ; }
        public string user_login { get ; set ; }
        public string delivery_method { get ; set ; }
        public string delivery_price { get ; set ; }
        public IDeliveryAddress deliveryAddress { get ; set ; }

        public string delivery_fullname { get; set; }
        public string delivery_company { get; set; }
        public string delivery_address { get; set; }
        public string delivery_postcode { get; set; }
        public string delivery_city { get; set; }
        public string delivery_country_code { get; set; }
        public string delivery_point_id { get; set; }
        public string delivery_point_name { get; set; }
        public string delivery_point_address { get; set; }
        public string delivery_point_city { get; set; }
        public IInvoiceAddress invoiceAddress { get ; set ; }

        public string invoice_fullname { get; set; }
        public string invoice_company { get; set; }
        public string invoice_address { get; set; }
        public string invoice_postcode { get; set; }
        public string invoice_city { get; set; }
        public string invoice_country_code { get; set; }
        public string want_invoice { get; set; }
        public string invoice_nip { get; set; }


        public string extra_field_1 { get ; set ; }
        public string extra_field_2 { get ; set ; }
        public IEnumerable<IProduct> products { get ; set ; }


        public IEnumerable<IOrder> setUpOrder(JObject data)
        {

            List<IOrder> orderList = new List<IOrder>();

            var orders = data["orders"];
            foreach (var order in orders)
            {
                IOrder orderObj = new BaseLinkerOrder();
                foreach (JProperty orderField in order)
                {
                    var property = orderObj.GetType().GetProperties().Where(x => x.Name.Equals(orderField.Name)).FirstOrDefault();
                    if (property != null)
                    {
                        object propertyValue;
                        string orderFieldValue = orderField.Value.ToString();
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
                        property.SetValue(orderObj, propertyValue);
                    }

                }
                orderList.Add(orderObj);
            }




            return orderList;
        }
    }
}

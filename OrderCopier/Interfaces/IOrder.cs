using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCopier.Interfaces
{
    public interface IOrder
    {
       string order_status_id { get; set; }
       string date_add { get; set; }
       string currency { get; set; }
       string payment_method { get; set; }
       string payment_method_cod { get; set; }
       string paid { get; set; }
       string user_comments{ get; set; }
       string admin_comments { get; set; }
       string email { get; set; }
       string phone { get; set; }
       string user_login{ get; set; }
       string delivery_method { get; set; }
       string delivery_price { get; set; }
       IDeliveryAddress deliveryAddress{ get; set; }

        string delivery_fullname { get; set; }
        string delivery_company { get; set; }
        string delivery_address { get; set; }
        string delivery_postcode { get; set; }
        string delivery_city { get; set; }
        string delivery_country_code { get; set; }
        string delivery_point_id { get; set; }
        string delivery_point_name { get; set; }
        string delivery_point_address { get; set; }
        string delivery_point_city { get; set; }


        IInvoiceAddress  invoiceAddress { get; set; }

        string invoice_fullname { get; set; }
        string invoice_company { get; set; }
        string invoice_address { get; set; }
        string invoice_postcode { get; set; }
        string invoice_city { get; set; }
        string invoice_country_code { get; set; }
        string want_invoice { get; set; }
        string invoice_nip { get; set; }


        string extra_field_1 { get; set; }
       string extra_field_2 { get; set; }
       IEnumerable<IProduct> products { get; set; }


        IEnumerable<IOrder> setUpOrder(JObject data);

    }
}

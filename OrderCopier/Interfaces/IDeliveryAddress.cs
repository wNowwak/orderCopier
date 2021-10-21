using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCopier.Interfaces
{
    public interface IDeliveryAddress
    {
        string delivery_fullname { get; set; }
        string delivery_company  { get; set; }
        string delivery_address{ get; set; }
        string delivery_postcode { get; set; }
        string delivery_city { get; set; }
        string delivery_country_code { get; set; }
        string delivery_point_id { get; set; }
        string delivery_point_name { get; set; }
        string delivery_point_address { get; set; }
        string delivery_point_city { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCopier.Interfaces
{
    public interface IProduct
    {
        string storage { get; set; }
        int storage_id { get; set; }
        string product_id { get; set; }
        int variant_id { get; set; }
        string name { get; set; }
        string sku { get; set; }
        string ean { get; set; }
        string attributes { get; set; }
        decimal price_brutto { get; set; }
        decimal tax_rate { get; set; }
        int quantity { get; set; }
        decimal weight { get; set; }
    }
}

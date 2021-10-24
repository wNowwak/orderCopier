using OrderCopier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCopier.Ecommerce.BaseLinker.Products
{
    public class BaseLinkerProduct : IProduct
    {
        public string storage { get ; set ; }
        public int storage_id { get ; set ; }
        public string product_id { get ; set ; }
        public int variant_id { get ; set ; }
        public string name { get ; set ; }
        public string sku { get ; set ; }
        public string ean { get ; set ; }
        public decimal price_brutto { get ; set ; }
        public decimal tax_rate { get ; set ; }
        public int quantity { get ; set ; }
        public decimal weight { get ; set ; }
    }
}

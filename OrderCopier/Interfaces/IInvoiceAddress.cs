using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCopier.Interfaces
{
    public interface IInvoiceAddress
    {
        string invoice_fullname { get; set; }
        string invoice_company { get; set; }
        string invoice_address { get; set; }
        string invoice_postcode { get; set; }
        string invoice_city { get; set; }
        string invoice_country_code { get; set; }
        bool   want_invoice { get; set; }
        string invoice_nip { get; set; }
    }
}

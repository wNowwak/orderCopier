using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCopier
{
    public class StandardUserConfig
    {
       public string fromBL;
       public string toBL;
       public string orderId;
       public string destinationStatus;
        public string dateAdd;
        public StandardUserConfig(string from, string to, string Id, string Status, string date)
        {
            fromBL = from;
            toBL = to;
            orderId = Id;
            destinationStatus = Status;
            dateAdd = date;
        }
    }
}

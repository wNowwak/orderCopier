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
        private string _dataType;
        public string dateAdd;
        public StandardUserConfig(string from, string to, string Id, string Status, string dataTyp)
        {
            fromBL = from;
            toBL = to;
            orderId = Id;
            destinationStatus = Status;
            _dataType = dataTyp;
        }

        public string processDate(string datatime)
        {
            string data = string.Empty;
            switch (_dataType)
            {
                case "original":
                    data = datatime;
                    break;
                default:
                    var dateAdd = (int)Math.Floor(DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
                    data = dateAdd.ToString();
                    break;
                 
            }
            return data;
        }

        
    }
}

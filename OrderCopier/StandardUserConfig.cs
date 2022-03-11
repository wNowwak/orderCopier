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
        private string _specificData;
        public StandardUserConfig(string from, string to, string Id, string Status, string dataTyp, string specificData)
        {
            fromBL = from;
            toBL = to;
            orderId = Id;
            destinationStatus = Status;
            _dataType = dataTyp;
            _specificData = specificData;
        }

        public string processDate(string datatime)
        {
            string data = string.Empty;
            switch (_dataType)
            {
                case "original":
                    data = datatime;
                    break;
                case "specific":
                    var dataa = DateTime.Parse(_specificData);
                    var dataAdd = (int)Math.Floor(dataa.Subtract(new DateTime(1970, 1, 1)).TotalSeconds);
                    data = dataAdd.ToString();
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

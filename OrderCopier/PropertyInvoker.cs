using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCopier
{
    public class PropertyInvoker
    {
        private string _propertyName;

        public PropertyInvoker( string propertyName)
        {
            _propertyName = propertyName;
        }

        public object Invoke(object target)
        {
            string ala = "";
            return ala;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCopier.Interfaces
{
    public interface IOrderAdder
    {
        void AddOrder(IOrder order, string statusId, string dateAdd);
    }
}

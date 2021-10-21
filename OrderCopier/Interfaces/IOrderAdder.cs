using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCopier.Interfaces
{
    public interface IOrderAdder
    {
        string AddOrder(IOrder order);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderCopier.Interfaces
{
    public interface ILogger
    {
        void Info(string msg);
        void Debug(string msg);
        void Error(string msg);
        void VerifyResponse(string msg);
    }
}

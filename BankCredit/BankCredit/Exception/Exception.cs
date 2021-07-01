using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCredit.Exception
{
    class PercentException : ApplicationException
    {
        public override string Message { get; }
        public PercentException(string message) => Message = message;
    }
    class ClientException:ApplicationException
    {
        public override string Message { get; }
        public ClientException(string message) => Message = message;
    }
}

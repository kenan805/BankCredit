using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCredit.Bank_Credit_Operation
{
    class BaseId
    {
        public Guid Guid { get; set; }
        public BaseId()
        {
            Guid = Guid.NewGuid();
        }
        public override string ToString() => $"Id: {Guid}";
    }
}

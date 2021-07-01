using BankCredit.Bank_Credit_Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCredit
{
    class Operation : BaseId
    {
        public string Process_name { get; set; }
        public DateTime DateTime { get; set; }
        public Operation(string process_name, DateTime dateTime)
        {
            Process_name = process_name;
            DateTime = dateTime;
        }
    }
}
//Guid,process_name(meselen kredit emeliyyati),datetime +
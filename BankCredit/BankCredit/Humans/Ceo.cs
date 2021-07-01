using BankCredit.Exception;
using BankCredit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCredit
{
    class Ceo : Employee, IOrganize, IMeeting, IControl
    {
        public Ceo(string name, string surname, int age, double salary, string position) : base(name, surname, age, salary, position)
        {
        }

        public void Control() => Console.WriteLine("Ceo control");
        public void MakeMeeting() => Console.WriteLine("Ceo make meeting");
        public void Organize() => Console.WriteLine("Ceo organize");
        public override string ToString() => $"------- Ceo info -------\n{base.ToString()}";

        public void DecreasePercentage(double percent, Credit[] credits)
        {
            foreach (var credit in credits)
            {
                if (percent > credit.Percent) throw new PercentException("Interest does not match!");
                credit.Percent -= percent;
            }
        }
    }
}
//Guid,name,surname,age,salary-> position +
//-->control(),Iorganize(),makeMeeting()+
//decreasePercentage(percent) +

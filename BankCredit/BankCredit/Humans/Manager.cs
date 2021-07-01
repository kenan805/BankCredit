using BankCredit.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCredit
{
    class Manager : Employee, IOrganize
    {
        public Manager(string name, string surname, int age, double salary, string position) : base(name, surname, age, salary, position)
        {
        }

        public void Organize() => Console.WriteLine("Manager organize");
        public override string ToString() => base.ToString();
        public double CalculateSalaries(Worker[] workers, Manager[] managers, Ceo ceo)
        {
            double SumSalaries = 0;
            foreach (var worker in workers)
                SumSalaries += worker.Salary;
            foreach (var manager in managers)
                SumSalaries += manager.Salary;
            SumSalaries += ceo.Salary;

            return SumSalaries;

        }

    }

}
//Guid,name,surname,age,salary -> position +
//Iorganize()+
//calculateSalaries() +
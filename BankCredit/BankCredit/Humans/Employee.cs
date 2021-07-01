using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCredit
{
    abstract class Employee : Human
    {
        public double Salary { get; set; }
        public string Position { get; set; }
        protected Employee(string name, string surname, int age, double salary, string position) : base(name, surname, age)
        {
            Salary = salary;
            Position = position;
        }

        public override string ToString() => $"{base.ToString()}\nSalary: {Salary}\nPosition: {Position}";
    }
}

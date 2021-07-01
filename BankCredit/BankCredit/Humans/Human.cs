using BankCredit.Bank_Credit_Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCredit
{
    abstract class Human : BaseId
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Human(string name, string surname, int age) : base()
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
        public override string ToString() => $"Guid: {Guid}\nName: {Name}\nSurname: {Surname}\nAge: {Age}";

    }
}
//Guid,name,surname,age,salary
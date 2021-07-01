using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCredit
{
    class Client : Human
    {
        public string Live_adress { get; set; }
        public string Work_adress { get; set; }
        public double Salary { get; set; }
        public Client(string name, string surname, int age, string live_adress, string work_adress, double salary) : base(name, surname, age)
        {
            Live_adress = live_adress;
            Work_adress = work_adress;
            Salary = salary;
        }

        public override string ToString() => $"{base.ToString()}\nLive adress: {Live_adress}\nWork adress: {Work_adress}\nSalary: {Salary}";

    }
}
//guid name, surname,age,live_adrress,work_adress,salary +
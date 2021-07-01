using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCredit
{
    class Worker : Employee
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Operation[] Operations { get; set; }
        public Worker(string name, string surname, int age, double salary, string position, DateTime startTime, DateTime endTime) : base(name, surname, age, salary, position)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public override string ToString() => $"{base.ToString()}\nStart time: {StartTime.ToShortTimeString()}\nEnd time: {EndTime.ToShortTimeString()}";
        public void AddOperation(in Operation newOperation)
        {
            int count = (Operations == null) ? 1 : Operations.Length + 1;
            Operation[] newOperations = new Operation[count];
            if (Operations != null) Array.Copy(Operations, newOperations, Operations.Length);
            newOperations[count - 1] = newOperation;
            Operations = newOperations;
        }
    }
}
//Guid,name,surname,age,salary -> position, startTime,endTime +
//Operations[],addOperation +

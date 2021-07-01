using BankCredit.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCredit
{
    class Bank
    {

        public string Name { get; set; }
        public double Budget { get; set; }
        public double Profit { get; set; }
        public Ceo Ceo { get; set; }
        public Worker[] Workers { get; set; }
        public Manager[] Managers { get; set; }
        public Credit[] Credits { get; set; }

        public Bank(string name, double budget, Ceo ceo, Worker[] workers, Manager[] managers, Credit[] credits)
        {
            Name = name;
            Budget = budget;
            Profit = CalculateProfit(credits);
            Ceo = ceo;
            Workers = workers;
            Managers = managers;
            Credits = credits;
        }
        public void ShowClientCredit(string name, string surname)
        {
            if (string.IsNullOrEmpty(surname))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            else if (string.IsNullOrEmpty(surname))
                throw new ArgumentException($"'{nameof(surname)}' cannot be null or empty.", nameof(surname));
            else if (Array.Exists(Credits, credit => credit.Client.Name == name && credit.Client.Surname == surname))
            {
                var client = Array.Find(Credits, credit => credit.Client.Name == name);
                Console.WriteLine($"{name} {surname} credit amount: {client.Amount}");
            }
            else throw new ClientException("Client not found!");
        }
        public void PayCredit(Client client, double money)
        {
            if (client is null) throw new ArgumentNullException(nameof(client));
            else if (money < 0) throw new ArgumentException(null, nameof(money));
            else if (Array.Exists(Credits, credit => credit.Client == client))
            {
                var findClient = Array.Find(Credits, credit => credit.Client == client);
                if (money > findClient.Amount)
                {
                    Console.WriteLine($"Qaliq pul: {money - findClient.Amount}");
                    findClient.Amount -= money;
                }
                else if (money == findClient.Amount)
                {
                    Console.WriteLine("Your debt is settled.");
                    findClient.Amount -= money;
                }
                else if (money < findClient.Payment)
                {
                    Console.WriteLine($"The money must be at least {findClient.Payment} AZN! You have to pay {findClient.Payment - money} AZN more");
                    findClient.Amount -= money;
                }
                findClient.Amount -= money;
            }
            else throw new ClientException("Client not found!");
        }
        public void ShowAllCredit()
        {
            Console.WriteLine("--------- All credit info ---------");
            foreach (var credit in Credits)
            {
                Console.WriteLine(credit);
                Console.WriteLine();
            }
        }
        public override string ToString()
        {
            return $"--------- Bank info ---------\n" +
                $"Name: {Name}\n" +
                $"Budget: {Budget} AZN\n" +
                $"Profit: {Profit} AZN\n";
        }
        public double CalculateProfit(Credit[] credits)
        {
            double allIncomingAmount = 0;
            double allAmount = 0;
            foreach (var credit in credits)
            {
                allAmount += credit.Amount;
                allIncomingAmount += credit.CalculatePercent();
            }
            return allIncomingAmount - allAmount;
        }
    }
}

//Name,budget,profit +
//ceo,worker[],manager[],client[] +
//showClientCredit(string fullname)+
//payCredit(Client,money) +
//showAllCredit +
//Calculate_profit() +
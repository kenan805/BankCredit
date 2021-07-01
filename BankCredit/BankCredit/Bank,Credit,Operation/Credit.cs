using BankCredit.Bank_Credit_Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCredit
{
    class Credit : BaseId
    {
        public Client Client { get; set; }
        public double Amount { get; set; }
        public double Percent { get; set; }
        public int Months { get; set; }
        public double Payment { get; set; }
        public Credit(Client client, double amount, double percent, int months) : base()
        {
            Client = client;
            Amount = amount;
            Percent = percent;
            Months = months;
            Payment = CalculatePayment();
        }
        public double CalculatePercent() => Amount * (100 + Percent) / 100;
        private double CalculatePayment()
        {
            int intPayment = (int)(CalculatePercent() / Months); // 458
            double longPayment = ((int)(((CalculatePercent() / Months) - intPayment) * 100)); // 0,33
            double payshort = longPayment / 100;
            return intPayment+payshort;
        }
        public override string ToString()
        {
            return $"Client name: {Client.Name}\n" +
                $"Client surname: {Client.Surname}\n" +
                $"Amount: {Amount}\n" +
                $"Percent: {Percent}\n" +
                $"Months: {Months}\n" +
                $"Payment: {Payment}";
        }
    }
}

//Guid,Client,amount,percent,months ,payment + 
//calculatePercent +

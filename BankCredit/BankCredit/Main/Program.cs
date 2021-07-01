using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCredit.Main
{
    class Program
    {
        public static void Main(string[] args)
        {
            BankCreditProcess();
        }

        private static void BankCreditProcess()
        {
            try
            {

                Ceo ceo = new("Akif", "Agayev", 32, 5500, "~~~~~");
                Client client1 = new("Revan", "Agayev", 30, "Xirdalan", "Ecemi", 1400);
                Client client2 = new("Gunay", "Ibrahimova", 45, "Xetai", "20 yanvar", 900);
                Client client3 = new("Ferrux", "Eliyev", 40, "Sumqayit", "Dernegul", 600);
                Client client4 = new("Qasim", "Qasimli", 26, "N.Nerimanov", "Genclik", 1600);

                Worker[] workers =
                {
                new Worker("Eli","Eliyev",24,1000,"~~~~",new DateTime().AddHours(8),new DateTime().AddHours(18)),
                new Worker("Alim","Qasimov",34,1200,"~~~~",new DateTime().AddHours(10),new DateTime().AddHours(20)),
                new Worker("Rasim","Abdullayev",28,1400,"~~~~",new DateTime().AddHours(9),new DateTime().AddHours(19)),
                new Worker("Nermin","Hesenova",45,900,"~~~~",new DateTime().AddHours(22),new DateTime().AddHours(7))
            };

                Operation[] operations =
                {
                new Operation("Credit process 1", DateTime.Now),
                new Operation("Credit process 2", DateTime.Now.AddDays(10)),
                new Operation("Credit process 3", DateTime.Now.AddMonths(2)),
                new Operation("Credit process 4", DateTime.Now.AddDays(22))
            };

                for (int i = 0; i < workers.Length; i++)
                    workers[i].AddOperation(operations[i]);


                Manager[] managers =
                {
                new Manager("Kenan","Idayatov",22,2200,"~~~~~"),
                new Manager("Tural","Novruzov",28,2300,"~~~~~"),
                new Manager("Nebi","Nebili",23,2400,"~~~~~"),
                new Manager("Emiraslan","Eliyev",24,2500,"~~~~~"),
            };

                Credit[] credits =
                {
                new Credit(client1,4000,10,12),
                new Credit(client2,2800,14,18),
                new Credit(client3,2500,10,12),
                new Credit(client4,10000,17.5,18)
            };

                /////////////////////////////////////////////////////////////////////////
                ///Bank info ve methods
                Bank bank = new("Kapital bank", 1000000, ceo, workers, managers, credits);
                Console.WriteLine(bank);
                Console.WriteLine(bank.Ceo);
                Console.WriteLine($"Profit: {bank.CalculateProfit(credits)}");
                bank.ShowAllCredit();
                bank.ShowClientCredit("Ferrux", "Eliyev");

                /////////////////////////////////////////////////////////////////////////
                ///Kredit odenisi
                Console.WriteLine($"Payment month: {bank.Credits[1].Payment}");
                Console.WriteLine($"Before: {bank.Credits[1].Amount}");
                bank.PayCredit(credits[1].Client, 177.45);
                Console.WriteLine($"After: {bank.Credits[1].Amount}");


                /////////////////////////////////////////////////////////////////////////
                ///Credit percent after before
                Console.WriteLine("---- Before ----");
                foreach (var credit in credits)
                    Console.Write($"{credit.Percent}  ");

                bank.Ceo.DecreasePercentage(2, credits);
                Console.WriteLine("\n---- After ----");
                foreach (var credit in credits)
                    Console.Write($"{credit.Percent}  ");

                /////////////////////////////////////////////////////////////////////////
                ///Her hansisa manager vasitesile butun iscilerin maasi
                Console.WriteLine($"All salaries: {managers[0].CalculateSalaries(workers, managers, ceo)} AZN");

                /////////////////////////////////////////////////////////////////////////
                ///Butun creditlerin faizleri
                foreach (var credit in bank.Credits)
                {
                    Console.WriteLine($"Without percent: {credit.Amount}   Percent: {credit.CalculatePercent()}");
                }

            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

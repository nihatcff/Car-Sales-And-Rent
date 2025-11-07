using System;
using System.Collections.Generic;

namespace CarSalesAndRent.Systems
{
    public class Bank
    {
        public double Balance { get; private set; }
        private List<string> history = new List<string>();

        public Bank(double balance)
        {
            Balance = balance;
        }

        public bool Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                history.Add($"-{amount} AZN");
                return true;
            }
            return false;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            history.Add($"+{amount} AZN ");
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n===== BANK MENYUSU =====");
                Console.WriteLine("1. Balansa bax");
                Console.WriteLine("2. Əməliyyatlar");
                Console.WriteLine("0. Geri");
                Console.Write("Seçim: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Cari balans: {Balance} AZN");
                        break;
                    case "2":
                        ShowHistory();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Yanlış seçim!");
                        break;
                }
            }
        }

        private void ShowHistory()
        {
            Console.WriteLine("\n--- Əməliyyat tarixçəsi ---");
            if (history.Count == 0)
            {
                Console.WriteLine("Qeyd yoxdur.");
                return;
            }

            foreach (var item in history)
            {
                Console.WriteLine(item);
            }
        }

        public double GetBalance()
        {
            return Balance;
        }

        public List<string> GetHistory()
        {
            return history;
        }
    }
}

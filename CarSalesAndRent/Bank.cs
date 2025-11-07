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
                history.Add($"-{amount} AZN (expense)");
                return true;
            }
            return false;
        }

        public void Deposit(double amount, string reason)
        {
            Balance += amount;
            history.Add($"+{amount} AZN ({reason})");
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n===== BANK MENU =====");
                Console.WriteLine("1. Show Balance");
                Console.WriteLine("2. Transaction History");
                Console.WriteLine("0. Back");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Current Balance: {Balance} AZN");
                        break;
                    case "2":
                        ShowHistory();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        private void ShowHistory()
        {
            Console.WriteLine("\n--- Transaction History ---");
            if (history.Count == 0)
            {
                Console.WriteLine("No records found.");
                return;
            }

            foreach (var item in history)
            {
                Console.WriteLine(item);
            }
        }
    }
}

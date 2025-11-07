using System;
using CarSalesAndRent.Systems;
using CarSalesAndRent.Models;

namespace CarSalesAndRent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank(50000);
            CarSaleSystem saleSystem = new CarSaleSystem(bank);
            RentSystem rentSystem = new RentSystem(bank);

            while (true)
            {
                Console.WriteLine("\n========= MAIN MENU =========");
                Console.WriteLine("1. Car Sale");
                Console.WriteLine("2. Rent a Car");
                Console.WriteLine("3. Bank");
                Console.WriteLine("0. Exit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        saleSystem.Menu();
                        break;
                    case "2":
                        rentSystem.Menu();
                        break;
                    case "3":
                        bank.Menu();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}

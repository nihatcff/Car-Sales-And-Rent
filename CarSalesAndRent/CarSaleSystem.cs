using System;
using System.Collections.Generic;
using CarSalesAndRent.Models;

namespace CarSalesAndRent.Systems
{
    public class CarSaleSystem
    {
        private List<Car> cars = new List<Car>();
        private Bank bank;

        public CarSaleSystem(Bank bank)
        {
            this.bank = bank;
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n===== CAR SALE MENU =====");
                Console.WriteLine("1. Add Car");
                Console.WriteLine("2. View Cars");
                Console.WriteLine("3. Delete Car");
                Console.WriteLine("4. Filter Cars");
                Console.WriteLine("5. Sort Cars");
                Console.WriteLine("6. Sell Car");
                Console.WriteLine("0. Back");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddCar();
                        break;
                    case "2":
                        ShowCars();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Option not ready yet.");
                        break;
                }
            }
        }

        private void AddCar()
        {
            Console.Write("Brand: ");
            string brand = Console.ReadLine();
            Console.Write("Model: ");
            string model = Console.ReadLine();
            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Cost Price: ");
            double cost = double.Parse(Console.ReadLine());
            Console.Write("Sale Price: ");
            double sale = double.Parse(Console.ReadLine());

            if (bank.Withdraw(cost))
            {
                cars.Add(new Car(brand, model, year, cost, sale));
                Console.WriteLine("Car added successfully!");
            }
            else
            {
                Console.WriteLine("Not enough money in the bank!");
            }
        }

        private void ShowCars()
        {
            if (cars.Count == 0)
            {
                Console.WriteLine("No cars available.");
                return;
            }

            Console.WriteLine("\n--- Cars in System ---");
            for (int i = 0; i < cars.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cars[i]}");
            }
        }
    }
}

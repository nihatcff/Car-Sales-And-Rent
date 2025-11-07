using System;
using System.Collections.Generic;
using CarSalesAndRent.Models;

namespace CarSalesAndRent.Systems
{
    public class RentSystem
    {
        private List<Car> rentCars = new List<Car>();
        private Bank bank;

        public RentSystem(Bank bank)
        {
            this.bank = bank;
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n===== RENT A CAR MENU =====");
                Console.WriteLine("1. Add Car");
                Console.WriteLine("2. View Cars");
                Console.WriteLine("3. Delete Car");
                Console.WriteLine("4. Rent a Car");
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
                rentCars.Add(new Car(brand, model, year, cost, sale));
                Console.WriteLine("Car added to rent list.");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

        private void ShowCars()
        {
            if (rentCars.Count == 0)
            {
                Console.WriteLine("No cars found.");
                return;
            }

            Console.WriteLine("\n--- Cars for Rent ---");
            foreach (var car in rentCars)
            {
                Console.WriteLine(car);
            }
        }
    }
}

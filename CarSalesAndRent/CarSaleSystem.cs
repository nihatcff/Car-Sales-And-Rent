using System;
using System.Collections.Generic;
using System.Linq;
using CarSalesAndRent.Models;

namespace CarSalesAndRent.Systems
{
    public class CarSaleSystem
    {
        private Bank bank;
        private List<Car> cars = new List<Car>();
        private bool looping = true;

        public CarSaleSystem(Bank bank)
        {
            this.bank = bank;
        }

        public void Menu()
        {
            while (looping)
            {
                Console.WriteLine("\n===== CAR SALE SYSTEM =====");
                Console.WriteLine("1. Maşın al");
                Console.WriteLine("2. Maşınlara bax");
                Console.WriteLine("3. Maşını sil");
                Console.WriteLine("4. Maşınları filtr et");
                Console.WriteLine("5. Maşınları çeşidle");
                Console.WriteLine("6. Maşını sat");
                Console.WriteLine("7. Bank menyusu");
                Console.WriteLine("0. Çıxış");
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        AddCar();
                        break;
                    case "2":
                        ShowCars();
                        break;
                    case "3":
                        DeleteCar();
                        break;
                    case "4":
                        FilterCars();
                        break;
                    case "5":
                        SortCars();
                        break;
                    case "6":
                        SellCar();
                        break;
                    case "7":
                        bank.Menu();
                        break;
                    case "0":
                        looping = false;
                        break;
                    default:
                        Console.WriteLine("Yanlış seçim!");
                        break;
                }
            }
        }

        private void AddCar()
        {
            Console.Write("Maşının markası: ");
            string brand = Console.ReadLine();

            Console.Write("Maşının modeli: ");
            string model = Console.ReadLine();

            Console.Write("Maşının ili: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Maşının maya deyeri (Cost Price): ");
            double cost = Convert.ToDouble(Console.ReadLine());

            Console.Write("Maşının satış qiymeti (Sale Price): ");
            double price = Convert.ToDouble(Console.ReadLine());

            if (!bank.Withdraw(cost))
            {
                Console.WriteLine("Balansda kifayet qeder mebleğ yoxdur! Maşın alına bilmedi.");
                return;
            }

            Car newCar = new Car(brand, model, year, cost, price);
            cars.Add(newCar);

            Console.WriteLine($"Maşın elave olundu: ID={newCar.Id}, {brand} {model} ({year})");
            Console.WriteLine($"{cost} AZN balansdan çıxıldı. Yeni balans: {bank.Balance} AZN");
        }

        private void ShowCars()
        {
            if (cars.Count == 0)
            {
                Console.WriteLine("Salonda maşın yoxdur!");
                return;
            }

            Console.WriteLine("\n--- Salondakı maşınlar ---");
            foreach (var car in cars)
            {
                Console.WriteLine($"ID: {car.Id}, {car.Brand} {car.Model}, {car.Year}, Cost: {car.CostPrice} AZN, Sale: {car.SalePrice} AZN");
            }
        }

        private void DeleteCar()
        {
            Console.Write("Silinecek maşının ID-sini daxil edin: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car != null)
            {
                cars.Remove(car);
                Console.WriteLine("Maşın silindi!");
            }
            else
            {
                Console.WriteLine("Bu ID-ye uyğun maşın tapılmadı!");
            }
        }

        private void FilterCars()
        {
            Console.Write("(Optional) İl üzre filter: ");
            string yearInput = Console.ReadLine();

            Console.Write("(Optional) Marka üzre filter: ");
            string brandInput = Console.ReadLine()?.ToLower();

            var filtered = cars.AsEnumerable();

            if (!string.IsNullOrEmpty(yearInput))
            {
                int year = Convert.ToInt32(yearInput);
                filtered = filtered.Where(c => c.Year == year);
            }

            if (!string.IsNullOrEmpty(brandInput))
            {
                filtered = filtered.Where(c => c.Brand.ToLower().Contains(brandInput));
            }

            Console.WriteLine("\n--- Filtr neticeleri ---");
            if (!filtered.Any())
            {
                Console.WriteLine("Uyğun maşın tapılmadı!");
                return;
            }

            foreach (var car in filtered)
            {
                Console.WriteLine($"ID: {car.Id}, {car.Brand} {car.Model}, {car.Year}, {car.SalePrice} AZN");
            }
        }

        private void SortCars()
        {
            Console.Write("Qiymete göre çeşidle (1 - Artan, 2 - Azalan): ");
            string input = Console.ReadLine();

            List<Car> sorted;

            if (input == "1")
                sorted = cars.OrderBy(c => c.SalePrice).ToList();
            else if (input == "2")
                sorted = cars.OrderByDescending(c => c.SalePrice).ToList();
            else
            {
                Console.WriteLine("Yanlış seçim!");
                return;
            }

            Console.WriteLine("\n--- Çeşidlenmiş maşınlar ---");
            foreach (var car in sorted)
            {
                Console.WriteLine($"ID: {car.Id}, {car.Brand} {car.Model}, {car.Year}, {car.SalePrice} AZN");
            }
        }

        private void SellCar()
        {
            Console.Write("Satılacaq maşının ID-sini daxil edin: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                Console.WriteLine("Bu ID-ye uyğun maşın tapılmadı!");
                return;
            }

            cars.Remove(car);
            bank.Deposit(car.SalePrice);

            Console.WriteLine($"{car.Brand} {car.Model} satıldı!");
            Console.WriteLine($"{car.SalePrice} AZN balansınıza elave olundu. Yeni balans: {bank.Balance} AZN");
        }
    }
}

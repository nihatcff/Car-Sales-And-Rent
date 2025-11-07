using CarSalesAndRent.Models;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace CarSalesAndRent.Systems
{
    public class RentSystem
    {
        private static List<Car> masinlar = new List<Car>();
        

        private Bank bank;

        public RentSystem(Bank bank)
        {
           this.bank = bank;
        }


        public void MasinElaveEt()// masin eelave etmek ucunn
        {
            
            Console.Write("Marka: ");
             string marka = Console.ReadLine();

            Console.Write("Model: ");
            string model = Console.ReadLine();

            Console.Write("Il: ");
            int il = Convert.ToInt32(Console.ReadLine());

            Console.Write("Qiymet: ");
            double qiymet = double.Parse(Console.ReadLine());

            Console.Write("Kiraye Qiymeti(eger ala bilsen masini baslangicdan masina kiraye qiymet vermelisen: ");
            double qiymet1 = double.Parse(Console.ReadLine());

            if (bank.Withdraw(qiymet))
            {
                Car masin = new Car(marka, model, il, qiymet, qiymet1);
                masinlar.Add(masin);
                Console.WriteLine($"Id: {masin.Id } / Marka: {marka}  / Model: {model} / Il:{il} sisteme elave olundu.");
                Console.WriteLine($"Bu qeder pulunuz qaldi {bank.Balance}");
            }
            else
            {
                Console.WriteLine(" masin elave olunmadi pul kifayet qeder  yoxdu.");
                Console.WriteLine($"Bu qeder pulunuz qalib cunki :D {bank.Balance} AZN");
            }
        }

        public void MasinSil()// masin silmek ucun  balansa atrtmir sadcee silinrir
        {
            Console.Write("Silmek istediyiniz masinin ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Car? masin = masinlar.FirstOrDefault(x => x.Id == id);
            if (masin != null)
            {
                masinlar.Remove(masin);
                Console.WriteLine($"{masin.Brand} {masin.Model} silindii.");
            }
            else
            {
                Console.WriteLine(" Masin tapilmadi ");
            }
        }


        public void MasinFiltrle()//filtrlnir 
        {
            Console.Write("Filtrlenecek Il: ");
            if (!int.TryParse(Console.ReadLine(), out int il))
            {
                Console.WriteLine("Yanlis  il daxil edilib ");
                return;
            }

            var fff = masinlar.Where(x => x.Year > il).OrderBy(x => x.Year).ToList();

            if (fff.Count == 0)
            {
               Console.WriteLine("Hec bir masın tapilmadi ");
                return;
            }

            Console.WriteLine($"{il}  Filtrlenmis ilə istehsal olunan maasinlarr : ");
            foreach (var m in fff)
               Console.WriteLine(m);
        }


        public void MasinCesidle()
        {
            var d = masinlar.OrderBy(x => x.Year).ToList();

            Console.WriteLine("Butun masinlari ile gore Cesidlendi :");
            foreach (var m in d)
                Console.WriteLine(m);
        }


        public void MasinKiraye()
        {
            Console.Write("hansi ID ye sahib masini kiraye goturmek isteyirsiniz ");
            int id=Convert.ToInt32(Console.ReadLine());
            

            Car? masin = masinlar.FirstOrDefault(x => x.Id ==id);
            if (masin == null)
            {
                Console.WriteLine("Masin tapilmadi.");
                return;

            }
            else
            {

                Console.Write("Kiraye qiymeti: ");
                double kiraye = Convert.ToInt32(Console.ReadLine());
                masin.IsRented = true;
                bank.Deposit(kiraye);
                Console.WriteLine($"{id}  li kirayeye verildi :{kiraye} AZN. sizin balansiniz {bank.Balance}");
            }

        }


        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n----------------------------------- RENT    A   CAR---------------------------------------------------");
                Console.WriteLine("1. Masin elave  et ");
                Console.WriteLine("2. Masin sil");
                Console.WriteLine("3. Masinlari filtrle");
                Console.WriteLine("4. Masinlari cesidle (Qiymet)");
                Console.WriteLine("5. kiraye ver");
                Console.WriteLine("0. Cixis");
                Console.Write("Secim: ");
                string secim = Console.ReadLine()!;
                switch (secim)
                {
                    case "1":
                        MasinElaveEt();
                        
                         break;

                    case "2":
                         MasinSil();
                        break;

                    case "3":
                         MasinFiltrle();
                        break;

                    case "4":
                        MasinCesidle(); 
                        break;

                    case "5":
                        MasinKiraye(); 
                      
                   break;

                    case "0": return;
                    default: Console.WriteLine("Yanlis secim.");
                         
                        break;
                }
            }
        }
    }
}





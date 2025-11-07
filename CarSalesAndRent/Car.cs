namespace CarSalesAndRent.Models
{
    public class Car
    {

        private static int counter = 1;
        public int Id { get; private set; }

        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double CostPrice { get; set; }
        public double SalePrice { get; set; }
        public bool IsRented { get; set; }

        public Car(string brand, string model, int year, double cost, double price)
        {
            Id = counter++;
            Brand = brand;
            Model = model;
            Year = year;
            CostPrice = cost;
            SalePrice = price;
            IsRented = false;
        }

        public override string ToString()
        {
            string rentedText = IsRented ? " (Rented)" : "";
            return $"{Id}. {Brand} {Model} ({Year}) - {SalePrice} AZN{rentedText}";
        }
    }
}
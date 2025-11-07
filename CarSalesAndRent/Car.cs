namespace CarSalesAndRent.Models
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double CostPrice { get; set; }
        public double SalePrice { get; set; }
        public bool IsRented { get; set; }

        public Car(string brand, string model, int year, double cost, double price)
        {
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
            return $"{Brand} {Model} ({Year}) - {SalePrice} AZN{rentedText}";
        }
    }
}

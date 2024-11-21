namespace EKGMaster.Models.ProductStuff
{
    public class Product
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public ProductCategory Category { get; protected set; }
        public enum ProductCategory { Computer=1, Television=2, GamingConsole=3, Screen=4, Phone=5};

        public Product(string model, int year, string brand, double price, string picture, string description, ProductCategory category)
        {
            Model = model;
            Year = year;
            Brand = brand;
            Price = price;
            Picture = picture;
            Description = description;
            Category = category;
        }

        public Product()
        {
            
        }
    }
}

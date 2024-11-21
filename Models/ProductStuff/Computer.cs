namespace EKGMaster.Models.ProductStuff
{
    public class Computer : Product
    {
        public string Storage { get; set; }
        public string OperatingSystem { get; set; }
        public string PSU { get; set; }
        public string RAM { get; set; }
        public string CPU { get; set; }
        public string GPU { get; set; }

        public Computer(int id, string model, int year, string brand, double price, string picture, string description, ProductCategory category) : base(id, model, year, brand, price, picture, description, category)
        {
            Category = ProductCategory.Computer;
        }

        public Computer()
        {
            Category = ProductCategory.Computer;
        }
    }
}

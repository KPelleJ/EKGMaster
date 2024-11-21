namespace EKGMaster.Models.ProductStuff
{
    public class Phone : Product
    {
        public string ScreenSize { get; set; }
        public string OperatingSystem { get; set; }
        public string Storage {  get; set; }
        public string BatteryHealth { get; set; }

        public Phone(string model, int year, string brand, double price, string picture, string description, ProductCategory category, string batteryhealth, string screensize, string operatingsystem, string storage) : base(model, year, brand, price, picture, description, category)
        {
            Category = ProductCategory.Phone;
        }

        public Phone(int id)
        {
            Id = id;
            Category = ProductCategory.Phone;
        }

        public Phone()
        {
            Category = ProductCategory.Phone;
        }
    }
}

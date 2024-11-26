namespace EKGMaster.Models.ProductStuff
{
    public class Screen : Product
    {
        public string ScreenSize { get; set; }
        public string Resolution { get; set; }
        public string RefreshRate { get; set; }

        public Screen(string model, int year, string brand, double price, string picture, string description) : base(model, year, brand, price, picture, description)
        {
            Category = ProductCategory.Screen;
        }
    }
}

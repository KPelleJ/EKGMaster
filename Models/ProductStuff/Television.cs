namespace EKGMaster.Models.ProductStuff
{
    public class Television : Product
    {
        public string ScreenSize {  get; set; }
        public string Resolution { get; set; }
        public bool SmartTv { get; set; }
        public Television(int id, string model, int year, string brand, double price, string picture, string description, string category, string screenSize, string resolution, bool smartTv) : base(id, model, year, brand, price, picture, description, category)
        {
            ScreenSize = screenSize;
            Resolution = resolution;
            SmartTv = smartTv;
            Category = ProductCategory.Television;
        }
    }
}

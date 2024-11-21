namespace EKGMaster.Models.ProductStuff
{
    public class Television : Product
    {
        public string ScreenSize {  get; set; }
        public string Resolution { get; set; }
        public bool SmartTv { get; set; }
        
        public Television(int id)
        {
            Id = id;
        }

        public Television(string model, int year, string brand, double price, string picture, string description, ProductCategory category) : base(model, year, brand, price, picture, description, category)
        {
        }
    }
}

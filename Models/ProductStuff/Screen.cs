namespace EKGMaster.Models.ProductStuff
{
    public class Screen : Product
    {
        public Screen(string model, int year, string brand, double price, string picture, string description, ProductCategory category) : base(model, year, brand, price, picture, description, category)
        {
        }
    }
}

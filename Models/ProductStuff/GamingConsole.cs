namespace EKGMaster.Models.ProductStuff
{
    public class GamingConsole:Product
    {
        public string Edition { get; set; }
        public string Storage { get; set; }

        public GamingConsole() 
        { 
            Category = ProductCategory.GamingConsole;
        }

        public GamingConsole(int id)
        {
            Id = id;
        }
    }
}

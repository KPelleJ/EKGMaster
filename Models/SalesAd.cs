using EKGMaster.Models.ProductStuff;
using EKGMaster.Models.UserStuff;

namespace EKGMaster.Models

{
    public class SalesAd
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }
        public DateTime DateOfCreation { get; set; }
        
        public SalesAd(int id, string title, Product product, User user, DateTime dateofcreation)
        {
            Id = id;
            Title = title;
            Product = product;
            User = user;
            DateOfCreation = dateofcreation;
        }
    

    }
}

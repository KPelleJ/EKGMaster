using EKGMaster.Models.ProductStuff;
using EKGMaster.Models.UserStuff;

namespace EKGMaster.Models

{
    public class SalesAd
    {
        public string Title { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public DateTime DateOfCreation { get; set; }
        
        public SalesAd(string title, int productId, int userId, DateTime dateofcreation)
        {
            Title = title;
            ProductId = productId;
            UserId = userId;
            DateOfCreation = dateofcreation;
        }

        public SalesAd()
        {

        }
    

    }
}

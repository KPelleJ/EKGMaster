using EKGMaster.Models;
using EKGMaster.Models.ProductStuff;

namespace EKGMaster.Interfaces
{
    public interface IDeleteProducts
    {
        public void DeleteProduct(Product product, SalesAd salesAd);
        //public void DeleteComputer(Computer product, SalesAd salesAd);
        //public void DeleteScreen(Screen screen, SalesAd salesAd);
    }
}

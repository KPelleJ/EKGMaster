using EKGMaster.Models;
using EKGMaster.Models.ProductStuff;

namespace EKGMaster.Interfaces
{
    public interface ICreateProducts
    {
        public void AddComputer(Computer product, SalesAd salesAd);

        public void AddGamingConsole(GamingConsole product, SalesAd salesAd);

        public void AddPhone(Phone product, SalesAd salesAd);

        public void AddScreen(Screen product, SalesAd salesAd);

        public void AddTelevision(Television product, SalesAd salesAd);
    }
}

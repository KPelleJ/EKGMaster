using EKGMaster.Interfaces;
using EKGMaster.Models.ProductStuff;

namespace EKGMaster.Models.ProductHandlers
{
    public class AdProductCreater : ICreateProducts
    {

        private readonly ICRUDRepository<SalesAd> _salesAdRepository;
        private readonly ICategoryRepository<Computer> _computerRepo;
        private readonly ICategoryRepository<GamingConsole> _consoleRepo;
        private readonly ICategoryRepository<Phone> _phoneRepo;
        private readonly ICategoryRepository<Screen> _screenRepo;
        private readonly ICategoryRepository<Television> _tvRepo;

        public AdProductCreater
        (
            ICRUDRepository<SalesAd> salesAdRepo,
            ICategoryRepository<Computer> computerRepo,
            ICategoryRepository<GamingConsole> consoleRepo,
            ICategoryRepository<Phone> phoneRepo,
            ICategoryRepository<Screen> screenRepo,
            ICategoryRepository<Television> tvRepo
        )
        {
            _salesAdRepository = salesAdRepo;
            _computerRepo = computerRepo;
            _consoleRepo = consoleRepo;
            _phoneRepo = phoneRepo;
            _screenRepo = screenRepo;
            _tvRepo = tvRepo;
        }

        public void AddComputer(Computer product, SalesAd salesAd)
        {
            salesAd.ProductId = _computerRepo.Add(product).Id;
            _salesAdRepository.Add(salesAd);
        }

        public void AddGamingConsole(GamingConsole product, SalesAd salesAd)
        {
            salesAd.ProductId = _consoleRepo.Add(product).Id;
            _salesAdRepository.Add(salesAd);
        }

        public void AddPhone(Phone product, SalesAd salesAd)
        {
            salesAd.ProductId = _phoneRepo.Add(product).Id;
            _salesAdRepository.Add(salesAd);
        }

        public void AddScreen(Screen product, SalesAd salesAd)
        {
            salesAd.ProductId = _screenRepo.Add(product).Id;
            _salesAdRepository.Add(salesAd);
        }

        public void AddTelevision(Television product, SalesAd salesAd)
        {
            salesAd.ProductId = _tvRepo.Add(product).Id;
            _salesAdRepository.Add(salesAd);
        }
    }
}

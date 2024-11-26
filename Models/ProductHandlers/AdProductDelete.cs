using EKGMaster.Interfaces;
using EKGMaster.Models.ProductStuff;

namespace EKGMaster.Models.ProductHandlers
{
    public class AdProductDelete : IDeleteProducts
    {
        private readonly ICRUDRepository<SalesAd> _salesAdRepository;
        private readonly ICategoryRepository<Computer> _computerRepo;
        private readonly ICategoryRepository<GamingConsole> _consoleRepo;
        private readonly ICategoryRepository<Phone> _phoneRepo;
        private readonly ICategoryRepository<Screen> _screenRepo;
        private readonly ICategoryRepository<Television> _tvRepo;

        public AdProductDelete
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
        public void DeleteProduct(Product product, SalesAd salesAd)
        {
            _salesAdRepository.Delete(salesAd);
            _computerRepo.Delete((Computer)product);
        }
    }
}

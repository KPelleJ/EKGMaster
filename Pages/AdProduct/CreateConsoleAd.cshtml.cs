using EKGMaster.Interfaces;
using EKGMaster.Models.ProductStuff;
using EKGMaster.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EKGMaster.Pages.AdProduct
{
    public class CreateConsoleAdModel : PageModel
    {
        private readonly ICategoryRepository<GamingConsole> _consoleRepo;
        private readonly ICRUDRepository<SalesAd> _salesAdRepo;

        [BindProperty]
        public GamingConsole GamingConsole { get; set; }

        [BindProperty]
        public SalesAd SalesAd { get; set; }

        public CreateConsoleAdModel(ICategoryRepository<GamingConsole> consoleRepo, ICRUDRepository<SalesAd> salesAdRepo)
        {
            _consoleRepo = consoleRepo;
            _salesAdRepo = salesAdRepo;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            SalesAd.ProductId = _consoleRepo.Add(GamingConsole).Id;

            _salesAdRepo.Add(SalesAd);

            return RedirectToPage("/Index");
        }
    }
}

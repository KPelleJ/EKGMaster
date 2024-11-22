using EKGMaster.Interfaces;
using EKGMaster.Models.ProductStuff;
using EKGMaster.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EKGMaster.Pages.AdProduct
{
    public class CreateConsoleAdModel : PageModel
    {
        private readonly ICreateProducts _productRepo;

        [BindProperty]
        public GamingConsole GamingConsole { get; set; }

        [BindProperty]
        public SalesAd SalesAd { get; set; }

        public CreateConsoleAdModel(ICreateProducts productRepo)
        {
            _productRepo = productRepo;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _productRepo.AddGamingConsole(GamingConsole, SalesAd);
            return RedirectToPage("/Index");
        }
    }
}

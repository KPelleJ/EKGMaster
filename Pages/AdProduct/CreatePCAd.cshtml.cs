using EKGMaster.Interfaces;
using EKGMaster.Models.ProductStuff;
using EKGMaster.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EKGMaster.Pages.AdProduct
{
    public class CreatePCAdModel : PageModel
    {
        private readonly ICreateProducts _productRepo;

        [BindProperty]
        public Computer Computer { get; set; }

        [BindProperty]
        public SalesAd SalesAd { get; set; }

        public CreatePCAdModel(ICreateProducts productRepo)
        {
            _productRepo = productRepo;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            _productRepo.AddComputer(Computer, SalesAd);
            return RedirectToPage("/Index");
        }
    }
}

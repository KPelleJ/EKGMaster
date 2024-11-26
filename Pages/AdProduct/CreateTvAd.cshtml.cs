using EKGMaster.Interfaces;
using EKGMaster.Models;
using EKGMaster.Models.ProductStuff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EKGMaster.Pages.CreateProducts
{
    public class CreateTvProductModel : PageModel
    {
        [BindProperty]
        public SalesAd salesAd {  get; set; }

        [BindProperty]
        public Television Television { get; set; }

        private readonly ICreateProducts _createProducts;
        public CreateTvProductModel(ICreateProducts createProducts)
        {
            _createProducts = createProducts;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _createProducts.AddTelevision(Television, salesAd);
            return RedirectToPage("/Index");
        }
    }
}

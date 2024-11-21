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
        private ICategoryRepository<Television> _tvRepo;
        public CreateTvProductModel(ICategoryRepository<Television> tvRepo)
        {
            _tvRepo = tvRepo;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _tvRepo.Add(Television);
            return RedirectToPage("/Index");
        }
    }
}

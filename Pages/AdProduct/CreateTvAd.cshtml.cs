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

        private ICRUDRepository<SalesAd> _salesAdRepository;
        private ICategoryRepository<Television> _tvRepo;
        public CreateTvProductModel(ICategoryRepository<Television> tvRepo, ICRUDRepository<SalesAd> salesAdRepository)
        {
            _tvRepo = tvRepo;
            _salesAdRepository = salesAdRepository;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
           
            _salesAdRepository.Add(salesAd);
            return RedirectToPage("/Index");
        }
    }
}

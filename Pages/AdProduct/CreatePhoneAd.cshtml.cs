using EKGMaster.Interfaces;
using EKGMaster.Models.ProductStuff;
using EKGMaster.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EKGMaster.Pages.AdProduct
{
    public class CreatePhoneAdModel : PageModel
    {
        private readonly ICreateProducts _productRepo;
        [BindProperty]
        public Phone Phone { get; set; }

        [BindProperty]
        public SalesAd SalesAd { get; set; }

        private ICRUDRepository<SalesAd> _salesAdRepository;
        private ICategoryRepository<Phone> _phoneRepo;
        public CreatePhoneAdModel(ICreateProducts productRepo)
        {
            _productRepo = productRepo;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _phoneRepo.Add(Phone);

            _productRepo.AddPhone(Phone, SalesAd);
            return RedirectToPage("/Index");                      
        }
    }
}

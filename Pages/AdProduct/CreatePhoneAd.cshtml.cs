using EKGMaster.Interfaces;
using EKGMaster.Models.ProductStuff;
using EKGMaster.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EKGMaster.Pages.AdProduct
{
    public class CreatePhoneAdModel : PageModel
    {
        [BindProperty]
        public SalesAd salesAd { get; set; }

        [BindProperty]
        public Phone Phone { get; set; }

        private ICRUDRepository<SalesAd> _salesAdRepository;
        private ICategoryRepository<Phone> _phoneRepo;
        public CreatePhoneAdModel(ICategoryRepository<Phone> phoneRepo, ICRUDRepository<SalesAd> salesAdRepository)
        {
            _phoneRepo = phoneRepo;
            _salesAdRepository = salesAdRepository;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _phoneRepo.Add(Phone);

            _salesAdRepository.Add(salesAd);
            return RedirectToPage("/Index");                      
        }
    }
}

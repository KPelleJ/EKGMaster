using EKGMaster.Interfaces;
using EKGMaster.Models;
using EKGMaster.Models.ProductStuff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EKGMaster.Pages
{
    public class TestpageModel : PageModel
    {
        //private readonly ICategoryRepository<Computer> _pcrepo;
        private readonly ICategoryRepository<Computer> _pcrepo;
        private readonly ICRUDRepository<SalesAd> _salesAdRepo;

        [BindProperty]
        public Computer Computer { get; set; }

        [BindProperty]
        public SalesAd SalesAd { get; set; }

        public TestpageModel(ICategoryRepository<Computer> pcrepo, ICRUDRepository<SalesAd> salesAdRepo) 
        { 
            _pcrepo = pcrepo;
            _salesAdRepo = salesAdRepo;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            _pcrepo.Add(Computer);
            SalesAd.ProductId = _pcrepo.GetNewestItem().Id;

            _salesAdRepo.Add(SalesAd);
            return RedirectToPage("/Index");
        }
    }
}

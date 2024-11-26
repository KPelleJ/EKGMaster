using EKGMaster.Interfaces;
using EKGMaster.Models;
using EKGMaster.Models.ProductStuff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EKGMaster.Pages
{
    public class TestpageModel : PageModel
    {
        private readonly ICategoryRepository<Computer> _pcrepo;
        private readonly ICRUDRepository<SalesAd> _salesAdRepo;
        private readonly IDeleteProducts _deleteProducts;

        [BindProperty]
        public Computer Computer { get; set; }

        [BindProperty]
        public SalesAd SalesAd { get; set; }

        public TestpageModel(/*ICategoryRepository<Computer> pcrepo*/IDeleteProducts deleteProducts, ICRUDRepository<SalesAd> salesAdRepo) 
        { 
            _deleteProducts = deleteProducts;
           /* _pcrepo = pcrepo;*/
            _salesAdRepo = salesAdRepo;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            _deleteProducts.DeleteProduct(Computer, SalesAd);
            return RedirectToPage("/Index");
        }
    }
}

using EKGMaster.Interfaces;
using EKGMaster.Models.ProductStuff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EKGMaster.Pages
{
    public class TestpageModel : PageModel
    {
        //private readonly ICategoryRepository<Computer> _pcrepo;
        private readonly ICategoryRepository<Computer> _pcrepo;

        [BindProperty]
        public Computer computer { get; set; }

        public TestpageModel(ICategoryRepository<Computer> pcrepo) 
        { 
            _pcrepo = pcrepo;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            _pcrepo.Add(computer);
            return RedirectToPage("/Index");
        }
    }
}

using EKGMaster.Interfaces;
using EKGMaster.Models.UserStuff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EKGMaster.Pages.Account
{
    public class UserRegistrationModel : PageModel
    {
        private readonly ICreateUser _createUser;

        [BindProperty]
        public Credential Credential { get; set; }

        [BindProperty]
        public User User { get; set; }

        public UserRegistrationModel(ICreateUser createUser)
        {
            _createUser = createUser;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            //if (!ModelState.IsValid) return Page();

            _createUser.AddUserWithCredentials(Credential, User);
            return RedirectToPage("/Index");
        }
    }
}

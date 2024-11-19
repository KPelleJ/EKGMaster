using EKGMaster.Interfaces;
using EKGMaster.Models.UserStuff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EKGMaster.Pages.Account
{
    public class UserRegistrationModel : PageModel
    {
        private ICRUDRepository<User> _userRepository;
        private ICRUDRepository<Credential> _credentialRepository;

        [BindProperty]
        public Credential Credential { get; set; }

        [BindProperty]
        public User User { get; set; }

        public UserRegistrationModel(ICRUDRepository<User> userRepo, ICRUDRepository<Credential> credRepo)
        {
            _userRepository = userRepo;
            _credentialRepository = credRepo;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            Credential.PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(Credential.Password, 12);
            User.CredMail = Credential.Email;
            
            
            //if (!ModelState.IsValid) return Page();

            _credentialRepository.Add(Credential);
            _userRepository.Add(User);

            return RedirectToPage("/Index");
        }
    }
}

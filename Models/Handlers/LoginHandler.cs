using EKGMaster.Interfaces;
using EKGMaster.Models.UserStuff;
using EKGMaster.Repositories;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace EKGMaster.Models.Handlers
{
    public class LoginHandler : ICreateUser
    {
        private readonly ICRUDRepository<User> _userRepo;
        private readonly ICRUDRepository<Credential> _credentialRepo;
        
        public LoginHandler(ICRUDRepository<Credential> credentialRepo, ICRUDRepository<User> userRepo)
        {
            _credentialRepo = credentialRepo;
            _userRepo = userRepo;
        }
        public void AddUserWithCredentials(Credential credential, User user)
        {
            credential.PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(credential.Password, 12);
            user.CredMail = credential.Email;
            _credentialRepo.Add(credential);
            _userRepo.Add(user);
        }
    }
}

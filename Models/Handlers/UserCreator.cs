using EKGMaster.Interfaces;
using EKGMaster.Models.UserStuff;

namespace EKGMaster.Models.Handlers
{
    public class UserCreator : ICreateUser
    {
        private readonly ICRUDRepository<User> _userRepo;
        private readonly ICRUDRepository<Credential> _credentialRepo;

        public UserCreator(ICRUDRepository<Credential> credentialRepo, ICRUDRepository<User> userRepo)
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

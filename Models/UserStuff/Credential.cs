namespace EKGMaster.Models.UserStuff
{
    public class Credential
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ?PasswordHash { get; set; }
        public bool RememberMe { get; set; }
    }
}

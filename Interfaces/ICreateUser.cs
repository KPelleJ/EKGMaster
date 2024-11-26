using EKGMaster.Models.UserStuff;

namespace EKGMaster.Interfaces
{
    public interface ICreateUser
    {
        void AddUserWithCredentials(Credential credential, User user);
    }
}

namespace EKGMaster.Models.UserStuff
{
    public class User
    {
        public int Id { get; set; }
        public Credential Credential { get; set; }
        public string UserName { get; set; }
        public DateTime SignUpDate { get; set; }
        public int Rating { get; set; }
        public string City { get; set; }
        public UserType Usertype { get; set; }
        public enum UserType { Admin=1, RegularUser=2}
    }
}

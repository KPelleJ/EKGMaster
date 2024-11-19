using EKGMaster.Interfaces;
using EKGMaster.Models.UserStuff;
using Microsoft.Data.SqlClient;

namespace EKGMaster.Repositories
{
    public class UserRepository : ICRUDRepository<User>
    {
        private readonly string _connectionString;
        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("myDb1");
        }
        public void Add(User t)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Users (UserName, UserLevelId, CredMail, City) " +
                            "VALUES (@UserName, @UserLevelId, @CredMail, @City)";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@UserName", t.UserName);
                command.Parameters.AddWithValue("@UserLevelId", t.Usertype);
                command.Parameters.AddWithValue("@CredMail", t.Credential.Email);
                command.Parameters.AddWithValue("@City", t.City);
            }
        }

        public void Delete(User t)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetSingleObject(User t)
        {
            throw new NotImplementedException();
        }

        public void Update(User t)
        {
            throw new NotImplementedException();
        }
    }
}

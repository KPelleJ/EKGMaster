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
                string sql = "INSERT INTO Users (UserName, CredEmail, City) " +
                            "VALUES (@UserName, @CredEmail, @City)";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@UserName", t.UserName);
                command.Parameters.AddWithValue("@CredEmail", t.CredMail);
                command.Parameters.AddWithValue("@City", t.City);

                command.ExecuteNonQuery();
            }
        }
        public void Delete(User t)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "DELETE FROM Users Where Id = @Id";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Id", t.Id);

                command.ExecuteNonQuery();
            }
        }
        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }
        public User GetSingleObject(User t)
        {
            User userw = new User();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Users Where CredMail = @CredMail";

                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User();
                    user.Id = reader.GetInt32(0);
                    user.UserName = reader.GetString(1);
                    user.Credential.Email = reader.GetString(3);
                    user.City = reader.GetString(6);

                    userw = user;
                }

            }
            return userw;
        }
        public void Update(User t)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "UPDATE Users SET UserName = @UserName, CredMail = @CredMail, City = @City";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@UserName", t.UserName);
                command.Parameters.AddWithValue("@CredMail", t.Credential.Email);
                command.Parameters.AddWithValue("@City", t.City);

                command.ExecuteNonQuery();
            }
        }
    }
}

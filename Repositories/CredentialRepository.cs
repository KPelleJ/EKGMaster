using EKGMaster.Interfaces;
using EKGMaster.Models.UserStuff;
using Microsoft.Data.SqlClient;

namespace EKGMaster.Repositories
{
    public class CredentialRepository : ICRUDRepository<Credential>
    {
        private readonly string _connectionString;

        public CredentialRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("myDb1");
        }

        public void Add(Credential t)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Credentials (Email, PasswordHash) " +
                             "VALUES (@Email, @PasswordHash)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Email", t.Email);
                command.Parameters.AddWithValue("@PasswordHash", t.PasswordHash);
                command.ExecuteNonQuery();
            }
        }

        public Credential GetSingleObject(Credential t)
        {
            Credential creds = new Credential();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Credentials where Email = @Email", connection);
                command.Parameters.AddWithValue("@Email", t.Email);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Credential c = new Credential();
                    c.Email = reader.GetString(0);
                    c.PasswordHash = reader.GetString(1);

                    creds = c;
                }
            }
            return creds;
        }

        public void Update(Credential t)
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "UPDATE Credentials SET Email = @Email, PasswordHash = @PasswordHash" +
                             "WHERE Email = @Email";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Email", t.Email);
                command.Parameters.AddWithValue("@PasswordHash", t.PasswordHash);

                command.ExecuteNonQuery();
            }
            
        }

        public void Delete(Credential t)
        {
            throw new NotImplementedException();
        }

        public List<Credential> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

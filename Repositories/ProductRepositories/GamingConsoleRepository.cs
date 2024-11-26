using EKGMaster.Interfaces;
using EKGMaster.Models.ProductStuff;
using Microsoft.Data.SqlClient;

namespace EKGMaster.Repositories.ProductRepositories
{
    public class GamingConsoleRepository : ICategoryRepository<GamingConsole>
    {
        private readonly string _connectionString;

        public GamingConsoleRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("myDb1");
        }

        public GamingConsole Add(GamingConsole product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Products (CatId, Description, Year, Brand, Model, Price, Edition, Storage) " +
                             "VALUES (@CatId, @Description, @Year, @Brand, @Model, @Price, @Edition, @Storage);" +
                             "SELECT Id FROM Products WHERE Id = SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@CatId", (int)product.Category);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Year", product.Year);
                command.Parameters.AddWithValue("@Brand", product.Brand);
                command.Parameters.AddWithValue("@Model", product.Model);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Edition", product.Edition);
                command.Parameters.AddWithValue("@Storage", product.Storage);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    product.Id = reader.GetInt32(0);
                }

            }
            return product;
        }

        public void Delete(GamingConsole t)
        {
            throw new NotImplementedException();
        }

        public GamingConsole GetOne(GamingConsole t)
        {
            throw new NotImplementedException();
        }

        public void Update(GamingConsole t)
        {
            throw new NotImplementedException();
        }
    }
}

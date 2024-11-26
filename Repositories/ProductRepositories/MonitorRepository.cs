using EKGMaster.Interfaces;
using EKGMaster.Models.ProductStuff;
using Microsoft.Data.SqlClient;

namespace EKGMaster.Repositories.ProductRepositories
{
    public class MonitorRepository : ICategoryRepository<Screen>
    {
        private readonly string _connectionString;

        public MonitorRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("myDb1");
        }

        public Screen Add(Screen product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Products (CatId, Description, Year, Brand, Model, Price, ScreenSize, Resolution, RefreshRate) " +
                             "VALUES (@CatId, @Description, @Year, @Brand, @Model, @Price, @ScreenSize, @Resolution, @RefreshRate);" +
                             "SELECT Id FROM Products WHERE Id = SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@CatId", (int)product.Category);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Year", product.Year);
                command.Parameters.AddWithValue("@Brand", product.Brand);
                command.Parameters.AddWithValue("@Model", product.Model);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@ScreenSize", product.ScreenSize);
                command.Parameters.AddWithValue("@Resolution", product.Resolution);
                command.Parameters.AddWithValue("@RefreshRate", product.RefreshRate);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    product.Id = reader.GetInt32(0);
                }

            }
            return product;
        }

        public void Delete(Screen product)
        {
            throw new NotImplementedException();
        }

        public Screen GetOne(Screen product)
        {
            throw new NotImplementedException();
        }

        public void Update(Screen product)
        {
            throw new NotImplementedException();
        }
    }
}

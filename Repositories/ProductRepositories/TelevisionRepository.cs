using EKGMaster.Interfaces;
using EKGMaster.Models.ProductStuff;
using Microsoft.Data.SqlClient;

namespace EKGMaster.Repositories.ProductRepositories
{
    public class TelevisionRepository : ICategoryRepository<Television>
    {
        private readonly string _connectionString;
        public TelevisionRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("myDb1");
        }
        public Television Add(Television t)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Products (CatId, Description, Year, Brand, Model, Price, ScreenSize, Resolution, SmartTv) " +
                            "VALUES (@CatId, @Description, @Year, @Brand, @Model, @Price, @ScreenSize, @Resolution, @SmartTv)" +
                            "SELECT Id FROM Products WHERE Id = SCOPE_IDENTITY()";
                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@CatId", t.Category);
                command.Parameters.AddWithValue("@Description", t.Description);
                command.Parameters.AddWithValue("@Year", t.Year);
                command.Parameters.AddWithValue("@Brand", t.Brand);
                command.Parameters.AddWithValue("@Model", t.Model);
                command.Parameters.AddWithValue("@Price", t.Price);
                command.Parameters.AddWithValue("@ScreenSize", t.ScreenSize);
                command.Parameters.AddWithValue("@Resolution", t.Resolution);
                command.Parameters.AddWithValue("@SmartTv", t.SmartTv);


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    t.Id = reader.GetInt32(0);
                }

            }
            return t;
        }
        public void Delete(Television product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "DELETE FROM Products Where Id = @Id";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Id", product.Id);

                command.ExecuteNonQuery();
            }
        }
        public Television GetOne(Television t)
        {
            throw new NotImplementedException();
        }

        public void Update(Television t)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "UPDATE Products SET Description = @Description, Year = @Year," +
                    "Brand = @Brand, Model = @Model, Price = @Price, ScreenSize = @ScreenSize," +
                    " Resolution = @Resolution, SmartTv = @SmartTv WHERE Id = @Id";

                SqlCommand command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Description", t.Description);
                command.Parameters.AddWithValue("@Year", t.Year);
                command.Parameters.AddWithValue("@Brand", t.Brand);
                command.Parameters.AddWithValue("@Model", t.Model);
                command.Parameters.AddWithValue("@Price", t.Price);
                command.Parameters.AddWithValue("@ScreenSize", t.ScreenSize);
                command.Parameters.AddWithValue("@Resolution", t.Resolution);
                command.Parameters.AddWithValue("@SmartTv", t.SmartTv);

                command.ExecuteNonQuery();
            }
        }
    }
}

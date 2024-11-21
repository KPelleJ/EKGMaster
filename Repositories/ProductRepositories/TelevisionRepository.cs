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
        public void Add(Television t)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO Products (CatId, Description, Year, Brand, Model, Price, ScreenSize, Resolution, SmartTv) " +
                            "VALUES (@CatId, @Description, @Year, @Brand, @Model, @Price, @ScreenSize, @Resolution, @SmartTv)";
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

                command.ExecuteNonQuery();
            }
        }

        public void Delete(Television t)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Television GetOne(Television t)
        {
            throw new NotImplementedException();
        }

        public void Update(Television t)
        {
            throw new NotImplementedException();
        }
        public Television GetNewestItem()
        {
            List<Television> products = new List<Television>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Products WHERE CatId = 2 ORDER BY Id";

                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Television tv = new Television(reader.GetInt32(0));

                    products.Add(tv);
                }
            }
            return products.Last();
        }
    }
}

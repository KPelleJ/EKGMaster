using EKGMaster.Interfaces;
using EKGMaster.Models.ProductStuff;
using Microsoft.Data.SqlClient;

namespace EKGMaster.Repositories.ProductRepositories
{
    public class PhoneRepository : ICategoryRepository<Phone>
    {
        private readonly string _connectionString;

        public PhoneRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("myDb1");
        }

        public void Add(Phone product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Products (CatId, Description, Year, Brand, Model, Price, Storage, OperatingSystem, ScreenSize, BatteryHealth) " +
                             "VALUES (@CatId, @Description, @Year, @Brand, @Model, @Price, @Storage, @OperatingSystem, @ScreenSize, @BatteryHealth)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@CatId", (int)product.Category);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Year", product.Year);
                command.Parameters.AddWithValue("@Brand", product.Brand);
                command.Parameters.AddWithValue("@Model", product.Model);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Storage", product.Storage);
                command.Parameters.AddWithValue("@OperatingSystem", product.OperatingSystem);
                command.Parameters.AddWithValue("@ScreenSize", product.ScreenSize);
                command.Parameters.AddWithValue("@BatteryHealth", product.BatteryHealth);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(Phone product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Phone GetOne(Phone product)
        {
            throw new NotImplementedException();
        }

        public void Update(Phone product)
        {
            throw new NotImplementedException();
        }
    }
}

using EKGMaster.Interfaces;
using EKGMaster.Models.ProductStuff;
using Microsoft.Data.SqlClient;

namespace EKGMaster.Repositories.ProductRepositories
{
    public class ComputerRepository : ICategoryRepository<Computer>
    {
        private readonly string _connectionString;

        public ComputerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("myDb1");
        }

        public void Add(Computer product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Products (CatId, Description, Year, Brand, Model, Price, Storage, OperatingSystem, PSU, RAM, CPU, GPU) " +
                             "VALUES (@CatId, @Description, @Year, @Brand, @Model, @Price, @Storage, @OperatingSystem, @PSU, @RAM, @CPU, @GPU)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@CatId", (int)product.Category);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Year", product.Year);
                command.Parameters.AddWithValue("@Brand", product.Brand);
                command.Parameters.AddWithValue("@Model", product.Model);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Storage", product.Storage);
                command.Parameters.AddWithValue("@OperatingSystem", product.OperatingSystem);
                command.Parameters.AddWithValue("@PSU", product.PSU);
                command.Parameters.AddWithValue("@RAM", product.RAM);
                command.Parameters.AddWithValue("@CPU", product.CPU);
                command.Parameters.AddWithValue("@GPU", product.GPU);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(Computer product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetOne(Computer product)
        {
            throw new NotImplementedException();
        }

        public void Update(Computer product)
        {
            throw new NotImplementedException();
        }
    }
}

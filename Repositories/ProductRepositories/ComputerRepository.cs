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
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM Products WHERE Id = @Id";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Id", product.Id);

                command.ExecuteNonQuery();
            }
        }

        public Computer GetOne(Computer product)
        {
            throw new NotImplementedException();   
        }

        public void Update(Computer product)
        {
            throw new NotImplementedException();
        }

        //Indtil videre virker det her men det kan nok gøres smartere
        public Computer GetNewestItem()
        {
            List<Computer> products = new List<Computer>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Products WHERE CatId = 1 ORDER BY Id";

                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Computer product = new Computer(reader.GetInt32(0));

                    products.Add(product);
                }
            }
            return products.Last();
        }
    }
}

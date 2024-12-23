﻿using EKGMaster.Interfaces;
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

        public Phone Add(Phone product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Products (CatId, Description, Year, Brand, Model, Price, Storage, OperatingSystem, ScreenSize, BatteryHealth)" +
                             "VALUES (@CatId, @Description, @Year, @Brand, @Model, @Price, @Storage, @OperatingSystem, @ScreenSize, @BatteryHealth)" +
                             "SELECT Id FROM Products WHERE Id = SCOPE_IDENTITY();";

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

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    product.Id = reader.GetInt32(0);
                }

            }
            return product;
        }

        public void Delete(Phone product)
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

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Phone GetOne(Phone product)
        {
            return new Phone();
        }

        public void Update(Phone product)
        {
            throw new NotImplementedException();
        }
        public Phone GetNewestItem()
        {
            throw new NotImplementedException();
        }
    }
}

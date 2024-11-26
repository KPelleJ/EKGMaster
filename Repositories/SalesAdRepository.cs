using EKGMaster.Interfaces;
using EKGMaster.Models;
using EKGMaster.Models.ProductStuff;
using EKGMaster.Models.UserStuff;
using Microsoft.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EKGMaster.Repositories
{
    public class SalesAdRepository : ICRUDRepository<SalesAd>
    {
        private readonly string _connectionString;
        public SalesAdRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("myDb1");

        }
        public void Add(SalesAd salesAd)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO SalesAds (ProdId, UserId, Title)" + "VALUES(@ProdId, @UserId, @Title)";

                SqlCommand command = new SqlCommand(sql, connection);
                
                command.Parameters.AddWithValue("@ProdId", salesAd.ProductId);
                    command.Parameters.AddWithValue("@UserId", salesAd.UserId);
                    command.Parameters.AddWithValue("@Title", salesAd.Title);

                    command.ExecuteNonQuery();
                
            }
        }
        public void Delete(SalesAd salesAd)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "DELETE FROM SalesAds WHERE ProdId = @ProdId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@ProdId", salesAd.ProductId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<SalesAd> GetAll()
        {
            throw new NotImplementedException();
        }

        public SalesAd GetSingleObject(SalesAd salesAd)
        {
            SalesAd salesAdd = new SalesAd();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM SalesAds WHERE ProdId = @ProdId, UserId = @UserId Id = @Id";

                    SqlCommand command = new SqlCommand(sql, connection);
                
                    command.Parameters.AddWithValue("@Id", salesAd.ProductId);

                     SqlDataReader reader = command.ExecuteReader();
                    
                        if (reader.Read())
                        { 
                            SalesAd salesAd1 = new SalesAd();
                            salesAd.ProductId = reader.GetInt32(0);
                            salesAd.UserId = reader.GetInt32(1);
                            salesAd.Title = reader.GetString(2);
                        }
            }
            return salesAd;
        }
        
        public void Update(SalesAd salesAd)
        {
           using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "UPDATE SalesAds SET Title = @Title, Product = @Product, UserId = @UserId, DateOfCreation = @DateOfCreation WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Title", salesAd.Title);
                    command.Parameters.AddWithValue("@Product", salesAd.ProductId);
                    command.Parameters.AddWithValue("@UserId", salesAd.UserId);
                    command.Parameters.AddWithValue("@DateOfCreation", salesAd.DateOfCreation);

                    command.ExecuteNonQuery();
                }                
            }
        }
    }
}

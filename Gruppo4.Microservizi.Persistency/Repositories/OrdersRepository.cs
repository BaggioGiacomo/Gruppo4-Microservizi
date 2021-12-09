using Dapper;
using Gruppo4.Microservizi.AppCore.Interfaces.Data;
using Gruppo4.Microservizi.AppCore.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.Persistency.Repositories
{
    public class OrdersRepository : IOrderRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString = "Server=tcp:its-clod-zanotto.database.windows.net,1433;Initial Catalog=its-clod-zanotto;Persist Security Info=False;User ID=andrea;Password=Vmware1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public OrdersRepository()
        {

        }

        public OrdersRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task DeleteOrder(Guid id)
        {
            using var connection = new SqlConnection(_connectionString);

            const string queryDelete = "DELETE FROM Orders WHERE Id=@Id";

          
           connection.Execute(queryDelete, new { Id = id});
            
        }

        public async Task<Order> GetOrder(Guid id)
        {
            using var connection = new SqlConnection(_connectionString);

            List<Order> list = new List<Order>();

            const string querySelect = "SELECT * FROM Orders WHERE Id=@Id";
            

            return await connection.QuerySingleAsync<Order>(querySelect, new
            {
                Id = id
            });
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            using var connection = new SqlConnection(_connectionString);

            List<Order> list = new List<Order>();

            const string querySelectAll = "SELECT * FROM Orders";

            return await connection.QueryAsync<Order>(querySelectAll);
        }

        public async Task InsertOrder(Order order)
        {

            if (order != null)
            {
                using var connection = new SqlConnection(_connectionString);
                const string queryInsert = @"
INSERT INTO Orders
           (Id,TotalPrice,DiscountedPrice,DiscountAmount,Customer_Id)
     VALUES
           (@Id,@TotalPrice,@DiscountedPrice,@DiscountAmount,@Customer_Id)";
                try
                {
                    await connection.ExecuteAsync(queryInsert, order);
                }
                catch (SqlException ex)
                {
                    throw;
                }
            }
            return;
        }

        public Task UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}

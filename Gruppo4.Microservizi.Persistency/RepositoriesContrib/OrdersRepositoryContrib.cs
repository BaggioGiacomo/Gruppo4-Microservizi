using Dapper.Contrib.Extensions;
using Gruppo4.Microservizi.AppCore.Interfaces.Data;
using Gruppo4.Microservizi.AppCore.Models;
using Gruppo4.Microservizi.AppCore.Models.ModelContrib;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.Persistency.Repositories.RepositoriesContrib
{
    public class OrdersRepositoryContrib : IOrderRepository
    {
        public IConfiguration _configuration;
        public readonly string _connectionString = "Server=tcp:its-clod-zanotto.database.windows.net,1433;Initial Catalog=its-clod-zanotto;Persist Security Info=False;User ID=andrea;Password=Vmware1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public OrdersRepositoryContrib(IConfiguration configuration)
        {
            _configuration = configuration;
            //_connectionString=_configuration.GetConnectionString("Db");
        }


        public Task DeleteOrder(Guid id)
        {
            var isSuccess = false;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                isSuccess = connection.Delete(new OrderContrib { Id = id });
            }
            return Task.CompletedTask;


        }

        public async Task<Order> GetOrder(Guid id)
        {
            OrderContrib order;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                order = connection.Get<OrderContrib>(id);
            }
            return null;
        }

        public Task<IEnumerable<Order>> GetOrders()
        {
            throw new NotImplementedException();
        }

        public Task InsertOrder(Order order)
        {
            OrderContrib orderContrib = new OrderContrib
            {
                Id = order.Id,
                Customer_Id = order.Customer_Id,
                DiscountAmount = order.DiscountAmount,
                DiscountedPrice = order.DiscountedPrice,
                TotalPrice = order.TotalPrice,
            };

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var identity = connection.Insert(orderContrib);
            }

            return Task.CompletedTask;
        }

        public Task UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}

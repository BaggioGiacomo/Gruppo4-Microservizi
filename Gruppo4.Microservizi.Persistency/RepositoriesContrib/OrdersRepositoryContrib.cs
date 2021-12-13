using Dapper;
using Dapper.Contrib.Extensions;
using Gruppo4.Microservizi.AppCore.Interfaces.Data;
using Gruppo4.Microservizi.AppCore.Models;
using Gruppo4.Microservizi.AppCore.Models.Entities;
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
        public readonly string _connectionString;
        public OrdersRepositoryContrib(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("AzureDbConnection");
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

        public async Task<OrderContrib> GetOrder(Guid id)
        {
            OrderContrib order;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                order = connection.Get<OrderContrib>(id);
            }
            return order;
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

            string query = @"
INSERT INTO [dbo].[Orders]
           ([Id]
           ,[TotalPrice]
           ,[DiscountedPrice]
           ,[DiscountAmount]
           ,[Customer_Id])
     VALUES
           (@Id,
            @TotalPrice,
            @DiscountedPrice,
            @DiscountAmount,
            @Customer_Id)";


            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, orderContrib);
            }

            return Task.CompletedTask;
        }

        public Task UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }


    }
}

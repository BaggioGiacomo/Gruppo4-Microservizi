using Dapper;
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

namespace Gruppo4.Microservizi.Persistency.RepositoriesContrib
{
    public class OrdersHasProductRepositoryContrib : IOrdersHasProductRepository
    {
        public IConfiguration _configuration;
        public readonly string _connectionString;
        public OrdersHasProductRepositoryContrib(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("AzureDbConnection");
        }



        public Task DeleteOrderFromOrdersHasProduct(Guid idOrders)
        {

            string query = @"DELETE from Orders_has_Product WHERE Orders_Id=@IdOrders";


            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, new { IdOrders = idOrders });
            }

            return Task.CompletedTask;
        }

        public Task DeleteProductFromOrdersHasProduct(Guid idOrders, int idProduct)
        {
            string query = @"DELETE from Orders_has_Product WHERE Product_Id=@IdProduct AND Orders_Id=@IdOrders";


            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, new { IdOrders = idOrders, IdProduct = idProduct });
            }

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<OrdersHasProductContrib>> GetProductByOrderId(Guid idOrders)
        {
            string query = @"SELECT * from Orders_has_Product WHERE Orders_Id=@IdOrders";

            IEnumerable<OrdersHasProductContrib> products;
            using (var connection = new SqlConnection(_connectionString))
            {
                products = connection.Query<OrdersHasProductContrib>(query, new { IdOrders = idOrders }).ToList();
            }

            return products;
        }

        public Task InsertProductHasOrder(OrdersHasProductContrib ordersHasProduct)
        {
            string query = @"
INSERT INTO [dbo].[Orders_has_Product]
           ([Orders_Id]
           ,[Product_Id]
           ,[PriceAtTheMoment]
           ,[Quantity])
     VALUES
           (@Orders_Id,
            @Product_Id,
            @PriceAtTheMoment,
            @Quantity)";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, ordersHasProduct);
            }

            return Task.CompletedTask;
        }

        public Task UpdateProductHasOrder(OrdersHasProductContrib ordersHasProduct)
        {
            throw new NotImplementedException();
        }
    }
}

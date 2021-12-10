using Dapper.Contrib.Extensions;
using Gruppo4.Microservizi.AppCore.Interfaces.Data;
using Gruppo4.Microservizi.AppCore.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.Persistency.RepositoriesContrib
{
    public class ProductRepositoryContrib : IProductRepository
    {
        public IConfiguration _configuration;
        public readonly string _connectionString = "Server=tcp:its-clod-zanotto.database.windows.net,1433;Initial Catalog=its-clod-zanotto;Persist Security Info=False;User ID=andrea;Password=Vmware1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public ProductRepositoryContrib(IConfiguration configuration)
        {
            _configuration = configuration;
            //_connectionString=_configuration.GetConnectionString("Db");
        }

        public async Task RefillQuantity(int id, int quantity)
        {
            var order = GetProductById(id).Result;
            if (order != null)
            {
                order.Quantity = quantity;
                await UpdateProduct(order);
            }
        }

        public Task<int> GetStockQuantity(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> HasEnoughStocked(int id, int quantity)
        {
            Product product = GetProductById(id).Result;
            if(product != null && product.Quantity >  quantity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task DeleteProduct(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var isSuccess = connection.Delete(new Product { Id = id });
            }
            return Task.CompletedTask;
        }

        public Task InsertProduct(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var identity = connection.Insert(product);
            }
            return Task.CompletedTask;
        }

        public Task UpdateProduct(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var isSuccess = connection.Update(product);
            }
            return Task.CompletedTask;
        }

        public async Task<Product> GetProductById(int id)
        {
            Product product; 
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                product = connection.Get<Product>(id);
            }

            return product;
        }
    }
}

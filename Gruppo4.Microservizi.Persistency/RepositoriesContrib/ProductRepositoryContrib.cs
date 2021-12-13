using Dapper.Contrib.Extensions;
using Gruppo4.Microservizi.AppCore.Interfaces.Data;
using Gruppo4.Microservizi.AppCore.Models.ModelContrib;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Gruppo4.Microservizi.Persistency.RepositoriesContrib
{
    public class ProductRepositoryContrib : IProductRepository
    {
        public IConfiguration _configuration;
        public readonly string _connectionString;
        public ProductRepositoryContrib(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("AzureDbConnection");
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
            //Parameter id=productId, quantity=quantity request
            //Check quantity stock product 
            ProductContrib product = GetProductById(id).Result;
            if (product != null && product.Quantity > quantity)
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

                var isSuccess = connection.Delete(new ProductContrib { Id = id });
            }
            return Task.CompletedTask;
        }

        public Task InsertProduct(ProductContrib product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var identity = connection.Insert(product);
            }
            return Task.CompletedTask;
        }

        public Task UpdateProduct(ProductContrib product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var isSuccess = connection.Update(product);
            }
            return Task.CompletedTask;
        }

        public async Task<ProductContrib> GetProductById(int id)
        {
            ProductContrib product;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.Get<ProductContrib>(id);
            }
        }
    }
}

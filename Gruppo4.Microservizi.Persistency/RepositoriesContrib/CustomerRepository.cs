using Dapper.Contrib.Extensions;
using Gruppo4.Microservizi.AppCore.Interfaces.Data;
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
    public class CustomerRepository : ICustomerRepository
    {
        public IConfiguration _configuration;
        public readonly string _connectionString;
        public CustomerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("AzureDbConnection");
        }


        public Task DeleteCustomer(int id)
        {
            var isSuccess = false;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                isSuccess = connection.Delete(new CustomerContrib { Id = id });
            }
            return Task.CompletedTask;
        }

        public async Task<CustomerContrib> GetCustomerById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return connection.Get<CustomerContrib>(id);
            }
        }

        public Task InsertCustomer(CustomerContrib customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var identity = connection.Insert(customer);
            }
            return Task.CompletedTask;
        }

        public Task UpdateCustomer(CustomerContrib customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var isSuccess = connection.Update(customer);
            }
            return Task.CompletedTask;
        }
    }
}

using Dapper;
using Gruppo4.Microservizi.AppCore.Interfaces.Data;
using Gruppo4.Microservizi.AppCore.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
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
        private readonly string _connectionString;

        public OrdersRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("LocalDB");
        }

        public Task DeleteOrder(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrder(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetOrders()
        {
            throw new NotImplementedException();
        }

        public Task InsertOrder(Order order)
        {

            if (order != null)
            {
                var cs = _configuration.GetConnectionString(_connectionString);
                using var connection = new SqlConnection(cs);
                const string queryInsert = @"
INSERT INTO Ordine
           (Id,PrezzoTot,PrezzoScontato,Sconto,Cliente_Id)
     VALUES
           (@Id,@PrezzoTot,@PrezzoScontato,@Sconto,@Cliente_Id)";
                connection.Execute(queryInsert, order);
                
            }
            return null;
        }

    public Task UpdateOrder(Order order)
    {
        throw new NotImplementedException();
    }
}
}

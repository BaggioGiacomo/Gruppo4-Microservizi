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
        private readonly string _connectionString = "";
        public OrdersRepository()
        {

        }

        public OrdersRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task DeleteOrder(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrder(Guid id)
        {
            return null;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            using var connection = new SqlConnection(_connectionString);

             List<Order> list = new List<Order>();

             const string querySelectAll = "SELECT * FROM Ordine";
             
            return await connection.QueryAsync<Order>(querySelectAll);
        }

        public Task InsertOrder(Order order)
        {

            if (order != null)
            {
                using var connection = new MySqlConnection(_connectionString);
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

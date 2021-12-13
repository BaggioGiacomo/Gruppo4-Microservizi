using Dapper;
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

namespace Gruppo4.Microservizi.Persistency.RepositoriesContrib
{
    public class CouponHasOrdersRepositoryContrib : ICouponHasOrdersRepository
    {
        public IConfiguration _configuration;
        public readonly string _connectionString;

        public CouponHasOrdersRepositoryContrib()
        {

        }

        public CouponHasOrdersRepositoryContrib(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("AzureDbConnection");

        }

        public Task DeleteCouponFromOrder(Guid idOrders)
        {

            string query = @"DELETE from Coupon_has_Orders WHERE Orders_Id=@IdOrders";


            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(query, new { IdOrders = idOrders });
            }

            return Task.CompletedTask;
        }

        public async Task<IEnumerable<CouponHasOrdersContrib>> GetCouponFromOrder(Guid idOrders)
        {
            string query = @"SELECT * from Coupon_has_Orders WHERE Orders_Id=@IdOrders";

            IEnumerable<CouponHasOrdersContrib> coupons;
            using (var connection = new SqlConnection(_connectionString))
            {
                coupons = connection.Query<CouponHasOrdersContrib>(query, new { IdOrders = idOrders });
            }

            return coupons;
        }

        public Task InsertCouponHasOrder(CouponHasOrdersContrib couponHasOrder)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var identity = connection.Insert(couponHasOrder);
            }

            return Task.CompletedTask;
        }

        public Task UpdateCouponHasOrder(CouponHasOrdersContrib couponHasOrder)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var isSuccess = connection.Update(couponHasOrder);
            }

            return Task.CompletedTask;
        }
    }
}

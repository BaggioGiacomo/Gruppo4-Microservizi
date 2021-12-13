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
    public class CouponsRepositoryContrib: ICouponRepository
    {
        public IConfiguration _configuration;
        public readonly string _connectionString = "Server=tcp:its-clod-zanotto.database.windows.net,1433;Initial Catalog=its-clod-zanotto;Persist Security Info=False;User ID=andrea;Password=Vmware1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public CouponsRepositoryContrib(IConfiguration configuration)
        {
            _configuration = configuration;
            //_connectionString=_configuration.GetConnectionString("Db");
        }

        public async Task<Coupon> GetCoupon(string code)
        {
            Coupon coupon;
            CouponContrib couponDb;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                couponDb = connection.Get<CouponContrib>(code);
            }

            coupon = new Coupon
            {
                Code = code,
                DiscountInfo = new DiscountInfo
                {
                    DiscountAbsolute = couponDb.DiscountAbsolute,
                    DiscountPercentage = couponDb.DiscountPercentage
                }
            };

            return coupon;
        }
    }
}

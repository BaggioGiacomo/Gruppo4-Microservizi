using Dapper.Contrib.Extensions;

namespace Gruppo4.Microservizi.AppCore.Models.ModelContrib
{
    [Table("Coupon_has_Orders")]
    public class CouponHasOrdersContrib
    {

        public CouponHasOrdersContrib()
        {

        }

        [ExplicitKey]
        public Guid Orders_Id { get; set; }
        [ExplicitKey]
        public string Coupon_Id { get; set; }



    }
}

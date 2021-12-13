using Dapper.Contrib.Extensions;

namespace Gruppo4.Microservizi.AppCore.Models.ModelContrib
{
    [Table("Coupon")]
    public class CouponContrib
    {
        [Key]
        public string Code { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAbsolute { get; set; }
    }
}

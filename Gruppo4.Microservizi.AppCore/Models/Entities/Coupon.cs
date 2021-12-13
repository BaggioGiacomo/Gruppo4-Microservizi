using Dapper.Contrib.Extensions;

namespace Gruppo4.Microservizi.AppCore.Models.Entities
{
    [Table("Coupon")]
    public class Coupon
    {
        [Key]
        public string Code { get; set; }
        public DiscountInfo DiscountInfo { get; set; }

    }

    public class DiscountInfo
    {
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAbsolute { get; set; }
    }
}

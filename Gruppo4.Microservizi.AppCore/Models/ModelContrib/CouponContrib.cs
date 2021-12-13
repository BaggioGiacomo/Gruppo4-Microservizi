using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

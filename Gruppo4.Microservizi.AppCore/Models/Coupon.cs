using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.AppCore.Models
{
    public class Coupon
    {
        public string Code { get; set; }
        public DiscountInfo DiscountInfo { get; set; }

    }

    public class DiscountInfo
    {
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAbsolute { get; set; }
    }
}

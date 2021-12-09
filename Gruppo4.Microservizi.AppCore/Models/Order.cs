using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.AppCore.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int CustomerId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountedPrice { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
        public IList<Coupon> Coupons { get; set; } = new List<Coupon>();
    }
}

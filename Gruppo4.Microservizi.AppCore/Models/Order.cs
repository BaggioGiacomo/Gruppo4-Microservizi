using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.AppCore.Models
{
    public class Order
    {
        public Order(string id, int customerId, decimal totalPrice, decimal discountAmount, decimal discountedPrice, IList<Product> products, IList<Coupon> coupons)
        {
            Id = Guid.Parse(id);
            Customer_Id = customerId;
            TotalPrice = totalPrice;
            DiscountAmount = discountAmount;
            DiscountedPrice = discountedPrice;
            Products = products;
            Coupons = coupons;
        }
        public Order()
        {
            Id = new Guid();
        }

        public Guid Id { get; }
        public int Customer_Id { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountedPrice { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
        public IList<Coupon> Coupons { get; set; } = new List<Coupon>();

        
    }
}

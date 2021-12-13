using Gruppo4.Microservizi.AppCore.Models.ModelContrib;

namespace Gruppo4.Microservizi.AppCore.Models.Entities
{
    public class Order
    {
        public Order(string id, int customerId, decimal totalPrice, decimal discountAmount, decimal discountedPrice, IList<ProductContrib> products, IList<Coupon> coupons)
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
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public int Customer_Id { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountedPrice { get; set; }
        public IList<ProductContrib> Products { get; set; } = new List<ProductContrib>();
        public IList<Coupon> Coupons { get; set; } = new List<Coupon>();


    }
}

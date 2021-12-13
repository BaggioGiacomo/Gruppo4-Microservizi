using Dapper.Contrib.Extensions;

namespace Gruppo4.Microservizi.AppCore.Models.ModelContrib
{
    [Table("Orders")]
    public class OrderContrib
    {
        public OrderContrib(string id, int customerId, decimal totalPrice, decimal discountAmount, decimal discountedPrice)
        {
            Id = Guid.Parse(id);
            Customer_Id = customerId;
            TotalPrice = totalPrice;
            DiscountAmount = discountAmount;
            DiscountedPrice = discountedPrice;
        }
        public OrderContrib()
        {
            Id = new Guid();
        }

        [Key]
        public Guid Id { get; set; }
        public int Customer_Id { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountedPrice { get; set; }
    }
}

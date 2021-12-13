using Gruppo4MicroserviziDTO.Models;

namespace Gruppo4MicroserviziDTO.DTOs
{
    public class UpdatedOrderEvent
    {
        public Guid Id { get; set; }
        public int IdCliente { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountedPrice { get; set; }

        public IEnumerable<ProductInOrder> Products { get; set; }
    }
}

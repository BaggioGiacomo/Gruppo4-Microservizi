using System.ComponentModel.DataAnnotations;

namespace Gruppo4.Microservizi.WebApi.DTOs
{
    public class OrderInsertDTO
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public IEnumerable<ProductInOrder> Products { get; set; }
        [Required]
        public IEnumerable<string> Coupons { get; set; }
    }

    public class ProductInOrder
    {
        public int ProductId { get; set; }
        public int OrderedQuantity { get; set; }
    }
}

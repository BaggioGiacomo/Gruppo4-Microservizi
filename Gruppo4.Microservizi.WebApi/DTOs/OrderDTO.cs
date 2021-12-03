using System.ComponentModel.DataAnnotations;

namespace Gruppo4.Microservizi.WebApi.DTOs
{
    public class OrderDTO
    {
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public decimal DiscountAmount { get; set; }
        [Required]
        public decimal DiscountedPrice { get; set; }
        [Required]
        public IEnumerable<ProductInOrder> Products { get; set; }
    }

    public class ProductInOrder
    {
        public int ProductId { get; set; }
        public int OrderedQuantity { get; set; }
    }
}

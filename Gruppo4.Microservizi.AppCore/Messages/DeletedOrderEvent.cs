using Gruppo4MicroserviziDTO.Models;

namespace Gruppo4MicroserviziDTO.DTOs
{
    public class DeletedOrderEvent
    {
        public Guid Id { get; set; }
        public IList<ProductInOrder> Products { get; set; } = new List<ProductInOrder>();
    }
}

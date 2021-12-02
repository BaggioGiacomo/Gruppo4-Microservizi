using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.AppCore.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public int IdCliente { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal DiscountedPrice { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}

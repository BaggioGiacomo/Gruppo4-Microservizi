using Dapper.Contrib.Extensions;

namespace Gruppo4.Microservizi.AppCore.Models.ModelContrib
{
    [Table("Product")]
    public class ProductContrib
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}

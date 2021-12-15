using Gruppo4.Microservizi.AppCore.Models.ModelContrib;
using System.Runtime.Serialization;

namespace Gruppo4.Microservizi.AppCore.Exceptions
{
    public class NotEnoughStockException : Exception
    {
        public IEnumerable<ProductContrib> Products { get; set; }
        public NotEnoughStockException(IEnumerable<ProductContrib> products)
        {
            Products = products;
        }

        public NotEnoughStockException(string? message, IEnumerable<ProductContrib> products) : base(message)
        {
            Products = products;
        }

        public NotEnoughStockException(string? message, Exception? innerException, IEnumerable<ProductContrib> products) : base(message, innerException)
        {
            Products = products;
        }

        protected NotEnoughStockException(SerializationInfo info, StreamingContext context, IEnumerable<ProductContrib> products) : base(info, context)
        {
            Products = products;
        }
    }
}

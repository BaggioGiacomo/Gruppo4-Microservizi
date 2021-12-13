using System.Runtime.Serialization;

namespace Gruppo4.Microservizi.AppCore.Exceptions
{
    public class NotEnoughStockException : ApplicationException
    {
        public NotEnoughStockException()
        {
        }

        public NotEnoughStockException(string? message) : base(message)
        {
        }

        public NotEnoughStockException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotEnoughStockException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

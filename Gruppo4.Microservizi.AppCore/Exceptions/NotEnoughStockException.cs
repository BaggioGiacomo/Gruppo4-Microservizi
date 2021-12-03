using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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

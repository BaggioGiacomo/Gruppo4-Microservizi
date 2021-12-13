using Gruppo4.Microservizi.AppCore.Models.Entities;
using System.Runtime.Serialization;

namespace Gruppo4.Microservizi.AppCore.Exceptions
{
    public class InvalidCouponException : ApplicationException
    {
        public InvalidCouponException()
        {
        }

        public InvalidCouponException(string? message) : base(message)
        {
        }

        public InvalidCouponException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidCouponException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.AppCore.Exceptions
{
    public class InvalidCustomerIdException : ApplicationException
    {
        public InvalidCustomerIdException()
        {
        }

        public InvalidCustomerIdException(string? message) : base(message)
        {
        }

        public InvalidCustomerIdException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidCustomerIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

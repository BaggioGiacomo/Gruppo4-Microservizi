using System.Runtime.Serialization;

namespace Gruppo4.Microservizi.AppCore.Exceptions
{
    public class InvalidCustomerIdException : Exception
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

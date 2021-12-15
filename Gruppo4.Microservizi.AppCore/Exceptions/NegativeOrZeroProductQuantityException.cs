using Gruppo4.Microservizi.AppCore.Models.ModelContrib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.AppCore.Exceptions
{
    public class NegativeOrZeroProductQuantityException : Exception
    {
        public ProductContrib Product { get; set; }

        public NegativeOrZeroProductQuantityException(ProductContrib product)
        {
            Product = product;
        }

        public NegativeOrZeroProductQuantityException(string? message, ProductContrib product) : base(message)
        {
            Product = product;
        }

        public NegativeOrZeroProductQuantityException(string? message, Exception? innerException, ProductContrib product) : base(message, innerException)
        {
            Product = product;
        }

        protected NegativeOrZeroProductQuantityException(SerializationInfo info, StreamingContext context, ProductContrib product) : base(info, context)
        {
            Product = product;
        }
    }
}

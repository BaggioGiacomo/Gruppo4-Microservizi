using Gruppo4.Microservizi.AppCore.Models.ModelContrib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.AppCore.Exceptions
{
    public class NegativeProductQuantityExeception : Exception
    {
        public ProductContrib Product { get; set; }

        public NegativeProductQuantityExeception(ProductContrib product)
        {
            Product = product;
        }

        public NegativeProductQuantityExeception(string? message, ProductContrib product) : base(message)
        {
            Product = product;
        }

        public NegativeProductQuantityExeception(string? message, Exception? innerException, ProductContrib product) : base(message, innerException)
        {
            Product = product;
        }

        protected NegativeProductQuantityExeception(SerializationInfo info, StreamingContext context, ProductContrib product) : base(info, context)
        {
            Product = product;
        }
    }
}

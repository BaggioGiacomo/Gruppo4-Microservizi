using Gruppo4.Microservizi.AppCore.Models.Entities;
using System.Runtime.Serialization;

namespace Gruppo4.Microservizi.AppCore.Exceptions
{
    public class InvalidCouponException : Exception
    {
        public IEnumerable<Coupon> Coupons { get; set; }        

        public InvalidCouponException(IEnumerable<Coupon> coupons)
        {
            Coupons = coupons;
        }

        public InvalidCouponException(string? message, IEnumerable<Coupon> coupons) : base(message)
        {
            Coupons = coupons;
        }

        public InvalidCouponException(string? message, Exception? innerException, IEnumerable<Coupon> coupons) : base(message, innerException)
        {
            Coupons = coupons;
        }

        protected InvalidCouponException(SerializationInfo info, StreamingContext context, IEnumerable<Coupon> coupons) : base(info, context)
        {
            Coupons = coupons;
        }
    }
}

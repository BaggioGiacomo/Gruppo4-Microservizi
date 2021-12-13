using Gruppo4.Microservizi.AppCore.Models.Entities;

namespace Gruppo4.Microservizi.AppCore.Interfaces.Services
{
    public interface ICouponService
    {
        public Task<Coupon> GetCoupon(string code);
    }
}

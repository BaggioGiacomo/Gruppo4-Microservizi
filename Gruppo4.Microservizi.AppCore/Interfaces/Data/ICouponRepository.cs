using Gruppo4.Microservizi.AppCore.Models.Entities;


namespace Gruppo4.Microservizi.AppCore.Interfaces.Data
{
    public interface ICouponRepository
    {
        public Task<Coupon> GetCoupon(string code);
    }
}

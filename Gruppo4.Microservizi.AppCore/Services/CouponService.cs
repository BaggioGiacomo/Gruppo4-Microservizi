using Gruppo4.Microservizi.AppCore.Interfaces.Data;
using Gruppo4.Microservizi.AppCore.Interfaces.Services;
using Gruppo4.Microservizi.AppCore.Models.Entities;

namespace Gruppo4.Microservizi.AppCore.Services
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;

        public CouponService()
        {

        }

        public CouponService(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public async Task<Coupon> GetCoupon(string code)
        {
            return await _couponRepository.GetCoupon(code);
        }
    }
}

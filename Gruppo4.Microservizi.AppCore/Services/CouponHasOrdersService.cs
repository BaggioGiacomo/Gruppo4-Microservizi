using Gruppo4.Microservizi.AppCore.Interfaces.Data;
using Gruppo4.Microservizi.AppCore.Interfaces.Services;
using Gruppo4.Microservizi.AppCore.Models.ModelContrib;

namespace Gruppo4.Microservizi.AppCore.Services
{
    public class CouponHasOrdersService : ICouponHasOrdersService
    {

        private readonly ICouponHasOrdersRepository _couponHasOrdersRepository;

        public CouponHasOrdersService()
        {

        }

        public CouponHasOrdersService(ICouponHasOrdersRepository couponHasOrdersRepository)
        {
            _couponHasOrdersRepository = couponHasOrdersRepository;
        }

        public async Task DeleteCouponFromOrder(Guid idOrders)
        {
            await _couponHasOrdersRepository.DeleteCouponFromOrder(idOrders);
        }

        public async Task<IEnumerable<CouponHasOrdersContrib>> GetCouponsHasOrder(Guid idOrders)
        {
            return await _couponHasOrdersRepository.GetCouponFromOrder(idOrders);
        }

        public async Task InsertCouponHasOrder(CouponHasOrdersContrib couponHasOrder)
        {
            await _couponHasOrdersRepository.InsertCouponHasOrder(couponHasOrder);
        }
        public async Task UpdateCouponHasOrder(CouponHasOrdersContrib couponHasOrder)
        {
            await _couponHasOrdersRepository.UpdateCouponHasOrder(couponHasOrder);
        }
    }
}


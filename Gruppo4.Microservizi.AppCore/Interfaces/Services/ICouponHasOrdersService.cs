using Gruppo4.Microservizi.AppCore.Models.ModelContrib;

namespace Gruppo4.Microservizi.AppCore.Interfaces.Services
{
    public interface ICouponHasOrdersService
    {
        public Task<IEnumerable<CouponHasOrdersContrib>> GetCouponsHasOrder(Guid idOrders);
        public Task InsertCouponHasOrder(CouponHasOrdersContrib couponHasOrder);
        public Task UpdateCouponHasOrder(CouponHasOrdersContrib couponHasOrder);
        public Task DeleteCouponFromOrder(Guid idOrders);
    }
}

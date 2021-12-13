using Gruppo4.Microservizi.AppCore.Models.ModelContrib;

namespace Gruppo4.Microservizi.AppCore.Interfaces.Data
{
    public interface ICouponHasOrdersRepository
    {
        public Task<IEnumerable<CouponHasOrdersContrib>> GetCouponFromOrder(Guid idOrders);
        public Task InsertCouponHasOrder(CouponHasOrdersContrib couponHasOrder);
        public Task UpdateCouponHasOrder(CouponHasOrdersContrib couponHasOrder);
        public Task DeleteCouponFromOrder(Guid idOrders);
    }
}

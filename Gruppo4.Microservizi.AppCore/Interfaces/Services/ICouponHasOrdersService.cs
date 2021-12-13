using Gruppo4.Microservizi.AppCore.Models;
using Gruppo4.Microservizi.AppCore.Models.ModelContrib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

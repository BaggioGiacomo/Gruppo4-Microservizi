using Gruppo4.Microservizi.AppCore.Models;
using Gruppo4.Microservizi.AppCore.Models.ModelContrib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.AppCore.Interfaces.Data
{
    public interface IOrdersHasProductRepository
    {
        public Task<IEnumerable<OrdersHasProductContrib>> GetProductByOrderId(Guid idOrders);
        public Task InsertProductHasOrder(OrdersHasProductContrib ordersHasProduct);
        public Task UpdateProductHasOrder(OrdersHasProductContrib ordersHasProduct);
        public Task DeleteOrderFromOrdersHasProduct(Guid idOrders);
        public Task DeleteProductFromOrdersHasProduct(Guid idOrders, int idProduct);
    }
}

using Gruppo4.Microservizi.AppCore.Models.ModelContrib;

namespace Gruppo4.Microservizi.AppCore.Interfaces.Services
{
    public interface IOrdersHasProductService
    {

        public Task<IEnumerable<OrdersHasProductContrib>> GetProductByOrderId(Guid idOrders);
        public Task InsertProductHasOrder(OrdersHasProductContrib ordersHasProduct);
        public Task UpdateProductHasOrder(OrdersHasProductContrib ordersHasProduct);
        public Task DeleteOrderFromOrdersHasProduct(Guid idOrders);
        public Task DeleteProductFromOrdersHasProduct(Guid idOrders, int idProduct);

    }
}

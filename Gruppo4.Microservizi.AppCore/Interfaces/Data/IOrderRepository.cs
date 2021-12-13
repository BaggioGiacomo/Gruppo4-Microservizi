using Gruppo4.Microservizi.AppCore.Models.Entities;
using Gruppo4.Microservizi.AppCore.Models.ModelContrib;

namespace Gruppo4.Microservizi.AppCore.Interfaces.Data
{
    public interface IOrderRepository
    {
        public Task InsertOrder(Order order);
        public Task UpdateOrder(Order order);
        public Task DeleteOrder(Guid id);
        public Task<OrderContrib> GetOrder(Guid id);
        public Task<IEnumerable<OrderContrib>> GetOrders();

    }
}

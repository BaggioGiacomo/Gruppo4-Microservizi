using Gruppo4.Microservizi.AppCore.Models;
using Gruppo4.Microservizi.AppCore.Models.ModelContrib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.AppCore.Interfaces.Data
{
    public interface IOrderRepository
    {
        public Task InsertOrder(Order order);
        public Task UpdateOrder(Order order);
        public Task DeleteOrder(Guid id);
        public Task<OrderContrib> GetOrder(Guid id);
        public Task<IEnumerable<Order>> GetOrders();

    }
}

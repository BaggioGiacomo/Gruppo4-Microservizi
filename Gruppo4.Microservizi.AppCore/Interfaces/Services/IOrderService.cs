using Gruppo4.Microservizi.AppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.AppCore.Interfaces.Services
{
    public interface IOrderService
    {
        public Task InsertOrder(Order order);
        public Task UpdateOrder(Order order);
        public Task DeleteOrder(Guid id);
        public Task<Order> GetOrder(Guid id);
        public Task<IEnumerable<Order>> GetOrders();
    }
}

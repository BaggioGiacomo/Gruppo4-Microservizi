using Gruppo4.Microservizi.AppCore.Exceptions;
using Gruppo4.Microservizi.AppCore.Interfaces.Data;
using Gruppo4.Microservizi.AppCore.Interfaces.Services;
using Gruppo4.Microservizi.AppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.AppCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;

        public OrderService(IOrderRepository orderRepository, IProductService productService, ICustomerService customerService)
        {
            _orderRepository = orderRepository;
            _productService = productService;
            _customerService = customerService;
        }

        public async Task DeleteOrder(Guid id)
        {
            await _orderRepository.DeleteOrder(id);
        }

        public async Task<Order> GetOrder(Guid id)
        {
            return await _orderRepository.GetOrder(id); 
        }

        public async Task InsertOrder(Order order)
        {
            var stockChecks = new List<Task<bool>>();
            foreach (var product in order.Products)
            {
                stockChecks.Add(_productService.HasEnoughStocked(product.Id, product.Quantity));
            }

            var stockChecksResults = await Task.WhenAll(stockChecks);

            if (!(stockChecksResults.All(v => v)))
            {
                throw new NotEnoughStockException("Some products are missing.");
            }
            
            

            await _orderRepository.InsertOrder(order);
        }

        public async Task UpdateOrder(Order order)
        {
            await _orderRepository.UpdateOrder(order);
        }
    }
}

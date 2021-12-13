using Gruppo4.Microservizi.AppCore.Interfaces.Data;
using Gruppo4.Microservizi.AppCore.Interfaces.Services;
using Gruppo4.Microservizi.AppCore.Models;
using Gruppo4.Microservizi.AppCore.Models.ModelContrib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.AppCore.Services
{
    public class OrdersHasProductService : IOrdersHasProductService
    {
        private readonly IOrdersHasProductRepository _ordersHasProductService;

        public OrdersHasProductService()
        {

        }

        public OrdersHasProductService(IOrdersHasProductRepository ordersHasProductRepository)
        {
            _ordersHasProductService = ordersHasProductRepository;
        }

        public async Task DeleteOrderFromOrdersHasProduct(Guid idOrders)
        {
            await _ordersHasProductService.DeleteOrderFromOrdersHasProduct(idOrders);   
        }

        public async Task DeleteProductFromOrdersHasProduct(Guid idOrders, int idProduct)
        {
            await _ordersHasProductService.DeleteProductFromOrdersHasProduct(idOrders, idProduct);  
        }

        public async Task<IEnumerable<OrdersHasProductContrib>> GetProductByOrderId(Guid idOrders)
        {
           return await _ordersHasProductService.GetProductByOrderId(idOrders); 
        }

        public async Task InsertProductHasOrder(OrdersHasProductContrib ordersHasProduct)
        {
            await _ordersHasProductService.InsertProductHasOrder(ordersHasProduct);
        }

        public async Task UpdateProductHasOrder(OrdersHasProductContrib ordersHasProduct)
        {
            await _ordersHasProductService.UpdateProductHasOrder(ordersHasProduct); 
        }
    }
}

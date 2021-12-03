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
        private readonly ICouponService _couponService;

        public OrderService(IOrderRepository orderRepository, IProductService productService, ICustomerService customerService, ICouponService couponService)
        {
            _orderRepository = orderRepository;
            _productService = productService;
            _customerService = customerService;
            _couponService = couponService;
        }

        public async Task DeleteOrder(Guid id)
        {
            await _orderRepository.DeleteOrder(id);
        }

        public async Task<Order> GetOrder(Guid id)
        {
            return await _orderRepository.GetOrder(id); 
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _orderRepository.GetOrders();
        }

        public async Task InsertOrder(Order order)
        {
            await CheckStock(order);
            await _orderRepository.InsertOrder(order);
        }       

        public async Task UpdateOrder(Order order)
        {
            await CheckStock(order);
            await _orderRepository.UpdateOrder(order);
        }

        private async Task CheckStock(Order order)
        {
            var stockChecks = new List<Task<bool>>();
            foreach (var product in order.Products)
            {
                stockChecks.Add(_productService.HasEnoughStocked(product.Id, product.Quantity));
            }

            var stockChecksResults = await Task.WhenAll(stockChecks);

            if (!(stockChecksResults.All(v => v)))
            {
                // TODO: ritornare con l'eccezione la lista dei prodotti che non sono in stock
                throw new NotEnoughStockException("Some products are missing.");
            }
        }
        private async Task CheckCoupons(Order order)
        {
            var couponChecks = new List<Task<Coupon>>();
            foreach (var coupon in order.Coupons)
            {
                couponChecks.Add(_couponService.GetCoupon(coupon.Code));
            }

            var couponCheckResults = await Task.WhenAll(couponChecks);

            if(!(couponCheckResults.All(c => c is not null)))
            {
                // TODO: ritornare con l'eccezione la lista dei codici coupon non validi
                throw new InvalidCouponException("Some coupons are invalid.");
            }
        }
        private async Task CheckCustomer(Order order)
        {
            var customer = await _customerService.GetCustomerById(order.CustomerId);
            if(customer is null)
            {
                throw new InvalidCustomerIdException($"Customer {order.CustomerId} does not exist.");
            }
        }
        private async Task Validate(Order order)
        {
            await CheckCoupons(order);
            await CheckCustomer(order);
            await CheckStock(order);
        }
    }
}

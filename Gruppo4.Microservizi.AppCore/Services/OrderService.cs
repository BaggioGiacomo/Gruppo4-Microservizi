﻿using Gruppo4.Microservizi.AppCore.Exceptions;
using Gruppo4.Microservizi.AppCore.Interfaces.Data;
using Gruppo4.Microservizi.AppCore.Interfaces.Services;
using Gruppo4.Microservizi.AppCore.Models.Entities;
using Gruppo4.Microservizi.AppCore.Models.ModelContrib;
using System.Text.Json;

namespace Gruppo4.Microservizi.AppCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly ICouponService _couponService;
        private readonly ICouponHasOrdersService _couponHasOrdersService;
        private readonly IOrdersHasProductService _ordersHasProductService;


        public OrderService(IOrderRepository orderRepository, IProductService productService, ICustomerService customerService, ICouponService couponService, ICouponHasOrdersService couponHasOrdersService, IOrdersHasProductService ordersHasProductService)
        {
            _orderRepository = orderRepository;
            _productService = productService;
            _customerService = customerService;
            _couponService = couponService;
            _couponHasOrdersService = couponHasOrdersService;
            _ordersHasProductService = ordersHasProductService;
        }

        public async Task DeleteOrder(Guid id)
        {

            await _ordersHasProductService.DeleteOrderFromOrdersHasProduct(id);
            await _couponHasOrdersService.DeleteCouponFromOrder(id);
            await _orderRepository.DeleteOrder(id);
        }

        public async Task<Order> GetOrder(Guid id)
        {
            Order order;
            OrderContrib orderContrib = await _orderRepository.GetOrder(id);
            order = new Order
            {
                Id = id,
                Customer_Id = orderContrib.Customer_Id,
                DiscountAmount = orderContrib.DiscountAmount,
                TotalPrice = orderContrib.TotalPrice,
                DiscountedPrice = orderContrib.DiscountedPrice,
                //Controllare istanza liste
                Coupons = new List<Coupon>(),
                Products = new List<ProductContrib>()
            };

            var tempListProduct = await _ordersHasProductService.GetProductByOrderId(id);
            foreach (var product in tempListProduct)
            {
                ProductContrib tempProduct = await _productService.GetProductById(product.Product_Id);
                order.Products.Add(new ProductContrib { Id = product.Product_Id, Name = tempProduct.Name, Price = product.PriceAtTheMoment, Quantity = product.Quantity });
            }

            var tempListCoupon = await _couponHasOrdersService.GetCouponsHasOrder(id);
            foreach (var coupon in tempListCoupon)
            {
                Coupon tempCoupon = await _couponService.GetCoupon(coupon.Coupon_Id);
                order.Coupons.Add(new Coupon { Code = coupon.Coupon_Id, DiscountInfo = new DiscountInfo { DiscountAbsolute = tempCoupon.DiscountInfo.DiscountAbsolute, DiscountPercentage = tempCoupon.DiscountInfo.DiscountPercentage } });
            }

            return order;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            var ordersToReturn = new List<Order>();

            var orders = await _orderRepository.GetOrders();

            foreach (var order in orders)
            {
                Order orderTemp;
                OrderContrib orderContrib = await _orderRepository.GetOrder(order.Id);
                orderTemp = new Order
                {
                    Id = order.Id,
                    Customer_Id = orderContrib.Customer_Id,
                    DiscountAmount = orderContrib.DiscountAmount,
                    TotalPrice = orderContrib.TotalPrice,
                    DiscountedPrice = orderContrib.DiscountedPrice,
                    //Controllare istanza liste
                    Coupons = new List<Coupon>(),
                    Products = new List<ProductContrib>()
                };

                var tempListProduct = await _ordersHasProductService.GetProductByOrderId(order.Id);
                foreach (var product in tempListProduct)
                {
                    ProductContrib tempProduct = await _productService.GetProductById(product.Product_Id);
                    orderTemp.Products.Add(new ProductContrib { Id = product.Product_Id, Name = tempProduct.Name, Price = product.PriceAtTheMoment, Quantity = product.Quantity });
                }

                var tempListCoupon = await _couponHasOrdersService.GetCouponsHasOrder(order.Id);
                foreach (var coupon in tempListCoupon)
                {
                    Coupon tempCoupon = await _couponService.GetCoupon(coupon.Coupon_Id);
                    orderTemp.Coupons.Add(new Coupon { Code = coupon.Coupon_Id, DiscountInfo = new DiscountInfo { DiscountAbsolute = tempCoupon.DiscountInfo.DiscountAbsolute, DiscountPercentage = tempCoupon.DiscountInfo.DiscountPercentage } });
                }
                ordersToReturn.Add(orderTemp);
            }
            return ordersToReturn;
        }

        public async Task InsertOrder(Order order)
        {

            //Check stock of the products in the order
            await Validate(order);
            //Total Price
            order.TotalPrice = await CalculateTotal(order);
            var discount = await CalculateDiscount(order);
            order.DiscountedPrice = (order.TotalPrice - discount.DiscountAbsolute) * (1 - discount.DiscountPercentage / 100);
            order.DiscountAmount = order.TotalPrice - order.DiscountedPrice;

            await _orderRepository.InsertOrder(order);
            foreach (var coupon in order.Coupons)
            {
                await _couponHasOrdersService.InsertCouponHasOrder(new CouponHasOrdersContrib { Orders_Id = order.Id, Coupon_Id = coupon.Code });
            }
            foreach (var product in order.Products)
            {
                var tempProduct = await _productService.GetProductById(product.Id);
                tempProduct.Quantity = tempProduct.Quantity - product.Quantity;
                await _productService.UpdateProduct(tempProduct);
                await _ordersHasProductService.InsertProductHasOrder(new OrdersHasProductContrib { Orders_Id = order.Id, Product_Id = product.Id, PriceAtTheMoment = tempProduct.Price, Quantity = product.Quantity });
            }



        }

        public async Task UpdateOrder(Order order)
        {
            await CheckStock(order);
            await _orderRepository.UpdateOrder(order);
        }

        private async Task CheckStock(Order order)
        {
            List<ProductContrib> productsNotInStock = new List<ProductContrib>();
            foreach (var product in order.Products)
            {
                if (product.Quantity > 0)
                {
                    if (!(await _productService.HasEnoughStocked(product.Id, product.Quantity)))
                    {
                        productsNotInStock.Add(product);
                    }
                }
                else
                {
                    throw new NegativeOrZeroProductQuantityException("Negative Or Zero product quantity inserted", product);
                }

            }

            if (productsNotInStock.Any())
            {
                throw new NotEnoughStockException("Some products are not in stock.", productsNotInStock);
            }

        }
        private async Task CheckCoupons(Order order)
        {
            List<Coupon> invalidCoupons = new List<Coupon>();
            foreach (var coupon in order.Coupons)
            {
                Coupon temp = await _couponService.GetCoupon(coupon.Code);
                if (temp == null)
                {
                    invalidCoupons.Add(new Coupon { Code = coupon.Code });
                }
            }

            if (invalidCoupons.Any())
            {
                throw new InvalidCouponException("Some coupon codes are invalid.", invalidCoupons);
            }

        }
        private async Task CheckCustomer(Order order)
        {
            var customer = await _customerService.GetCustomerById(order.Customer_Id);
            if (customer is null)
            {
                throw new InvalidCustomerIdException($"Customer {order.Customer_Id} does not exist.");
            }
        }
        private async Task Validate(Order order)
        {
            await CheckCoupons(order);
            await CheckCustomer(order);
            await CheckStock(order);
        }
        private async Task<decimal> CalculateTotal(Order order)
        {
            decimal total = 0;
            foreach (var product in order.Products)
            {
                var productInfo = await _productService.GetProductById(product.Id);
                total += productInfo.Price * product.Quantity;
            }
            return total;
        }
        private async Task<DiscountInfo> CalculateDiscount(Order order)
        {
            var discount = new DiscountInfo();

            foreach (var coupon in order.Coupons)
            {
                var couponInfo = await _couponService.GetCoupon(coupon.Code);
                discount.DiscountAbsolute += couponInfo.DiscountInfo.DiscountAbsolute;
                discount.DiscountPercentage += couponInfo.DiscountInfo.DiscountPercentage;
            }

            return discount;
        }
    }
}

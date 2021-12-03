﻿using Gruppo4.Microservizi.AppCore.Exceptions;
using Gruppo4.Microservizi.AppCore.Interfaces.Services;
using Gruppo4.Microservizi.AppCore.Models;
using Gruppo4.Microservizi.WebApi.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gruppo4.Microservizi.WebApi.Controllers
{
    [Route("api/v1/[controller]/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public OrdersController(IOrderService orderService, IConfiguration configuration)
        {
            _orderService = orderService;
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("LocalDB");
        }

        [Route("{guid}")]
        public async Task<IActionResult> GetOrderAsync(Guid guid)
        {
            var order = await _orderService.GetOrder(guid);
            if(order is null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        [HttpPut]
        public async Task<IActionResult> InsertOrderAsync(OrderInsertDTO order)
        {
            var newOrder = new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = order.CustomerId,
                Products = new List<Product>(),
                Coupons = new List<Coupon>()
            };

            foreach (var product in order.Products)
            {
                newOrder.Products.Add(new Product
                {
                    Id = product.ProductId,
                    Quantity = product.OrderedQuantity
                });
            }
            foreach (var coupon in order.Coupons)
            {
                newOrder.Coupons.Add(new Coupon
                {
                    Code = coupon
                });
            }

            try
            {
                await _orderService.InsertOrder(newOrder);
            }
            catch (InvalidCouponException e)
            {
                return BadRequest(e.Message);
            }
            catch (InvalidCustomerIdException e)
            {
                return BadRequest(e.Message);
            }
            catch(NotEnoughStockException e)
            {
                return BadRequest(e.Message);
            }
            catch { throw; }

            var createdOrder = await _orderService.GetOrder(newOrder.Id);

            return CreatedAtAction(nameof(GetOrderAsync), createdOrder);
        }
    }
}
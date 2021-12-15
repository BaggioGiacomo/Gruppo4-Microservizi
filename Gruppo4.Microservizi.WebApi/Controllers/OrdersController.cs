using Gruppo4.Microservizi.AppCore.Exceptions;
using Gruppo4.Microservizi.AppCore.Interfaces.Services;
using Gruppo4.Microservizi.AppCore.Models.Entities;
using Gruppo4.Microservizi.AppCore.Models.ModelContrib;
using Gruppo4.Microservizi.WebApi.DTOs;
using Gruppo4MicroserviziDTO.DTOs;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Gruppo4.Microservizi.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IPublishEndpoint _endpoint;

        public OrdersController(IOrderService orderService, IPublishEndpoint endpoint)
        {
            _orderService = orderService;
            _endpoint = endpoint;
        }

        [HttpGet]
        [Route("{guid}")]
        public async Task<IActionResult> GetOrderAsync(Guid guid)
        {
            var order = await _orderService.GetOrder(guid);
            if (order is null)
            {
                return NotFound();
            }

            return Ok(order);
        }


        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetOrders();
            return Ok(orders);
        }


        [HttpPost]
        [HttpPut]
        public async Task<IActionResult> InsertOrderAsync(OrderInsertDTO order)
        {
            var newOrder = new Order
            {
                Customer_Id = order.CustomerId,
                Products = new List<ProductContrib>(),
                Coupons = new List<Coupon>()
            };

            foreach (var product in order.Products)
            {
                newOrder.Products.Add(new ProductContrib
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
                return BadRequest(new { e.Message, e.Coupons });
            }

            catch (InvalidCustomerIdException e)
            {
                return BadRequest(new { e.Message });
            }
            catch (NotEnoughStockException e)
            {
                return BadRequest(new { e.Message, e.Products });
            }
            catch (NegativeOrZeroProductQuantityException e)
            {
                return BadRequest(new { e.Message, e.Product });
            }
            catch { throw; }

            var createdOrder = await _orderService.GetOrder(newOrder.Id);

            var newOrderEvent = new NewOrderEvent
            {
                Id = createdOrder.Id,
                IdCliente = createdOrder.Customer_Id,
                TotalPrice = createdOrder.TotalPrice,
                DiscountAmount = createdOrder.DiscountAmount,
                DiscountedPrice = createdOrder.DiscountedPrice
            };

            foreach (var product in createdOrder.Products)
            {
                newOrderEvent.Products.Add(new Gruppo4MicroserviziDTO.Models.ProductInOrder
                {
                    ProductId = product.Id,
                    OrderedQuantity = product.Quantity
                });
            }

            await _endpoint.Publish(newOrderEvent);

            return CreatedAtAction(nameof(GetOrderAsync), createdOrder);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _orderService.DeleteOrder(id);

            }
            catch (Exception)
            {
                //TODO: Aggiungere eccezione errore eliminazione ordine
                throw;
            }
            var order = await _orderService.GetOrder(id);
            var deletedOrderEvent = new DeletedOrderEvent
            {
                Id = id
            };

            foreach (var product in order.Products)
            {
                deletedOrderEvent.Products.Add(new Gruppo4MicroserviziDTO.Models.ProductInOrder
                {
                    ProductId = product.Id,
                    OrderedQuantity = product.Quantity
                });
            }

            await _endpoint.Publish(deletedOrderEvent);
            return Ok();
        }
    }
}

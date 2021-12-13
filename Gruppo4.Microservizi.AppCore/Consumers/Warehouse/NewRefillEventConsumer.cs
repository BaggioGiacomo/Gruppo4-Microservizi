using MassTransit;
using MacNuget.Warehouse.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gruppo4.Microservizi.AppCore.Interfaces.Services;
using Gruppo4.Microservizi.AppCore.Models.ModelContrib;

namespace Gruppo4.Microservizi.AppCore.Consumers.Warehouse
{
    public class NewRefillEventConsumer : IConsumer<NewRefillEvent>
    {
        private readonly IProductService _productService;

        public NewRefillEventConsumer(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Consume(ConsumeContext<NewRefillEvent> context)
        {
            var oldProduct = await _productService.GetProductById(context.Message.Product.Id);
            await _productService.UpdateProduct(new ProductContrib
            {
                Id = context.Message.Product.Id,
                Quantity = oldProduct.Quantity + context.Message.Product.Quantity

            });
        }
    }
}

using Gruppo4.Microservizi.AppCore.Interfaces.Services;
using MassTransit;
using Microservices.Ecommerce.DTO.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.AppCore.Consumers.Products
{
    public class DeleteProductEventConsumer : IConsumer<DeleteProductEvent>
    {
        private readonly IProductService _productService;

        public DeleteProductEventConsumer(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Consume(ConsumeContext<DeleteProductEvent> context)
        {
            await _productService.DeleteProduct(context.Message.Id);
        }
    }
}

using Gruppo4.Microservizi.AppCore.Interfaces.Services;
using MassTransit;
using Microservices.Ecommerce.DTO.Events;

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

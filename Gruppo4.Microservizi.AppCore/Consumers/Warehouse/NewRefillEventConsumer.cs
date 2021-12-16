using Gruppo4.Microservizi.AppCore.Interfaces.Services;
using Gruppo4.Microservizi.AppCore.Models.ModelContrib;
using MacNuget.Warehouse.Events;
using MassTransit;

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
                Id = oldProduct.Id,
                Quantity = oldProduct.Quantity + context.Message.Product.Quantity,
                Name = oldProduct.Name,
                Price = oldProduct.Price
            });
        }
    }
}

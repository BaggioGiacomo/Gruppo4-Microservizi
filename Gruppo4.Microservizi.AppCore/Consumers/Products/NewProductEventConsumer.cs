using Gruppo4.Microservizi.AppCore.Interfaces.Services;
using Gruppo4.Microservizi.AppCore.Models.ModelContrib;
using MassTransit;
using Microservices.Ecommerce.DTO.Events;

namespace Gruppo4.Microservizi.AppCore.Consumers.Products
{
    public class NewProductEventConsumer : IConsumer<NewProductEvent>
    {
        private readonly IProductService _productService;

        public NewProductEventConsumer(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Consume(ConsumeContext<NewProductEvent> context)
        {
            await _productService.InsertProduct(new ProductContrib
            {
                Id = context.Message.Id,
                Name = context.Message.Nome,
                Price = (decimal)context.Message.Prezzo
            });
        }
    }
}

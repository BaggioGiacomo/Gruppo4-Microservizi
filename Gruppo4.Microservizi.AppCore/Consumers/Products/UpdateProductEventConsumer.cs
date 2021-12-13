using Gruppo4.Microservizi.AppCore.Interfaces.Services;
using Gruppo4.Microservizi.AppCore.Models;
using Gruppo4.Microservizi.AppCore.Models.ModelContrib;
using MassTransit;
using Microservices.Ecommerce.DTO.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.AppCore.Consumers.Products
{
    public class UpdateProductEventConsumer : IConsumer<UpdateProductEvent>
    {
        private readonly IProductService _productService;

        public UpdateProductEventConsumer(IProductService productService)
        {
            _productService = productService;
        }

        public async Task Consume(ConsumeContext<UpdateProductEvent> context)
        {
            await _productService.UpdateProduct(new ProductContrib
            {
                Id = context.Message.Id,
                Name = context.Message.Nome,
                Price = (decimal)context.Message.Prezzo
            });
        }
    }
}

using Gruppo3.ClientiDTO.Domain.Events;
using Gruppo4.Microservizi.AppCore.Interfaces.Services;
using Gruppo4.Microservizi.AppCore.Models.ModelContrib;
using MassTransit;

namespace Gruppo4.Microservizi.AppCore.Consumers.Customers
{
    public class UpdateClientEventConsumer : IConsumer<UpdateClientEvent>
    {
        private readonly ICustomerService _consumerService;

        public UpdateClientEventConsumer(ICustomerService consumerService)
        {
            _consumerService = consumerService;
        }

        public async Task Consume(ConsumeContext<UpdateClientEvent> context)
        {
            await _consumerService.UpdateCustomer(new CustomerContrib
            {
                Id = context.Message.Id,
                Name = context.Message.Name,
                Surname = context.Message.Surname,
                BusinessName = context.Message.Businessname
            });
        }
    }
}

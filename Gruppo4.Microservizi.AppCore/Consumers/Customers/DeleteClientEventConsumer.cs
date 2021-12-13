using Gruppo3.ClientiDTO.Domain.Events;
using Gruppo4.Microservizi.AppCore.Interfaces.Services;
using MassTransit;

namespace Gruppo4.Microservizi.AppCore.Consumers.Customers
{
    public class DeleteClientEventConsumer : IConsumer<DeleteClientEvent>
    {
        private readonly ICustomerService _consumerService;

        public DeleteClientEventConsumer(ICustomerService consumerService)
        {
            _consumerService = consumerService;
        }

        public async Task Consume(ConsumeContext<DeleteClientEvent> context)
        {
            await _consumerService.DeleteCustomer(context.Message.Id);
        }
    }
}

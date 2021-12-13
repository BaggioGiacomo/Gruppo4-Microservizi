using Gruppo3.ClientiDTO.Domain.Events;
using Gruppo4.Microservizi.AppCore.Interfaces.Services;
using Gruppo4.Microservizi.AppCore.Models;
using Gruppo4.Microservizi.AppCore.Models.ModelContrib;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo4.Microservizi.AppCore.Consumers.Customers
{
    public class CreateClientEventConsumer : IConsumer<CreateClientEvent>
    {
        private readonly ICustomerService _consumerService;

        public CreateClientEventConsumer(ICustomerService consumerService)
        {
            _consumerService = consumerService;
        }

        public async Task Consume(ConsumeContext<CreateClientEvent> context)
        {
            await _consumerService.InsertCustomer(new CustomerContrib
            {
                Id = context.Message.Id,
                Name = context.Message.Name,
                Surname = context.Message.Surname,
                BusinessName = context.Message.Businessname
            });
        }
    }
}

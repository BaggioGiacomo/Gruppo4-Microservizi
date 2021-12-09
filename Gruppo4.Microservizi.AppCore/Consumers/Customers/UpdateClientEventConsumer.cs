using Gruppo3.ClientiDTO.Domain.Events;
using Gruppo4.Microservizi.AppCore.Interfaces.Services;
using Gruppo4.Microservizi.AppCore.Models;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await _consumerService.UpdateCustomer(new Customer
            {
                Id = context.Message.Id,
                Name = context.Message.Name,
                Surname = context.Message.Surname,
                BusinessName = context.Message.Businessname
            });
        }
    }
}

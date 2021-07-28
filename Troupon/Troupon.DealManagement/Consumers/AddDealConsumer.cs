using System;
using System.Threading.Tasks;
using MassTransit;
using Troupon.Events;

namespace Troupon.DealManagement.Consumers
{
    public class AddDealConsumer : IConsumer<AddDealCommand>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public AddDealConsumer(
            IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public Task Consume(
            ConsumeContext<AddDealCommand> context)
        {
            // Add in database and do other validations
            
            var newDeal = new Deal
            {
                Id = Guid.NewGuid(),
                Name = context.Message.Name,
                Description = context.Message.Description,
                Address = context.Message.Address,
                Image = context.Message.Image,
                CurrentPrice = context.Message.CurrentPrice,
                OriginalPrice = context.Message.OriginalPrice
            };

            _publishEndpoint.Publish<DealAdded>(new DealAdded {Deal = newDeal});
            
            return Task.CompletedTask;
        }
    }
}

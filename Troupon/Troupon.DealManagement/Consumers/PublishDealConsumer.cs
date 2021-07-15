using System;
using System.Threading.Tasks;
using MassTransit;
using Troupon.Events;

namespace Troupon.DealManagement.Consumers
{
    public class PublishDealConsumer : IConsumer<PublishDealRequest>
    {
        public Task Consume(
            ConsumeContext<PublishDealRequest> context)
        {
            Console.WriteLine("[DealManagement - PublishDeal] Event received");
            return Task.CompletedTask;
        }
    }
}

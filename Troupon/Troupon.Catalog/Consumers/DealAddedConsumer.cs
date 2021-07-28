using System.Threading.Tasks;
using MassTransit;
using Troupon.Catalog.Services;
using Troupon.Events;

namespace Troupon.Catalog.Consumers
{
    public class DealAddedConsumer : IConsumer<DealAdded>
    {
        private readonly IDealsDatabase _dealsDatabase;

        public DealAddedConsumer(
            IDealsDatabase dealsDatabase)
        {
            _dealsDatabase = dealsDatabase;
        }

        public Task Consume(
            ConsumeContext<DealAdded> context)
        {
            _dealsDatabase.AddDeal(context.Message.Deal);
            return Task.CompletedTask;
        }
    }
}

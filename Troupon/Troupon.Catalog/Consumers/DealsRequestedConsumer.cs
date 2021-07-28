using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MassTransit;
using Troupon.Catalog.Extensions;
using Troupon.Catalog.Services;
using Troupon.Events;

namespace Troupon.Catalog.Consumers
{
    public class DealsRequestedConsumer : IConsumer<DealsRequested>
    {
        private readonly IDealsDatabase _dealsDatabase;

        public DealsRequestedConsumer(
            IDealsDatabase dealsDatabase)
        {
            _dealsDatabase = dealsDatabase;
        }

        public async Task Consume(
            ConsumeContext<DealsRequested> context)
        {
            Console.WriteLine("[Catalog - DealsRequested] Event received");
            await context.RespondAsync<DealsRequestedResult>(new DealsRequestedResult { Deals = _dealsDatabase.GetDeals()});
        }
    }
}

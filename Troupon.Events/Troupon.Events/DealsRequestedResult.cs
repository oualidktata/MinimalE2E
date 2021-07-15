using System.Collections.Generic;
using api_facade.Models;

namespace Troupon.Events
{
    public class DealsRequestedResult
    {
        public IEnumerable<Deal> Deals { get; set; }
    }
}

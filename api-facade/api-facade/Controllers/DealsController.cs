using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_facade.Services;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Troupon.Events;

namespace api_facade.Controllers
{
    [ApiController]
    [Route("Catalog/[controller]")]
    public class DealsController : ControllerBase
    {
        private readonly IRequestClient<DealsRequested> _requestClient;
        private readonly IPublishEndpoint _publishEndpoint;

        public DealsController(
            IRequestClient<DealsRequested> requestClient,
            IPublishEndpoint publishEndpoint)
        {
            _requestClient = requestClient;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        /*[Authorize]*/
        public async Task<IEnumerable<Deal>> Get()
        {
            var response = await _requestClient.GetResponse<DealsRequestedResult>("");

            return response.Message.Deals;
        }

        [HttpPost]
        public IActionResult Add(AddDealCommand command)
        {
            _publishEndpoint.Publish<AddDealCommand>(command);

            return Ok();
        }

        [HttpPost("Publish")]
        public IActionResult Publish()
        {
            _publishEndpoint.Publish<PublishDealRequest>(new PublishDealRequest {DealId = 1});

            return Ok();
        }
    }
}

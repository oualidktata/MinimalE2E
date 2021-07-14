using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_facade.Models;
using api_facade.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

namespace api_facade.Controllers
{
    [ApiController]
    [Route("App2/[controller]")]
    [Authorize]
    public class DealsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Deal> Get()
        {
            var rpcClient = new RpcClient();

            var response = rpcClient.Call(string.Empty);

            rpcClient.Close();

            return JsonConvert.DeserializeObject<Deal[]>(response);
        }
    }
}

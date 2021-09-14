using Actio.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace actio.api.Controllers
{
    [Route("[controller]")]
    public class ActivitesController : Controller
    {
        private readonly IBusClient _busClient;
        public ActivitesController(IBusClient busClient)
        {
            this._busClient = busClient;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateActivity command)
        {
            command.Id = Guid.NewGuid();
            command.CreatedAt = DateTime.Now;
            await _busClient.PublishAsync(command);
            return Accepted($"activities/{command.Id}");
        }

    }
}
